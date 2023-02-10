using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    static public bool goalMet = false;
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        Projectile proj=other.GetComponent<Projectile>();
        if (proj != null) 
        {
            Goal.goalMet= true;
            Material mat = GetComponent<Renderer>().material;
            Color ccc= mat.color;
            ccc.a=0.8f;
            mat.color = ccc;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}