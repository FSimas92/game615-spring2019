using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb5Script : MonoBehaviour
{
    public float speed = 1.5f;
    GameObject goal3;

    // Start is called before the first frame update
    void Start()
    {
        goal3 = GameObject.Find("Goal3");
        transform.LookAt(goal3.transform);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + transform.forward * speed * Time.deltaTime;
    }
}
