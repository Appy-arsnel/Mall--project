using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 using UnityEngine.SceneManagement;

public class ToyStore_Manager : MonoBehaviour
{
    public GameObject[] toymodels;
    public int currenttoyindex;
    // Start is called before the first frame update
    void Start()
    {
       currenttoyindex=PlayerPrefs.GetInt("Selectedtoy",0);
        foreach(GameObject toy in toymodels){
            toy.SetActive(false);
        }
        toymodels[currenttoyindex].SetActive(true);
        
    }

    // Update is called once per frame
    void Update()
    {
        
            Cursor.lockState = CursorLockMode.Confined;


    }

    public void Changnext(){
        toymodels[currenttoyindex].SetActive(false);
        currenttoyindex++;
        if(currenttoyindex==toymodels.Length)   
        currenttoyindex=0;

        toymodels[currenttoyindex].SetActive(true);

        PlayerPrefs.SetInt("Selectedtoy",currenttoyindex);
        
        
         }
         public void ChangPrev(){
        toymodels[currenttoyindex].SetActive(false);
        currenttoyindex--;
        if(currenttoyindex== -1)   
        currenttoyindex=toymodels.Length-1;

        toymodels[currenttoyindex].SetActive(true);

        PlayerPrefs.SetInt("Selectedtoy",currenttoyindex);
        
        
         }
         public void SceneSelect(){
             Cursor.lockState = CursorLockMode.Locked;
          SceneManager.LoadScene("main");
        
         }
}
