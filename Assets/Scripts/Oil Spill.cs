using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class OilSpill : Hazard
{
    // INHERITED
    //  public bool isActive = true;
    //  public Object requiremnt;
    //  public float timeLimmit;
    //  public float timeLeft { get; private set; }

    

    public float elapsedTime;
    public float cleaningTime;
    public bool inRange = false;
    public CharacterMovement player;

    private void Awake()
    {
        elapsedTime = cleaningTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") 
        {
            inRange = true;
        }
    }

    private void OnTriggerExit()
    {
        inRange = false;
        elapsedTime = cleaningTime;
    }

    private void OnTriggerStay(Collider other)
    {
        elapsedTime -= Time.deltaTime;
    }

}

   


