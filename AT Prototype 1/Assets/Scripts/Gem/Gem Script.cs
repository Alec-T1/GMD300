using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemScript : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject GameController;
    private GameObject SoundController;

    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RotateGem();
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //
            
            GameController = GameObject.FindGameObjectWithTag("GameController");
            SoundController = GameObject.FindGameObjectWithTag("SoundController");
            Debug.Log("collided");
            GameController.GetComponent<GameManager>().GemCollect();
            SoundController.GetComponent<SoundManager>().GemCollect();
            Destroy(this.gameObject);
        }
    }

    void RotateGem()
    {
        this.transform.eulerAngles = new Vector3(this.transform.eulerAngles.x,this.transform.eulerAngles.y ,this.transform.eulerAngles.z+.2f);
    }
}
