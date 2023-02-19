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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "fish") 
        {
            return;
        }


        FishControl fishControl = collision.GetComponent<FishControl>();
        fishControl.Damage(3);
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.up*Time.deltaTime*8,Space.World);
    }
}
