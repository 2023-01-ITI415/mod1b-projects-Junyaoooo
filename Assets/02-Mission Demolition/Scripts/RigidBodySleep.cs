using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidBodySleep : MonoBehaviour
{
    private int sleepCountDown = 4;
    private Rigidbody rigid;
    // Start is called before the first frame update
    void Awake()
    {
        rigid=GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixUpdate()
    {
        if (sleepCountDown>0) 
        {
            rigid.Sleep();
            sleepCountDown--;
        }
    }
}
