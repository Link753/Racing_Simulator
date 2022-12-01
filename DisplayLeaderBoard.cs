using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayLeaderBoard : MonoBehaviour
{
    Text display;
    // Start is called before the first frame update
    void Start()
    {
        display = GameObject.Find("LeaderBoard").GetComponent<Text>();
        PlayerData data = SaveLoad.Load();
        display.text = "Your last time was: " + data.time + "\nThe Highscore is: " + data.HighScore;
        
    }
}
