using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    public GameObject player;

    [SerializeField]
    private Vector3 offset = new Vector3(0, 5, -7);


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() 
    { 

    }
    // LateUpdate Move camera After Vehicle
    void LateUpdate()
    {                                                      // Adds ofset for camera
        transform.position = player.transform.position + offset;
    }
}
