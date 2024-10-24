using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class TitleScreenToGame : MonoBehaviour
{
    public Button StartB;
    // Start is called before the first frame update

    void Start()
    {
        StartB = GetComponent<Button>();
        StartB.onClick.AddListener(TaskOnClick);
    }


    void TaskOnClick()
    {
        SceneManager.LoadScene("OutdoorsScene");
        Debug.Log("You have clicked the button!");
    }
}
