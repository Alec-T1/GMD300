using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMovement : MonoBehaviour
{

    CharacterController controller;
    Vector2 AbsoluteMoveInput = Vector2.zero;
    Vector3 RelativeMoveInput = Vector3.zero;
    Vector3 MoveCalc = Vector3.zero;
    Vector3 HorizontalMoveCalc = Vector3.zero;
    Vector3 FinalMovement = Vector3.zero;
    public float speed;

    bool Grounded=false;
    public float gravity = -9.81f;
    public float gravitymultiplier = 3;
    float velocity;

    public float JumpPower = 4;
    
    

    void Awake()
    {
       Initialize();

    }

    void Initialize()
    {
        controller = GetComponent<CharacterController>();
    }

    /// Variables Initialized
    /// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// Active Code

    private void Update()
    {
        Debug.DrawRay(transform.position, new Vector3(AbsoluteMoveInput.x, 0, AbsoluteMoveInput.y), Color.red);
        Debug.DrawRay(transform.position, RelativeMoveInput, Color.blue);
        ApplyGravity();
        ApplyMovement();
        

    }


    private void ProcessHorizontalVelocity()
    {
        HorizontalMoveCalc = new Vector3(RelativeMoveInput.x, 0, RelativeMoveInput.y);
        //HorizontalMoveCalc = Vector3.Lerp(HorizontalMoveCalc, MoveCalc, Time.deltaTime);
    }
    public void ApplyMovement()
    {
        //FinalMovement = new Vector3(MoveCalc.x, MoveCalc.y, MoveCalc.z);
        //applies gravity for jump
        RelativeMoveInput.y = velocity;



        RelativeMoveInput = RelativeMoveInput.normalized * RelativeMoveInput.magnitude;
        Debug.Log(RelativeMoveInput);
        //Movement
        controller.Move(RelativeMoveInput * speed * Time.deltaTime);
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

    void OnMovement(InputValue input)
    {
        //Raw Input
        AbsoluteMoveInput = input.Get<Vector2>();
        //Converted to Local Space
        MoveCalc = new Vector3(AbsoluteMoveInput.x, 0, AbsoluteMoveInput.y);
        RelativeMoveInput = Camera.main.transform.TransformDirection(MoveCalc);

        //Chucked into MoveCalc for Final Game Movement


        //FIGURE OUT HOW TO LERP ONLY HORIZONTALS
        //MoveCalc = Vector3.Lerp(MoveCalc, new Vector3(AbsoluteMoveInput.x, MoveCalc.y, AbsoluteMoveInput.y), Time.deltaTime);
        //MoveCalc = new Vector3(AbsoluteMoveInput.x, MoveCalc.y, AbsoluteMoveInput.y);
    }


    /// On Jump Executes When the Jump Button is Pressed 
    /// Makes the Velocity equal to that of the predetermined Jump Power.
    public void OnJump(InputValue input)
    {
        if (!controller.isGrounded) return;
        velocity = JumpPower;
    }



}
