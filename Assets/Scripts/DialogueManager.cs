using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO.Pipes;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class DialogueManager : MonoBehaviour
{
    public NPC npc;

    bool isTalking = false;

    float distance;
    float curResponseTracker = 0;

    public GameObject player;
    public GameObject dialogueUI;

    public TMP_Text npcName;
    public TMP_Text npcDialogueBox;
    public TMP_Text playerResponse;
   private Animator animator;
     private bool is_waving;

     public int i = 0;

    // Start is called before the first frame update
    void Start()
    {
        dialogueUI.SetActive(false);
        Cursor.visible = false;
      animator= GetComponent<Animator>();
    }

   private void Update() {
       
        Convo();
    }

    void StartConversation()
    {   Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        isTalking = true;
        curResponseTracker = 0;
        dialogueUI.SetActive(true);
        npcName.text = npc.name;
        npcDialogueBox.text = npc.dialogue[i];
    

    }

    void EndDialogue()
    {   Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        isTalking = false;
        dialogueUI.SetActive(false);
              i = 0;
    }
  IEnumerator waving_waiter()
{     
     animator.SetBool("iswaving",true);
    yield return new WaitForSeconds(2);
   animator.SetBool("iswaving",false);         

}
void Convo(){
    distance = Vector3.Distance(player.transform.position, this.transform.position);
        if(distance <= 5f)
        {
            // if(Input.GetAxis("Mouse ScrollWheel") < 0f)
            // {
            //     curResponseTracker++;
            //     if (curResponseTracker >= npc.playerDialogue.Length - 1)
            //     {
            //         curResponseTracker = npc.playerDialogue.Length - 1;
            //     }
            // }
            // else if(Input.GetAxis("Mouse ScrollWheel") > 0f)
            // {
            //     curResponseTracker--;
            //     if(curResponseTracker < 0)
            //     {
            //         curResponseTracker = 0;
            //     }
            // }



            // change lines of conservations

            
            //trigger dialogue
            if(Input.GetKeyDown(KeyCode.E) && isTalking==false)
            {
                StartConversation();
                StartCoroutine(waving_waiter());
            }
            else if(Input.GetKeyDown(KeyCode.E) && isTalking == true)
            {
                EndDialogue();
            }
           
           
             if (isTalking == true && Input.GetKeyDown(KeyCode.Space) && i < npc.dialogue.Length - 1)
        {
            i++;
            npcDialogueBox.text = npc.dialogue[i];
            
        }
        else if (isTalking == true && Input.GetKeyDown(KeyCode.Space) && i == npc.dialogue.Length - 1)
        {
            EndDialogue();
        }
            

        }
   }
}