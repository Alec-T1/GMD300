using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Light;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if ((other.tag=="Player"))
        {
            Light.GetComponent<LightScript>().OnPressurePlateActive();
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if ((other.tag == "Player"))
        {
            Light.GetComponent<LightScript>().OnPressurePlateDeactive();
        }
       
    }
}
