using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb4Script : MonoBehaviour
{
    public float speed = 1.5f;
    GameObject goal2;

    // Start is called before the first frame update
    void Start()
    {
        goal2 = GameObject.Find("Goal2");
        transform.LookAt(goal2.transform);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + transform.forward * speed * Time.deltaTime;
    }
}
