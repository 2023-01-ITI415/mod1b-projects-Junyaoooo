using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonControl : MonoBehaviour
{
    //Timer
    private float time;
    //Interval between spawning firepoint
    private float timeInterval = 0.4f; 
    //firepoint create place
    public Transform firePoint;



    public void CreateFire() 
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));
        Vector3 dir = pos - transform.position;
        float angle = Vector3.Angle(Vector3.up, dir);

        if (pos.x > 0) 
        {
            //click screen right side
            angle=-angle;
        }

        transform.eulerAngles=new Vector3(0, 0, angle);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            CreateFire();
        }
    }
}
