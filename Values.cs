using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Values : MonoBehaviour
{
    public float time, HighScore;

    void Start()
    {
        PlayerData data = SaveLoad.Load();
        HighScore = data.HighScore;
    }

    void Update()
    {
        time = (float)GameObject.Find("Canvas").GetComponent<UI>().finalTime;
    }

    void Checkscore()
    {
        if(time < HighScore || HighScore == 0)
        {
            HighScore = time;
        }
    }

    public void save()
    {
        Checkscore();
        SaveLoad.Save(this);
        Application.LoadLevel(0);
    }
}
