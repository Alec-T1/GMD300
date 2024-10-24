using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMovement : MonoBehaviour
{

    CharacterController controller;
    Vector2 AbsoluteMoveInput = Vector2.zero;
    Vector3 RelativeMoveInput = Vector3.zero;
    Vector3 desiredHorizontalVelocity = Vector3.zero;
    Vector3 currentHorizontalVelocity = Vector3.zero;
    Vector3 MoveCalc = Vector3.zero;
    Vector3 HorizontalMoveCalc = Vector3.zero;
    Vector3 FinalMovement = Vector3.zero;
    public float speed;
    public float MovementAcceleration = 10.0f;

    public GameObject Bullet;
    public GameObject BulletSpawn;
    GameObject BulletInstance;

    bool Grounded=false;
    public int PlayerHealth = 3;
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
        //Debug.Log(PlayerHealth);
        if (PlayerHealth <= 0)
        {
            Debug.Log("DEAD");
        }

        Debug.DrawRay(transform.position, new Vector3(AbsoluteMoveInput.x, 0, AbsoluteMoveInput.y), Color.red);
        Debug.DrawRay(transform.position, RelativeMoveInput, Color.blue);
        ProcessHorizontalVelocity();
        ApplyGravity();
        ApplyMovement();
        

    }




    private void ProcessHorizontalVelocity()
    {
        //Get input based on Camera Direction
        RelativeMoveInput = Camera.main.transform.TransformDirection(new Vector3(AbsoluteMoveInput.x, 0, AbsoluteMoveInput.y));
        RelativeMoveInput.y = 0;
        RelativeMoveInput = RelativeMoveInput.normalized;

        desiredHorizontalVelocity = RelativeMoveInput;

        //Calculate Acceleration
        currentHorizontalVelocity = Vector3.Lerp(currentHorizontalVelocity, desiredHorizontalVelocity, MovementAcceleration * Time.deltaTime);
        
    }

    public void ApplyMovement()
    {
        
        FinalMovement = new Vector3(currentHorizontalVelocity.x, FinalMovement.y, currentHorizontalVelocity.z);
        //applies gravity for jump
        FinalMovement.y = velocity;
        controller.Move(FinalMovement * speed * Time.deltaTime);
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
    }


    /// On Jump Executes When the Jump Button is Pressed 
    /// Makes the Velocity equal to that of the predetermined Jump Power.
    public void OnJump(InputValue input)
    {
        
       
        if (!controller.isGrounded) return;
        velocity = JumpPower;
    }

    void OnShoot(InputValue input)
    {
        BulletInstance = Instantiate(Bullet, BulletSpawn.transform.position, Quaternion.identity);
    }

    private void OnCollisionStay(Collision collision)
    {

        
        if (collision.other.tag == "MovingPlatform")
        {
            
            isOnMovingPlatform(collision.collider);
        }
    }

    public void OnEnemyHit()
    {
        PlayerHealth--;
        Debug.Log(PlayerHealth);
    }

    private void isOnMovingPlatform(Collider other)
    {
        Debug.Log("working platform");
        //FinalMovement.x=other.transform.position.x;
        //FinalMovement.z=other.transform.position.z;
        FinalMovement = other.transform.position;
    }


}
