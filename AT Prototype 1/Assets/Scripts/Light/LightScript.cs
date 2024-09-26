using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Material LightOn;
    public Material LightOff;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPressurePlateActive()
    {
        //Debug.Log("in Box");
        this.GetComponent<MeshRenderer>().material = LightOn;
    }
    public void OnPressurePlateDeactive()
    {
        //Debug.Log("left Box");
        this.GetComponent<MeshRenderer>().material = LightOff;
    }
}
