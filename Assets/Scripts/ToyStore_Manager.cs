using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        
    }
}
