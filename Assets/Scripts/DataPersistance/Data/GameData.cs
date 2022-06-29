using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class GameData
{
    public Vector3 playerPosition;
    public Quaternion playerRotation;

    public GameData()
    {
        playerPosition = new Vector3(-64.63f, -0.932f, 4.81f);
        playerRotation = Quaternion.Euler(-0.211f, -0.191f, -0.213f);
    }
}