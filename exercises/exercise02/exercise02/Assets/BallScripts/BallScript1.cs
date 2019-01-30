using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    { 
        }

    // Update is called once per frame
    void Update()
    {
        }

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.name == "InvisibleTriggerCube1")
        {
            Debug.Log("Contact was made!");
            Rigidbody rb = gameObject.GetComponent<Rigidbody>();
            rb.useGravity = true;
        }

    }
}
