using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class bookstoreselect : MonoBehaviour
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

    private void OnTriggerEnter(Collider other)

    {
       
       isinmissionarea=true;

          SceneManager.LoadScene("Bookselection 1");

    }
}
