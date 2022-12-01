using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject main, leader;
    public void begin()
    {
        Application.LoadLevel(1);
    }

    public void Leader()
    {
        main.SetActive(false);
        leader.SetActive(true);
    }

    public void back()
    {
        main.SetActive(true);
        leader.SetActive(false);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
