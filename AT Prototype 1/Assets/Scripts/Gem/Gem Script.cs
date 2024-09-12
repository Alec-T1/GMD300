using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemScript : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject GameController;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //
            GameController = GameObject.FindGameObjectWithTag("GameController");
            //Debug.Log(GameController.name);
            GameController.GetComponent<GameManager>().GemCollect();
            Destroy(this.gameObject);
        }
    }
}
