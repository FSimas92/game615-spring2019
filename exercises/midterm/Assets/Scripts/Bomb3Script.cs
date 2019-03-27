using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb3Script : MonoBehaviour
{
    public float speed = 1.5f;
    GameObject goal1;

    // Start is called before the first frame update
    void Start()
    {
        goal1 = GameObject.Find("Goal1");
        transform.LookAt(goal1.transform);
    }

    // Update is called once per frame
    void Update()
    {     
        transform.position = transform.position + transform.forward * speed * Time.deltaTime;
    }
}
