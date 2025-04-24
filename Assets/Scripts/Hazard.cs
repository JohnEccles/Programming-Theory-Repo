using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour
{
    // Base Class for all Hazard Objects


    public bool isActive = true;
    public Object requiremnt;
    public static float timeLimmit;
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
