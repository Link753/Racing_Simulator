using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadNextSection : MonoBehaviour
{
    public GameObject start, middle;
    int random, Sections, SpawnedSections;
    Vector3 targetRotation;
    
    void Start()
    {
        SpawnedSections = 0;
    }

    public void Next(Vector3 player,Vector3 position, float PlayerY)
    {
        random = UnityEngine.Random.Range(0,3);
        Sections = 10;
        calcRotate(player,position,PlayerY);
        if(SpawnedSections >= Sections)
        {
            FinishSpawn(position);
        }
        else
        {
            SpawnedSections++;
            SpawnSection(position);
        }
    }

    void calcRotate(Vector3 player, Vector3 position, float PlayerY)
    {
        if (Math.Abs(PlayerY) > 135 && Math.Abs(PlayerY) <= 225)
        {
            targetRotation = new Vector3(0.0f, 180.0f, 0.0f);
        }
        else if (Math.Abs(PlayerY) <= 135 && Math.Abs(PlayerY) > 45)
        {
            targetRotation = new Vector3(0.0f, 90.0f, 0.0f);
        }
        else if (Math.Abs(PlayerY) > 225 && Math.Abs(PlayerY) <= 315)
        {
            targetRotation = new Vector3(0.0f, 270.0f, 0.0f);
        }
        else
        {
            targetRotation = new Vector3(0.0f, 0.0f, 0.0f);
        }
    }

    void SpawnSection(Vector3 position)
    {
        if (random == 0)
        {
            var Object = Instantiate(middle, new Vector3(position[0], position[1], position[2]), Quaternion.Euler(targetRotation));
            Object.transform.parent = GameObject.Find("Sections").transform;
        }
        else if (random == 1)
        {
            var Object = Instantiate(middle, new Vector3(position[0], position[1], position[2]), Quaternion.Euler(new Vector3(targetRotation.x, targetRotation.y, 180.0f)));
            Object.transform.parent = GameObject.Find("Sections").transform;
        }
        else
        {
            var Object = Instantiate(start, new Vector3(position[0], position[1], position[2]), Quaternion.Euler(targetRotation));
            Object.transform.parent = GameObject.Find("Sections").transform;
        }
    }

    void FinishSpawn(Vector3 position)
    {
        Instantiate(start, new Vector3(position[0], position[1], position[2]), Quaternion.Euler(targetRotation.x, targetRotation.y, 180.0f));
    }
}
