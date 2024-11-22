using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Sttings")]
    [SerializeField] float speed = 5f;
    [SerializeField] float verticalSpeedOnGrounded = -5f;
    [SerializeField] float jumpVelocity = 10f;
    [Space]
    [Header("InputActions")]
    [SerializeField] InputActionReference move;
    [SerializeField] InputActionReference jump;
    [SerializeField] InputActionReference run;
    Animator animator;

    CharacterController characterController;

    Camera mainCamera;


    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        mainCamera = Camera.main;
        animator = GetComponentInChildren<Animator>();
    }
    private void OnEnable()
    {
        move.action.Enable();
        jump.action.Enable();
        run.action.Enable();

        move.action.performed += OnMove;
        move.action.started += OnMove;
        move.action.canceled += OnMove;

        jump.action.performed += OnJump;
    }



    private void Update()
    {
        UpdateMovementOnPlane();
        UpdateVerticalMovement();
        UpdateAnimation();
    }
    Vector3 lastVelocity = Vector3.zero;
    private void UpdateMovementOnPlane()
    {
        Vector3 movement = mainCamera.transform.right * rawMove.x + mainCamera.transform.forward * rawMove.z;

        float oldMovementMAgnitude = movement.magnitude;

        Vector3 movementProjectedOnPlane = Vector3.ProjectOnPlane(movement, Vector3.up);

        movementProjectedOnPlane = movementProjectedOnPlane.normalized * oldMovementMAgnitude;

        characterController.Move(movementProjectedOnPlane * speed * Time.deltaTime);
        lastVelocity = movementProjectedOnPlane;
    }
    float gravity = -9.8f;
    float verticalVelocity;

    void UpdateVerticalMovement()
    {
        verticalVelocity += gravity * Time.deltaTime;
        characterController.Move(Vector3.up * verticalVelocity * Time.deltaTime);
        lastVelocity.y = verticalVelocity;  
        if (characterController.isGrounded)
        { 
            verticalVelocity = verticalSpeedOnGrounded;
        }
        if (mustJump)
        {
            mustJump = false;
            //Debug.Log("Jump");
            if (characterController.isGrounded)
            { 
                verticalVelocity = jumpVelocity;
            
            }
        }
    }
    void UpdateAnimation()
    {
        animator.SetFloat("SidewardVelocity", lastVelocity.x);
        animator.SetFloat("ForwardVelocity", lastVelocity.z); 
    }
    private void OnDisable()
    {
        move.action.Disable();
        jump.action.Disable();  
        run.action.Disable();

        move.action.performed -= OnMove;
        move.action.started -= OnMove;
        move.action.canceled -= OnMove;

        jump.action.performed -= OnJump;
    }

    Vector3  rawMove = Vector3.zero;

    private void OnMove(InputAction.CallbackContext context)
    {
        Vector2 rawInput = context.ReadValue<Vector2>();
        rawMove = new Vector3(rawInput.x, 0f, rawInput.y);
        //Debug.Log("RawMOVE");
    }
    bool mustJump;
    private void OnJump(InputAction.CallbackContext context)
    {
        mustJump = true;
    }

}
