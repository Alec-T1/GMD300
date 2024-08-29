using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMovement : MonoBehaviour
{

    CharacterController controller;
    Vector2 inputValue = Vector2.zero;
    Vector3 MoveCalc = Vector3.zero;
     void Awake()
    {
       controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        controller.Move(MoveCalc);
    }

    void OnMovement(InputValue input){
        Debug.Log(input.Get<Vector2>() * Time.deltaTime);
        inputValue = input.Get<Vector2>();
        MoveCalc = new Vector3(inputValue.x, 0, inputValue.y);
    }

}
