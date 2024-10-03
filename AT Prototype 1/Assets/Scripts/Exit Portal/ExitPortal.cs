using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitPortal : MonoBehaviour
{
    // Start is called before the first frame update
    public string NextScene;


    void Awake()
    {
        //Deactivate upon the scene loading
        this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //If the player enters the Portal, load the next scene
        if ((other.tag == "Player"))
        {
            SceneManager.LoadScene(NextScene);
        }

    }
}
