using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{
    Rigidbody MyRigidbody;
    private Vector3 Direction;
    private GameObject MainCamera;
    // Start is called before the first frame update
    void Start()
    {
        MyRigidbody = this.gameObject.GetComponent<Rigidbody>();
        MainCamera = GameObject.FindWithTag("PlayerCamera");
        Direction = Camera.main.transform.TransformDirection(new Vector3(0, 0, 1));
        MyRigidbody.AddForce(Direction, ForceMode.Impulse);
        StartCoroutine(BulletDespawn());

    }

    void OnCollisionEnter(Collision collision)
    {
        Destroy(this.gameObject);
    }

    IEnumerator BulletDespawn()
    {
        //Print the time of when the function is first called.
        //Debug.Log("Started Coroutine at timestamp : " + Time.time);

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(5);
        Destroy(this.gameObject);
        //After we have waited 5 seconds print the time again.
        //Debug.Log("Finished Coroutine at timestamp : " + Time.time);
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
