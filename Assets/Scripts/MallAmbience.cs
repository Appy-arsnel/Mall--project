using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MallAmbience : MonoBehaviour
{
    public FMOD.Studio.EventInstance mBGMA;
    // Start is called before the first frame update
    void Awake()
    {
        mBGMA = FMODUnity.RuntimeManager.CreateInstance("event:/Mall Ambience");
        mBGMA.start();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
