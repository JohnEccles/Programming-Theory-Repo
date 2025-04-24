using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SwitchController : MonoBehaviour
{

    [SerializeField]
    private Electricity elec;
    [SerializeField]
    private bool inRange;

    public void OnInteract(InputAction.CallbackContext context) 
    {

        if (context.started == true && inRange) 
        { 
            elec.SetActive();
        }
            
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
    }


}
