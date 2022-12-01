using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public float time, HighScore;

    public PlayerData(Values value)
    {
        HighScore = value.HighScore;
        time = value.time;
    }
}
