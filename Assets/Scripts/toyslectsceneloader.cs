 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class toyslectsceneloader : MonoBehaviour
{
         public Material Green;
   //  public Scene level;
     public Material Red;
      public GameObject Object;
      private bool isinmissionarea;

    // Start is called before the first frame update
    void Start()
    {
         Object.GetComponent<MeshRenderer> ().material = Red;
         isinmissionarea=false;
         
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F) &&isinmissionarea==true )
            {
                Object.GetComponent<MeshRenderer> ().material = Green;
                isinmissionarea =false;  
            }
           
    }

    private void OnTriggerStay(Collider other)

    {
       
       isinmissionarea=true;
        if(other.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.Q))
        {
            DataPersistanceManager.instance.SaveGame();
            SceneManager.LoadSceneAsync("Toystoreselection");
        }
          
          
    }
}
