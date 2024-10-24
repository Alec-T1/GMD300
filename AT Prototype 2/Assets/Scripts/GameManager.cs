using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private GameObject[] Badguys;
    private GameObject[] BadGuySpawns;
    private Transform CurrentBadGuySpawn;
    public GameObject Test;
    private int BadGuyCount =5;
    public GameObject BadGuyTemplate;
    // Start is called before the first frame update
    void Awake()
    {
        BadGuySpawns = GameObject.FindGameObjectsWithTag("BadGuySpawn");


    }

    // Update is called once per frame
    void Update()
    {
        Badguys = GameObject.FindGameObjectsWithTag("BadGuy");
        Debug.Log(Badguys.Length);
        if (Badguys.Length == 0)
        {
            for (int i = 0; i < BadGuyCount; i++)
            {
                CurrentBadGuySpawn = BadGuySpawns[(int)Random.Range(0, 8)].transform;
                //Debug.Log(CurrentBadGuySpawn.name);
                //CurrentBadGuySpawn = Test;
                Instantiate(BadGuyTemplate, CurrentBadGuySpawn.position, Quaternion.identity);
            }
             BadGuyCount++;
        }
    }
}
