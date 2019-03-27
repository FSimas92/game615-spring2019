using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombScript : MonoBehaviour
{
    public float speed = 1.1f;
    GameObject goal;

    // Start is called before the first frame update
    void Start()
    {
        goal = GameObject.Find("Goal");
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(goal.transform);
        transform.position = transform.position + transform.forward * speed * Time.deltaTime;
    }
}
