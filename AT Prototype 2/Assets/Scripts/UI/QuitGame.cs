using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuitGame : MonoBehaviour
{
    public Button QuitB;
    void Start()
    {
        QuitB = GetComponent<Button>();
        QuitB.onClick.AddListener(TaskOnClick);
    }


    void TaskOnClick()
    {
        Debug.Log("Quits");
        Application.Quit();
    }
}
