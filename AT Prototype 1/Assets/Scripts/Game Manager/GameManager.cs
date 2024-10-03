using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public GameObject ExitPortal;
    private int Gems;
    private int GemsCollected;
    private string SceneName;
    // Start is called before the first frame update

    void Awake()
    {
        QualitySettings.vSyncCount = 1;
        Application.targetFrameRate = 60;
    }

    void Start()
    {
        Gems = GameObject.FindGameObjectsWithTag("Gem").Length;
        SceneName = SceneManager.GetActiveScene().name;
    }



    public void GemCollect()
    {
        GemsCollected++;
        Debug.Log(GemsCollected);
        if (GemsCollected ==  Gems)
        {
            OpenExit();
        }
    }

    public void OpenExit()
    {
        ExitPortal.SetActive(true);
    }

    public int returnTotalGems()
    {
        return Gems;
    }

    public int returnGemsCollected()
    {
        return GemsCollected;
    }

    public string returnSceneName()
    {
        return SceneName;
    }
}
