using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class Checkpoint : MonoBehaviour
{           
    private GameMaster gm;
     void Start()
    {
        gm=GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
    }

    void OnTriggerEnter(Collider other)
{
    if(other.CompareTag("Player")){
           // gm.lastCheckPointPos=transform.position;
    }
}
    // Start is called before the first frame update
   
    // Update is called once per frame
    void Update()
    {
        
    }
}
