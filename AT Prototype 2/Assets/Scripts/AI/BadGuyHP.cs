using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadGuyHP : MonoBehaviour
{


    public GameObject BadGuy;
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        //BadGuy = transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            BadGuy.GetComponent<BadGuy>().OnHit();
            
        }

    }

}
