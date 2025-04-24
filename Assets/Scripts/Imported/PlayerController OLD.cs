using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerOLD : MonoBehaviour
{

    public float horizontalInput;
    public float speed = 10.0f;

    // Range for Player X coordinate
    public float xRange = 10;


    public GameObject projectilePrefab;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Make Player Stay in bounds on X axis
        if (transform.position.x < -xRange) 
        {
            // Set current position to current with fixed X location
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        else if (transform.position.x > xRange)
        {
            // Set current position to current with fixed X location
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }


        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            // Launch a Projectile from the Player
            Instantiate(projectilePrefab, transform.position,projectilePrefab.transform.rotation);
        }



        // Player Movement
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
    }
}
