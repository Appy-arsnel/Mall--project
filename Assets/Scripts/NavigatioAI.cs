using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class NavigatioAI : MonoBehaviour
{
    public GameObject the_Deastination;
    NavMeshAgent theAgent;
   // public GameObject the_Player;
    // Start is called before the first frame update
    void Start()
    {
        theAgent= GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        theAgent.SetDestination(the_Deastination.transform.position);
    }
}
