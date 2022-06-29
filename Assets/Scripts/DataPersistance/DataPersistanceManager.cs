using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;
using System;
using System.IO;

public class DataPersistanceManager : MonoBehaviour
{
    private GameData gameData;
    public static DataPersistanceManager instance { get; private set; }

    private List<IDataPersistance> dataPersistanceObjects;

    [SerializeField] private string fileName;

    private FileDataHandler dataHandler;


    private void Awake()
    {
       
        if(instance != null)
        {
            Debug.Log("multiple same managers");
            Destroy(this.gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(this.gameObject);
        this.dataHandler = new FileDataHandler(Application.persistentDataPath, fileName);
    }

    private void OnEnable()
    {
        
            SceneManager.sceneLoaded += OnSceneLoaded;
        
            
       
    }

    private void OnDisable()
    {
         
        SceneManager.sceneLoaded -= OnSceneLoaded;
        
    }

    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {

        Debug.Log(SceneManager.GetActiveScene().name + "is loaded");
        this.dataPersistanceObjects = FindAllDataPersistanceObjects();
        LoadGame();
    }
    

 
    public void NewGame()
    {
        this.gameData = new GameData();
    }

    public void LoadGame()
    {
        this.gameData = dataHandler.Load();
        if(this.gameData == null)
        {
            Debug.Log("No saved game data");
            NewGame();
            
        }

        foreach (IDataPersistance dataPersistanceObj in dataPersistanceObjects)
        {
            dataPersistanceObj.LoadData(gameData);
        }
    }

    public void SaveGame()
    {
        if(this.gameData == null)
        {
            return;
        }
        foreach(IDataPersistance dataPersistanceObj in dataPersistanceObjects)
        {
            dataPersistanceObj.SaveData(ref gameData);
        }
        dataHandler.Save(gameData);
    }

    private void OnApplicationQuit()
    {
        string[] filePaths = Directory.GetFiles(Application.persistentDataPath); 
        foreach (string filePath in filePaths) File.Delete(filePath);
    }

    private List<IDataPersistance> FindAllDataPersistanceObjects()
    {
        IEnumerable<IDataPersistance> dataPersistanceObjects = FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistance>();
        return new List<IDataPersistance>(dataPersistanceObjects);
    }
}
