using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour
{
    // Base Class for all Hazard Objects


    public bool isActive = true;

    public float Damadge;
    public Collider interactRange;
    public Collider damadgeRadius;

    public Object requiremnt;

    public float timeLimmit;
    public float timeLeft { get; private set; }

    private void Awake()
    {
        timeLeft = timeLimmit;

    }

    public void deactivate() 
    {
        isActive = false;
    }

    public void timer() 
    {
        timeLeft -= Time.deltaTime;
    }

   

}
