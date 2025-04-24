using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.GraphicsBuffer;

public class NewPlayerMovement : MonoBehaviour
{
    private Rigidbody rb;

    [SerializeField]
    private float playerSpeed = 20;
    [SerializeField]
    private float playerJumpHeight = 5;

    [SerializeField] Animator animator;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // used for Broadcast and Send Messages behaviour
    private void OnMove(InputValue value)
    {
        Debug.Log("MESSAGE MOVEMENT");
    }

    // used for unity Events behaviour 
    [System.Obsolete]
    public void OnMove(InputAction.CallbackContext context)
    {
        Debug.Log("EVENTS MOVEMENT");

        
 
        // Read Player input from movement
        Vector2 moveDir = context.ReadValue<Vector2>();
        // get current velocity
        Vector3 vel = rb.velocity;
        // update velocity
        vel.x = moveDir.x * playerSpeed;
        vel.z = moveDir.y * playerSpeed;
        rb.velocity = vel;



        if (moveDir.magnitude > 0) 
        {
            // Look in direction of movement
            // Disable Y.Rotation in editor for better effect
            rb.transform.LookAt(vel);
        }

        animator.SetFloat("Speed_f", rb.velocity.magnitude / playerSpeed);

    }

    /*
     * public void COMAND_NAME(InputAction.CallbackContext context)
    {

    }
     */
    public void OnLook(InputAction.CallbackContext context)
    {
        Debug.Log("Looking Around at the speed of sound");
    }
    public void OnJump(InputAction.CallbackContext context)
    {
        Debug.Log("JUMP!");
        Vector3 vel = rb.velocity;
        vel.y = playerJumpHeight;
        rb.velocity = vel;
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        Debug.Log("You interacted with an object");
    }






}
