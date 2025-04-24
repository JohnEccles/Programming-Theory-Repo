using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField]
    private CharacterController characterController;
    [SerializeField]
    private float playerSpeed = 1.0f;
    [SerializeField]
    private float rotationSpeed = 1.0f;

    private Vector3 move;
    

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    public void OnMove(InputAction.CallbackContext context) 
    {
        move = new Vector3(context.ReadValue<Vector2>().x,0, context.ReadValue<Vector2>().y) ;
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        // trigger once per press
        if (context.started == true) 
        {
            print("USER INTERACT"); 
        }
            
    }


    private void Update()
    {
        // Move Player
        characterController.Move(move * Time.deltaTime * playerSpeed);
        
    }

    private void LateUpdate()
    {
        if (move.sqrMagnitude == 0) { return; }
        // Rotate Player
        Quaternion toRotation = Quaternion.LookRotation(move, Vector3.up);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);

    }

}

