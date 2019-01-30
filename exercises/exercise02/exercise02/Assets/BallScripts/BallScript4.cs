using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript4 : MonoBehaviour
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

        if (other.gameObject.name == "InvisibleTriggerCube4")
        {
            Rigidbody rb = gameObject.GetComponent<Rigidbody>();
            rb.useGravity = true;
        }

    }
}
