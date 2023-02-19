using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// control fire move
/// </summary>
public class FireControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.up*Time.deltaTime*8,Space.World);
    }
}
