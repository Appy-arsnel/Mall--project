using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour
{
       [SerializeField]private float _rotationspeed = 70f;

    // Start is called before the first frame update
    void Start()
    {
          Cursor.visible = true;
          Time.timeScale = 1; 
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0,_rotationspeed*Time.deltaTime,0);
    }
}
