using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerPickup : MonoBehaviour
{

    private bool allowPickup = false;

    [SerializeField]
    public Transform holdArea;
    public GameObject heldObj;
    public Rigidbody heldObjRB;

    [SerializeField]
    private float pickupRange = 5.0f;
    [SerializeField]
    private float pickupForce = 150.0f;
    [SerializeField]
    public float moveSpeed;

    private void FixedUpdate()
    {
        if (heldObj != null)
        {
            // Move Object
            moveObject();
        }
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        //Debug.Log("You interacted with an object");
        //allowPickup = !allowPickup;


        if (context.started == true) // "== true" is just for readability
        {
            if (heldObj == null)
            {
                RaycastHit hit;

                // Changed transform.postion and transform.TransformDirection to holdArea. ###
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, pickupRange))
                {
                    // pickup object
                    //pickupObject(hit.transform.gameObject);

                    if (hit.transform.gameObject.tag == "Animal") 
                    {
                        hit.transform.gameObject.transform.parent = holdArea;
                        hit.transform.gameObject.transform.position = holdArea.position;
                        heldObj = hit.transform.gameObject;
                        heldObjRB = heldObj.GetComponent<Rigidbody>();
                        heldObjRB.constraints = RigidbodyConstraints.FreezePosition;
                    }

                    

                }

            }
            else
            {
                dropObject();
            }
        }

    }

    void moveObject()
    {
        if (Vector3.Distance(heldObj.transform.localPosition, holdArea.position) > heldObj.transform.localScale.magnitude)
        {
  
            Vector3 moveDirection = (holdArea.position - heldObj.transform.position);
            heldObjRB.AddForce(moveDirection * pickupForce);

        }
    }

    void pickupObject(GameObject pickObj)
    {
        Debug.Log("PICK OBJECT");
        if (pickObj.GetComponent<Rigidbody>())
        {
            heldObj = pickObj;
            Debug.Log("OBJECT has RB");

            heldObjRB = pickObj.GetComponent<Rigidbody>();
            heldObjRB.useGravity = false;
            

            heldObjRB.constraints = RigidbodyConstraints.FreezeRotation;



            heldObj.transform.SetParent(holdArea.transform);

            // OG LAYOUT
            //heldObjRB.transform.parent = holdArea;
            //heldObj = pickObj; // MOVED TO TOP 

        }


    }

    void dropObject()
    {

        Debug.Log("DROP OBJECT");
        heldObjRB.useGravity = true;
        

        heldObjRB.constraints = RigidbodyConstraints.None;

        heldObj.transform.parent = null;
        heldObj = null;

    }

   
}
