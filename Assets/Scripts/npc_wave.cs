using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npc_wave : MonoBehaviour
{
    // Start is called before the first frame update
    Animator anim;
    bool iswaving;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        iswaving=true;
    }

    // Update is called once per frame
    void Update()
    {
       if(iswaving==false){
            anim.SetBool("iswaving",true);
            iswaving=true;
       }
        if(iswaving==true){
                            anim.SetBool("iswaving",false);
                            iswaving=false;

       }
        
    }
}
