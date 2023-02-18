using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// control fish create
/// </summary>
public class GameControl : MonoBehaviour
{

    //maximum fish
    private int maxCount = 20;
    //now how many fish in the ground
    int currentCount;
    //Timer:
    private float time;
    //Interval between spawning fish
    private float timeInterval = 1.5f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CreateFish();
    }

    public void CreateFish() 
    {
        if (currentCount >= maxCount) 
        {
            return;
        }

        time += Time.deltaTime;
        if (time >= timeInterval) 
        {
            time = 0;
            currentCount++;
            //create random number get fish
            int random=Random.Range(1, 4);
            //from Resources get prefab
            GameObject fishPrefab = Resources.Load<GameObject>("fish"+random);
            int randomX = Random.Range(0,1);
            Vector3 poss = Camera.main.ViewportToWorldPoint(new Vector3(randomX,Random.value,-Camera.main.transform.position.z));
            GameObject fish = Instantiate(fishPrefab,poss,Quaternion.identity);
            FishControl fishControl=fish.GetComponent<FishControl>();
            //set fish swim random number
            fishControl.Speed= Random.Range(3f,9f);

            if (randomX == 0)
            {
                fishControl.currentDir = FishControl.FishDirection.Right;
            }
            else 
            {
                fishControl.currentDir = FishControl.FishDirection.Left;
            }
        }
    }
}
