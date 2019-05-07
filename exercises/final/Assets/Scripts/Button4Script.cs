using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button4Script : MonoBehaviour
{
    public static bool grow6 = false;
    public Material ButtonOnMat;
    public GameObject finalpath;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Pressed");

            grow6 = true;

            transform.GetComponent<Renderer>().material = ButtonOnMat;

            finalpath.SetActive(true);
        }
    }
}
