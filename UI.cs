using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Permissions;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    Text velocity, Timer;
    Rigidbody carrb;
    public double finalTime;
    bool RaceToggle, pauseToggle;
    public GameObject MainUI, FinishedUI, PauseUI;
    // Start is called before the first frame update
    void Start()
    {
        carrb = GameObject.Find("Car").GetComponent<Rigidbody>();
        velocity = GameObject.Find("VelocityTracker").GetComponent<Text>();
        Timer = GameObject.Find("Timer").GetComponent<Text>();
        RaceToggle = true;
    }

    // Update is called once per frame
    void Update()
    {
        velocity.text = (VelocityCalc()).ToString() + " MPH";
        timer();
        if (Input.GetKeyDown(KeyCode.Escape) & RaceToggle == true)
        {
            pauseToggle = !pauseToggle;
            Pause();
        }
    }

    void Pause()
    {
        if (pauseToggle)
        {
            Time.timeScale = 0.0f;
            MainUI.SetActive(false);
            PauseUI.SetActive(true);
        }
        else
        {
            Time.timeScale = 1.0f;
            MainUI.SetActive(true);
            PauseUI.SetActive(false);
        }
    }

    void timer()
    {
        if (RaceToggle)
        {
            Timer.text = (Time.timeSinceLevelLoad).ToString("0.0");
            finalTime = Convert.ToDouble(Time.timeSinceLevelLoad.ToString("0.0"));
        }
        else
        {
            Timer.text = finalTime.ToString();
        }
    }

    public void DisplayFinal()
    {
        pauseToggle = false;
        RaceToggle = false;
        MainUI.SetActive(false);
        FinishedUI.SetActive(true);
        GameObject.Find("Canvas/RaceFinishUI/FinalTimeDisplay").GetComponent<Text>().text = finalTime.ToString();
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        pauseToggle = !pauseToggle;
        Pause();
    }

    public void Reload()
    {
        Time.timeScale = 1f;
        Application.LoadLevel(1);
    }

    public void Quit()
    {
        Application.LoadLevel(0);
    }

    int VelocityCalc()
    {
        float totalvelocity;
        double velocity;
        totalvelocity = (carrb.velocity.x) * (carrb.velocity.x) + (carrb.velocity.z) * (carrb.velocity.z);
        velocity = Math.Sqrt(totalvelocity);
        return (int)velocity;
    }
}
