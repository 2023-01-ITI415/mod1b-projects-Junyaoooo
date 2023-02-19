using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonControl : MonoBehaviour
{
    //Timer
    private float time;
    //Interval between spawning firepoint
    private float timeInterval = 0.31f; 
    //firepoint create place
    public Transform firePoint;

    private GameObject firePrefab;

    public void CreateFire() 
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));
        Vector3 dir = pos - transform.position;
        float angle = Vector3.Angle(Vector3.up, dir);

        if (pos.x > transform.position.x) 
        {
            //click screen right side
            angle=-angle;
        }

        transform.eulerAngles=new Vector3(0, 0, angle);

        //create fire
        time += Time.deltaTime;
        if (time >= timeInterval) 
        {
            time = 0;
            GameObject fireGo = Instantiate(firePrefab, firePoint.position, firePoint.rotation);
            Destroy(fireGo,4);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        firePrefab = Resources.Load<GameObject>("fire");
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
