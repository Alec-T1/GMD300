using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemScript : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject GameController;
    private GameObject SoundController;


    private void FixedUpdate()
    {
        RotateGem();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            
            
            GameController = GameObject.FindGameObjectWithTag("GameController");
            SoundController = GameObject.FindGameObjectWithTag("SoundController");
            //Debug.Log("collided");
            //Tell the Game Manager that a Gem has been Collected
            GameController.GetComponent<GameManager>().GemCollect();
            //Tell the Sound Manager to play the Gem Collected sound
            SoundController.GetComponent<SoundManager>().GemCollect();
            //Destroy this Gem so that it cannot be collected again
            Destroy(this.gameObject);
        }
    }

    void RotateGem()
    {
        //Rotate the Gem constantly as a Primitive Animation
        this.transform.eulerAngles = new Vector3(this.transform.eulerAngles.x,this.transform.eulerAngles.y ,this.transform.eulerAngles.z+1f);
    }
}
