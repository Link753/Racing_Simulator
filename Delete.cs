using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delete : MonoBehaviour
{
    int childtotal;

    // Update is called once per frame
    void Update()
    {
        childtotal = transform.childCount;
        Debug.Log(transform.childCount);
        if(childtotal > 3)
        {
            Transform child = transform.GetChild(0);
            child.position = GameObject.Find("DespawnLocation").transform.position;
            child.SetParent(GameObject.Find("DespawnLocation").transform);
        }
    }
}
