using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootSteps : MonoBehaviour
{
    private FMOD.Studio.EventInstance fsteps;
    public movement mv;
    public float timer = 0.0f;
    public float fSFXDuration = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        //fsteps = FMODUnity.RuntimeManager.CreateInstance("event:/FootStep");
    }

    // Update is called once per frame
    void Update()
    {
        if (mv.isWalking)
        {
            if (timer > fSFXDuration)
            {
                fStepSFXPlay();
                timer = 0.0f;
            }
            timer += Time.deltaTime;
        }
        else if (!mv.isWalking)
        {
            fsteps.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        }

    }

    private void fStepSFXPlay()
    {
        fsteps = FMODUnity.RuntimeManager.CreateInstance("event:/FootSteps");
        fsteps.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
        fsteps.start();
        //fsteps.release();
    }
}
