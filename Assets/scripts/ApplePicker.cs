using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplePicker : MonoBehaviour
{

    [Header("Inscribed")]
    public int numBaskets = 3;
    public float basketBottomY = -15f;
    public float basketSpacingY = 2f;
    public GameObject basketPrefab;
    // Start is called before the first frame update
    void Start()
    {
        for (int h = 0; h < numBaskets; h++) 
        {
            GameObject tBasketGo = Instantiate<GameObject>(basketPrefab);
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY+(h*basketSpacingY);
            tBasketGo.transform.position = pos;
        }
    }

    //public void AppleMissed()
    //{
    //    GameObject[] appleArray = GameObject.FindGameObjectsWithTag("Apple");
    //    foreach (GameObject temGo in appleArray)
    //    {
    //        Destroy(temGo);
    //    }
    //}

    // Update is called once per frame
    void Update()
    {
        
    }
}
