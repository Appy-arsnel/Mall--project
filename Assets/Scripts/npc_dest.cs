using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npc_dest : MonoBehaviour
{
    private int pivotpoint;
    void OnTriggerEnter(Collider other)
    {
         if(pivotpoint==6){
                        this.gameObject.transform.position=new Vector3(0,-1,0);

            pivotpoint=0;
        }
        if(pivotpoint==5){
                       this.gameObject.transform.position=new Vector3(-64,-1,8);

            pivotpoint=6;
        }
        
        if(pivotpoint==4){
            this.gameObject.transform.position=new Vector3(69,0,8);
            pivotpoint=5;
        }

        if(pivotpoint==3){
            this.gameObject.transform.position=new Vector3(-64,-1,8);
            pivotpoint=4;
        }
        
        if(pivotpoint==2){
            this.gameObject.transform.position=new Vector3(-70,0,8);
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
