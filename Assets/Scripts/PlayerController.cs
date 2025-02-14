using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator myAnimator;
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    
    private float playerSpeed = 4.0f;
    private float jumpHeight = 2.0f;
    private float gravityValue = -9.81f;
    private Transform cameraTransform;

    private void Start()
    {
        myAnimator = transform.GetComponent<Animator>();
        controller = transform.GetComponent<CharacterController>();
        cameraTransform = Camera.main.transform;
    }

    void Update()
    {
        groundedPlayer = isGrounded();
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector3 inputData= new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        MoveCharacter(inputData);

        if (inputData != Vector3.zero)
        {
            RotateCharacter(inputData);
        }

        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
           myAnimator.SetTrigger("Jump");
           playerVelocity.y += Mathf.Sqrt(jumpHeight * -2.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
        myAnimator.SetFloat("Movement",inputData.magnitude);
        myAnimator.SetBool("Grounded", groundedPlayer);
    }
    bool isGrounded()
    {
        Vector3 groundCheckPosition = transform.position;
        return Physics.Raycast(transform.position,-Vector3.up, 0.2F);
    }

    void MoveCharacter(Vector3 moveDirection)
    {
        Vector3 cameraForward = GetHorizontalCameraDirection();
        Vector3 movement = cameraForward * moveDirection.z + cameraTransform.right * moveDirection.x;
        movement.y = 0;
        movement.Normalize();
        movement *= playerSpeed * Time.deltaTime;
        controller.Move(movement);
    }
    Vector3 GetHorizontalCameraDirection()
    {
        Vector3 cameraForward = cameraTransform.forward;
        cameraForward.y = 0;
        cameraForward.Normalize();
        return cameraForward;
    }
    void RotateCharacter(Vector3 lookDirection)
    {
        Vector3 cameraForward = GetHorizontalCameraDirection();
        Vector3 targetDirection = cameraForward * lookDirection.z + cameraTransform.right * lookDirection.x;
        targetDirection.y = 0;
        if (targetDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
            // transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            transform.rotation = targetRotation;
        }
    }
}
/*
 * using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public InputHandler myInputHandler; 
    public Transform cameraTransform; 
    private CharacterController myCharacterController;
    private Animator myAnimator;


    public float moveSpeed = 5f; 
    public float rotationSpeed = 10f;
    public float gravity = 9.8f;
    public Vector3 verticalVelocity=new Vector3();
    public float jumpHeight=2;


    void Start()
    {      
        myAnimator = transform.GetComponent<Animator>();
        myCharacterController = transform.GetComponent<CharacterController>();
        if (cameraTransform == null)
        {
            cameraTransform = Camera.main.transform;
        }
    }

    void Update()
    {

        Vector3 inputData = myInputHandler.InputData;
        MoveCharacter(inputData);
        if (inputData != Vector3.zero)
        {
            RotateCharacter(inputData);
        }
        myAnimator.SetFloat("Movement",inputData.magnitude);
    }
    void ApplyGravity()
    {

    }

    void MoveCharacter(Vector3 moveDirection)
    {
        Vector3 cameraForward = GetHorizontalCameraDirection();
        Vector3 movement = cameraForward * moveDirection.z + cameraTransform.right * moveDirection.x;
        movement.y = 0; 
        movement.Normalize();
        movement *= moveSpeed * Time.deltaTime;
        myCharacterController.Move(movement+verticalVelocity);
    }

    void RotateCharacter(Vector3 lookDirection)
    {
        Vector3 cameraForward = GetHorizontalCameraDirection();
        Vector3 targetDirection = cameraForward * lookDirection.z + cameraTransform.right * lookDirection.x;
        targetDirection.y = 0; 
        if (targetDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }


    Vector3 GetHorizontalCameraDirection()
    {
        Vector3 cameraForward = cameraTransform.forward;
        cameraForward.y = 0;
        cameraForward.Normalize();
        return cameraForward;
    }
}
 */