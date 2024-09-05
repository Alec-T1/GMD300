using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManagement : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform CameraTarget;
    private Vector3 Offset;
    private Vector3 targetPosition;
    public float CameraSmoothness;
    private Vector3 velocity = Vector3.zero;

    private void Awake()
    {
        Offset= transform.position - CameraTarget.position;
    }

    private void LateUpdate()
    {
        targetPosition = CameraTarget.position + Offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, CameraSmoothness);
    }
}
