using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Electricity : Hazard
{

    // INHERITED
    //  public bool isActive = true;
    //  public Object requiremnt;
    //  public float timeLimmit;
    //  public float timeLeft { get; private set; }

    public GameObject Switch;

    public override void SetActive() // POLYMORPHISM
    {
        isActive = !isActive;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && isActive)
        {
            print("Player is Electicuted");
        }
    }

    private void OnTriggerExit()
    {
        print("Player is Fine");
    }


}
