using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    private bool atPos2=false;
    private Vector3 Pos1T;
    private Vector3 Pos2T;

    public GameObject Pos1;
    public GameObject Pos2;
    // Start is called before the first frame update
    void Awake()
    {
        Pos1T = transform.TransformPoint(Pos1.transform.position);
        Pos2T = transform.TransformPoint(Pos2.transform.position);
    }

    // Update is called once per frame
    void Update()
    {

        if (atPos2)
        {
            if (Vector3.Distance(this.transform.position, Pos1.transform.position) < 0.1f)
            {
                atPos2 = false;
            }
            else
            {
                //this.transform.position = Vector3.MoveTowards(this.transform.position, transform.TransformPoint(Pos2.transform.position), .1f);
                this.transform.position = Vector3.MoveTowards(this.transform.position, Pos1.transform.position, .1f);
            }
        }
        else
        {
            if (Vector3.Distance(this.transform.position, Pos2.transform.position) < 0.1f)
            {
                atPos2 = true;
            }
            else
            {
                //this.transform.position = Vector3.MoveTowards(this.transform.position, transform.TransformPoint(Pos1.transform.position), .1f);
                this.transform.position = Vector3.MoveTowards(this.transform.position, Pos2.transform.position, .1f);
            }
        }
        
    }
}
