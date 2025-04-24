using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    //
    [SerializeField]
    private float speed = 20;
    [SerializeField]
    private float turnSpeed = 45.0f;

    private float horizontalInput;
    private float forwardInput;


    private Rigidbody playerRb;


    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        // Move the player forward
        playerRb.AddRelativeForce(Vector3.forward * speed * forwardInput);
        // Rotate Player based on horizontal Input
        transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);
        
         
    }


   

}
