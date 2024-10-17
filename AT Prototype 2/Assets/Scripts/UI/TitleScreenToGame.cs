using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class TitleScreenToGame : MonoBehaviour
{
    public Button Start;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        Debug.Log("Switches to Game");
        SceneManager.LoadScene("OutdoorScene");
        
    }
}
