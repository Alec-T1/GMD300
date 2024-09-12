using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private int Gems;
    private int GemsCollected;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GemCollect()
    {
        GemsCollected++;
        Debug.Log(GemsCollected);
    }
}
