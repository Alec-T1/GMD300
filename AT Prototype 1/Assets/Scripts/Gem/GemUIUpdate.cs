using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GemUIUpdate : MonoBehaviour
{
    // Start is called before the first frame update
    private string newText;
    private GameObject GameManager;
    public Text txt;
    
    void Start()
    {
        //txt = this.text;
        GameManager = GameObject.FindGameObjectWithTag("GameController");
    }

    // Update is called once per frame
    void Update()
    {
        //Update the HUD to have the correct number of Collected Gems, and the Total Gems on the field
        newText = "Gems: " + GameManager.GetComponent<GameManager>().returnGemsCollected().ToString() + "/" + GameManager.GetComponent<GameManager>().returnTotalGems().ToString();
        txt.text = newText;
    }
}
