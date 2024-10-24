using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadGuyHPTrigger : MonoBehaviour
{

    private bool isHit = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (!isHit)
            {
                isHit = true;
                other.gameObject.GetComponent<CharacterMovement>().OnEnemyHit();
                StartCoroutine(PlayerIFrames());
            }
            
        }
    }



    IEnumerator PlayerIFrames()
    {
        //Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time);

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(5);
        isHit = false;
        //After we have waited 5 seconds print the time again.
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
    }
}
