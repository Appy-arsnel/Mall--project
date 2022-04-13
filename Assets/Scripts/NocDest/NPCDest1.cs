using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDest1 : MonoBehaviour
{
    // Start is called before the first frame update
    public int pivotpoint;

  void  OnTriggerEnter(Collider other)
  {
      if(other.tag=="NPC"){
         if(pivotpoint==3){
              pivotpoint=0;
          }
          if(pivotpoint==2){
              this.gameObject.transform.position=new Vector3(-60,0,8);
              pivotpoint=3;
          }
           if(pivotpoint==1){
              this.gameObject.transform.position=new Vector3(-64,0,24);
              pivotpoint=2;
          }
          if(pivotpoint==0){
              this.gameObject.transform.position=new Vector3(-48,0,24);
              pivotpoint=1;
          }
          
           
      }
  }
}
