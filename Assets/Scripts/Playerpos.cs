using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerpos : MonoBehaviour
{
    // Start is called before the first frame update
    private GameMaster gm;
    void Start()
    {
        gm=GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
