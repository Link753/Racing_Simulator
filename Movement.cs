using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Threading;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float acceleration, stop, turnSpeed, MaxVelocity;
    float forward, turn, xspeed, zspeed, angle, tempaccel;
    Rigidbody rb;
    GameObject target,StartPoint;
    Transform Respawn;
    // Start is called before the first frame update
    void Start()
    {
        Respawn = GameObject.FindWithTag("StartPoint").GetComponent<Transform>();
        SetPosition();
        rb = GetComponent<Rigidbody>();
        target = GameObject.Find("MoveTowards");
        tempaccel = acceleration;
    }

    // Update is called once per frame
    void Update()
    {
        forward = Input.GetAxisRaw("Vertical");
        turn = Input.GetAxisRaw("Horizontal");
        calcSpeeds();
        if (forward > 0)
        {
            rb.AddForce(xspeed * acceleration,0,zspeed * acceleration);
        }
        else if (forward < 0 && rb.velocity.x < 0 && rb.velocity.z < 0)
        {
            rb.AddForce(-xspeed * stop,0,-zspeed * stop);
        }


        if (turn > 0)
        {
            transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime, Space.World);
        }
        else if (turn < 0)
        {
            transform.Rotate(Vector3.up, -turnSpeed * Time.deltaTime, Space.World);
        }
    }

    void calcSpeeds()
    {
        float noaccel = 0.0f;
        float targetx = target.transform.position.x;
        float targetz = target.transform.position.z;
        xspeed = targetx - transform.position.x;
        zspeed = targetz - transform.position.z;
        if(Math.Abs(rb.velocity.x) > MaxVelocity || Math.Abs(rb.velocity.z) > MaxVelocity)
        {
            acceleration = noaccel;
        }
        else
        {
            acceleration = tempaccel;
        }
    }

    void SetPosition()
    {
        transform.position = Respawn.position + new Vector3(0.0f,1.0f,0.0f);
        transform.eulerAngles = new Vector3(transform.rotation.x, 0.0f, transform.rotation.z);
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Respawn")
        {
            Respawn = col.transform;
        }
        else if(col.tag == "Death")
        {
            rb.velocity = new Vector3(0.0f, 0.0f, 0.0f);
            SetPosition();
        }
        else if(col.tag == "NextSection")
        {
            Vector3 position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            Vector3 colPosition = new Vector3(col.transform.position.x, col.transform.position.y, col.transform.position.z);
            Destroy(col);
            var script = GameObject.Find("NextArea").GetComponent<LoadNextSection>();
            UnityEngine.Debug.Log(col.transform.rotation.y);
            script.Next(position, colPosition, transform.eulerAngles.y);
        }
        else if(col.tag == "Finish")
        {
            GameObject.Find("Canvas").GetComponent<UI>().DisplayFinal();
        }
    }
}
