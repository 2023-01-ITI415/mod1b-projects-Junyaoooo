using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ApplePicker : MonoBehaviour
{

    [Header("Inscribed")]
    public int numBaskets = 3;
    public float basketBottomY = -15f;
    public float basketSpacingY = 2f;
    public GameObject basketPrefab;
    public List<GameObject> basketList;
    // Start is called before the first frame update
    void Start()
    {
        basketList = new List<GameObject>();
        for (int h = 0; h < numBaskets; h++) 
        {
            GameObject tBasketGo = Instantiate<GameObject>(basketPrefab);
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY+(h*basketSpacingY);
           
            tBasketGo.transform.position = pos;
            basketList.Add(tBasketGo);
        }
    }

    public void AppleMissed()
    {
        GameObject[] appleArray = GameObject.FindGameObjectsWithTag("Apple");
        foreach (GameObject temGo in appleArray)
        {
            Destroy(temGo);
        }
        int basketIndex=basketList.Count-1;
        GameObject basketGo = basketList[basketIndex];
        basketList.RemoveAt(basketIndex);
        Destroy(basketGo);
        if (basketList.Count == 0) 
        {
            SceneManager.LoadScene("_Scene_0");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
