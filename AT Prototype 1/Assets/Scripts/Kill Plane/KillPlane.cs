using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillPlane : MonoBehaviour
{
    private GameObject GameController;
    private string CurrentScene;

    // Start is called before the first frame update
    void Awake()
    {
        GameController = GameObject.FindGameObjectWithTag("GameController");
        
    }


    void OnTriggerEnter (Collider other)
    {
        if (other.tag == "Player")
        {
            //If the player enters the Kill Plane, reload the current scene
            SceneManager.LoadScene(GameController.GetComponent<GameManager>().returnSceneName());
        }
    }
}
