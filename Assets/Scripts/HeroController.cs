using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HeroController : MonoBehaviour
{

    private float gravity = -50f;
    private CharacterController characterController;
    private Vector3 velocity;
    private float speed = 3f;
    private Animator animator;
    Vector3 currentMovement;
    public float rotationFactorPerframe = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        //initally set reference variables
        PlayerInput playerInput = new PlayerInput();
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();

        //set the player input callbacks
        
    }

    // Update is called once per frame
    void Update()
    {
        //Add gravity
        velocity.y += gravity * Time.deltaTime;

        characterController.Move(velocity * Time.deltaTime);
        HandlePlayerRotation();
        HandlePlayerAnimation();


    }

    public void OnMovement(InputAction.CallbackContext movementValue)
    {
        Vector2 inputMovement = movementValue.ReadValue<Vector2>();
        velocity.x = inputMovement.x * speed;
        velocity.z = inputMovement.y * speed;
        velocity.y = 0;

    }

    public void OnJump(InputAction.CallbackContext jumpValue)
    {
        if (characterController.isGrounded)
        {
            velocity.y = 10f;
        }
        
    }

    public void HandlePlayerAnimation()
    {
        animator.SetFloat("Horizontal", characterController.velocity.x);
        animator.SetFloat("Vertical", characterController.velocity.z);

    }

    public void HandlePlayerRotation()
    {
        Vector3 positionToLookAt = new Vector3() { x = currentMovement.x, y = 0.0f, z = currentMovement.y };
        Quaternion currentRotation = transform.rotation;


        //if (isMovementPressed)
        //{
        //    Quaternion targetRotation = Quaternion.LookRotation(positionToLookAt);
        //    transform.rotation = Quaternion.Slerp(currentRotation, targetRotation, rotationFactorPerframe);
        //}
    }
    public Vector3 GetPosition()
    {
        return transform.position;
    } 
}
