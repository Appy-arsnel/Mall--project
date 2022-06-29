using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npc_wave : MonoBehaviour
{
    // Start is called before the first frame update
    Animator anim;
    bool iswaving;
     IEnumerator waving_waiter()
{     
     anim.SetBool("iswaving",true);
    yield return new WaitForSeconds(2);
   anim.SetBool("iswaving",false);         

}
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        iswaving=false;
    }

    // Update is called once per frame
    void Update()
    {   if((Input.GetKeyDown(KeyCode.E))&&iswaving==false){
                StartCoroutine(waving_waiter());
                           
    }
       
    }
}
