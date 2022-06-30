using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class toyslectsceneloader : MonoBehaviour

{       public bool FadeonStart=true; 
        public float fadeduration=2f;
         public Color fadecolor;
         private Renderer render;

         public Material Green;
   //  public Scene level;
     public Material Red;
      public GameObject Object;
      private bool isinmissionarea;

    // Start is called before the first frame update
    void Start()
    {     render=GetComponent<Renderer>();
         Object.GetComponent<MeshRenderer> ().material = Red;
         isinmissionarea=false;
        //  if(fadeOnStart){
        //     FadeIn();
        //  }
         
    }
    public void FadeIn(){
        Fade(1,0);
    }
    public void FadeOut(){
        Fade(0,1);
    }
    public void Fade(float alpahaIn ,float alphaOut){
       StartCoroutine(FadeRoutine(alpahaIn,alphaOut));
    }
    public IEnumerator FadeRoutine( float alphaIn ,float alphaOut){
         float timer=0;
        while(timer<fadeduration){
            Color newcolor =fadecolor;
            newcolor.a=Mathf.Lerp(alphaIn,alphaOut,timer/fadeduration);
            timer +=Time.deltaTime;
            yield return null;
        }
        Color newcolor2=fadecolor;
        newcolor2.a=alphaOut;
        render.material.SetColor("Color",newcolor2);
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
