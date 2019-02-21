using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformRotation2 : MonoBehaviour
{
    float rotateSpeed = 60;
    public bool shouldRotate = true;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (shouldRotate)
        {
            transform.Rotate(0, rotateSpeed * Time.deltaTime, 0);
        }
    }
}
