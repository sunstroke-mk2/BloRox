using UnityEngine;

public class PlayerFacade : MonoBehaviour
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

    void FixedUpdate()
    {
        groundedPlayer = isGrounded();
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
        myAnimator.SetBool("Grounded", groundedPlayer);
    }
     public bool isGrounded()
    {
        Vector3 groundCheckPosition = transform.position;
        return Physics.Raycast(transform.position,-Vector3.up, 0.2F);
    }

    public void Jump()
    {
        myAnimator.SetTrigger("Jump");
        playerVelocity.y += Mathf.Sqrt(jumpHeight * -2.0f * gravityValue);
    }
     public void MoveCharacter(Vector3 moveDirection)
    {

        Vector3 cameraForward = GetHorizontalCameraDirection();
        Vector3 movement = cameraForward * moveDirection.z + cameraTransform.right * moveDirection.x;
        movement.y = 0;
        movement.Normalize();
        movement *= playerSpeed * Time.deltaTime;
        myAnimator.SetFloat("Movement",movement.magnitude);
        controller.Move(movement);
    }
    Vector3 GetHorizontalCameraDirection()
    {
        Vector3 cameraForward = cameraTransform.forward;
        cameraForward.y = 0;
        cameraForward.Normalize();
        return cameraForward;
    }
    public void RotateCharacter(Vector3 lookDirection)
    {
        Vector3 cameraForward = GetHorizontalCameraDirection();
        Vector3 targetDirection = cameraForward * lookDirection.z + cameraTransform.right * lookDirection.x;
        targetDirection.y = 0;
        if (targetDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
            transform.rotation = targetRotation;
        }
    }
}
