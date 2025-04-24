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
    private float pickupRange = 10.0f;

    public GameObject heldItem;

    public bool isHeld = false;

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
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, pickupRange))
            {
                print("USER INTERACT WITH: " + hit.transform.gameObject.name);

                HandleInput(hit); // ABSTRACTION
            }
        }


        if (context.performed) 
        {
            print("MOSADSD");
            isHeld = true;
        }

        if (context.canceled)
        {
            print("opwqieouwoie");
            isHeld = false;
        }

        // Key Must be held
        if (context.canceled && !context.performed) 
        {
            //print(" THUS THOU ART A MAN OF PASSING FEVER");

            ///*
            
            //Debug.Log("Lifted Up");

            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, pickupRange))
            {
                HandleInput(hit); // ABSTRACTION
            }
            //*/
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


    private void HandleInput(RaycastHit hit)
    {
        // Change to if - else if to switch statements
        if (hit.transform.gameObject.tag == "Item")
        {

            if (heldItem != null)
            {
                heldItem.SetActive(true);
            }
            heldItem = hit.transform.gameObject;
            heldItem.SetActive(false);
        }
        else if (hit.transform.gameObject.tag == "Hazard")
        {
            // If hit object has component of a hazard
            if (hit.transform.gameObject.GetComponent<Hazard>() == true)
            {
                var Hazard = hit.transform.gameObject.GetComponent<Hazard>();

                if (Hazard.requiremnt == heldItem)
                {
                    Hazard.deactivate();
                    print("Requirement Met");

                    if (heldItem != null) // if holding an item
                    {
                        // Reset Held Item
                        heldItem.SetActive(true);
                        heldItem = null;
                    }


                }
                else if (Hazard.requiremnt == null)
                {
                    Hazard.deactivate();
                    print("No Requirement");
                }


            }
        }

        else if (hit.transform.gameObject.tag == "Fire")
        {
            // If hit object has component of a hazard
            if (hit.transform.gameObject.GetComponent<Hazard>() == true)
            {
                var Hazard = hit.transform.gameObject.GetComponent<Hazard>();

                if (Hazard.requiremnt == heldItem)
                {
                    Hazard.deactivate();
                    print("Requirement Met");

                    if (heldItem != null) // if holding an item
                    {
                        // Reset Held Item
                        heldItem.SetActive(true);
                        heldItem = null;
                    }
                }
            }
        }
        else if (hit.transform.gameObject.tag == "Oil Spill")
        {
            // If hit object has component of a hazard
            if (hit.transform.gameObject.GetComponent<Hazard>() == true)
            {
                var Oil_Spill = hit.transform.gameObject.GetComponent<OilSpill>();
                if (Oil_Spill.requiremnt == heldItem && Oil_Spill.elapsedTime <= 0)
                {
                    Oil_Spill.deactivate();
                    print("Requirement Met");

                    if (heldItem != null) // if holding an item
                    {
                        // Reset Held Item
                        heldItem.SetActive(true);
                        heldItem = null;
                    }
                }
            }
        }
    }


}

