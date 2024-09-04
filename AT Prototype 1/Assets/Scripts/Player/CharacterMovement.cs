using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMovement : MonoBehaviour
{

    CharacterController controller;
    Vector2 inputValue = Vector2.zero;
    Vector3 MoveCalc = Vector3.zero;
    public float speed;

    bool Grounded=false;
    public float gravity = -9.81f;
    public float gravitymultiplier = 3.0f;
    float velocity;

    public float jumppower = 4;
    
    

    void Awake()
    {
       controller = GetComponent<CharacterController>();

    }



    private void Update()
    {
        
        ApplyGravity();
       ApplyMovement();
        

    }

    private void FixedUpdate()
    {
        
    }

    public void ApplyMovement()
    {
        MoveCalc.y = velocity;
        controller.Move(MoveCalc * speed * Time.deltaTime);
    }

    public void ApplyGravity()
    {
        Grounded = controller.isGrounded;
        if (Grounded&&velocity<-1.0f)
        {
            velocity = -1.0f;
        }
        else
        {
            velocity += gravity * gravitymultiplier * Time.deltaTime;
        }
    }

    void OnMovement(InputValue input){
        //Debug.Log(input.Get<Vector2>() * Time.deltaTime);
        inputValue = input.Get<Vector2>();
        MoveCalc = new Vector3(inputValue.x, MoveCalc.y, inputValue.y);
    }

    void OnCollisionStay()
    {
        //isGrounded = true;
    }

    //public void OnJump(InputAction.CallbackContext context)
    public void OnJump(InputValue input)

    {
        Debug.Log("HIT");
        //if (!context.started) return;
        if (!controller.isGrounded) return;
        velocity = jumppower;
        Debug.Log("end");


        //rb.AddForce(jump * jumpForce, ForceMode.Impulse);
        //isGrounded = false;



    }



}
