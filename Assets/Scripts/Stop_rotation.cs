using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stop_rotation : MonoBehaviour
{   
    public GameObject cam;
    // Start is called before the first frame update
    void Update()
    {
        StopRotation();
    }

    // Update is called once per frame
    void StopRotation()
    {
        cam.transform.eulerAngles =new Vector3(0f,0f,0f);
    }
}
