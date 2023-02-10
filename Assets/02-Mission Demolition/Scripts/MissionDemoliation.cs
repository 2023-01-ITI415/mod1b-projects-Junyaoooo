using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.XR;

public enum GameMode {
    idle,
    playing,
    levelEnd
}
public class MissionDemoliation : MonoBehaviour
{
    static private MissionDemoliation SS;
    public Text uitLevel;
    public Text uitShots;
    public Vector3 castlePos;
    public GameObject[] castles;


    public int level;
    public int levelMax;
    public int shotsTaken;
    public GameMode mode = GameMode.idle;
    public GameObject castle;
    public string showing = "Show Slingshot";


    // Start is called before the first frame update
    void Start()
    {
        SS = this;
        level = 0;
        shotsTaken = 0;
        levelMax = castles.Length;
        StartLevel();
    }


    void UpdateGUI() 
    {
        uitLevel.text = "Level: " + (level + 1) + " of" + levelMax;
        uitShots.text = "Shots Taken: " + shotsTaken;
    }



    void StartLevel()
    {
        if (castle != null) 
        {
            Destroy(castle);
        }
        Projectile.DESTROY_PROJECTILES();
        castle = Instantiate<GameObject>(castles[level]);
        castle.transform.position = castlePos;
        Goal.goalMet = false;
        UpdateGUI();
        mode = GameMode.playing;
    }


    void NextLevel() 
    {
        level++;
        if (level == levelMax) 
        {
            shotsTaken = 0;
            level = 0;
        }
        StartLevel();
    }

    static public void SHOT_FIRED() 
    {
        SS.shotsTaken++;
    }

    static public GameObject GET_CASTLE()
    {
        return SS.castle;
    }


    void Update()
    {
        UpdateGUI();
        if ((mode == GameMode.playing) && Goal.goalMet)
        {
            mode = GameMode.levelEnd;
            Invoke("NextLevel",3f);
        }
    }
}
