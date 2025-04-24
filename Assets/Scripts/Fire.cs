using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : Hazard
{
    // INHERITED
    //  public bool isActive = true;
    //  public Object requiremnt;
    //  public float timeLimmit;
    //  public float timeLeft { get; private set; }

    public float damadge;
    public float damadgeInterval;

    private float elapsedTime = 0;



    private void Update()
    {
        elapsedTime += Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        print("Player IS NOW ON FIRE");
    }

    private void OnTriggerExit()
    {
        print("Player is Fine");
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && elapsedTime >= damadgeInterval) 
        {
            elapsedTime = 0;
            damadgePlayer();
        }
    }

    private void damadgePlayer() 
    {
        print("Player takes: " + damadge + " fire damadge");
    }

}
