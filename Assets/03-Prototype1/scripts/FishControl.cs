using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishControl : MonoBehaviour
{

    //Fish Direction
    public enum FishDirection
    {
        Left,
        Right
    }


    //fish blood
    private float hp;
    //fish speed
    private float speed1=5f;
    //fish end point
    private Vector3 target1;
    //now fish Direction
    public FishDirection currentDir = FishDirection.Left;

    public float Speed 
    {
        set { speed1 = value; }
    }


    public FishDirection CurrentDir 
    {
        set { CurrentDir = value; }
    }
    //set the end point for fish
    //when fish left side end than go right
    //when fish right side end than go left
    private void SetTarget() 
    {
        int scalX1 = currentDir == FishDirection.Left ? -1 : 1;
        transform.localScale=new Vector3(scalX1, 1, 1);

        //random y from 0 to 1:
        float randomY = Random.value;
        //fish head setting
        if (currentDir == FishDirection.Left)
        {
            //control fish swim left side
            target1 = Camera.main.ViewportToWorldPoint(new Vector3 (0,randomY,-Camera.main.transform.position.z));
        }
        else 
        {
            //control fish swim right side
            target1 = Camera.main.ViewportToWorldPoint(new Vector3(1, randomY, -Camera.main.transform.position.z));
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        SetTarget();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = Vector3.MoveTowards(transform.position,target1,Time.deltaTime*speed1);
        transform.position = pos;

        //if fish get the end point, if get, then set another new end point:
        if (Vector3.Distance(transform.position,target1)<0.06f) 
        {
            //if fish and end point distance less than 0.06, then think that they equal
            currentDir = currentDir == FishDirection.Left?FishDirection.Right:FishDirection.Left;
            //end point
            SetTarget();
        }
    }
}
