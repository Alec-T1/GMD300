using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillPlane : MonoBehaviour
{
    private GameObject GameController;
    private string CurrentScene;

    // Start is called before the first frame update
    void Start()
    {
        GameController = GameObject.FindGameObjectWithTag("GameController");
        //CurrentScene = GameController.GetComponent<GameManager>().returnSceneName();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter (Collider other)
    {
        if (other.tag == "Player")
        {
            //Debug.Log("Scene Loader");
            SceneManager.LoadScene(GameController.GetComponent<GameManager>().returnSceneName());
        }
    }
}
