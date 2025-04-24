using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimalCounter : MonoBehaviour
{
    public Text CounterText;

    private int Count = 0;

    private void Start()
    {
        Count = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player") 
        {
            Count += 1;
            UpdateCounter();
        }
            
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag != "Player")
        {
            Count -= 1;
            UpdateCounter();
        }
    }

    private void UpdateCounter() 
    {
        CounterText.text = "Count : " + Count;
    }

}
