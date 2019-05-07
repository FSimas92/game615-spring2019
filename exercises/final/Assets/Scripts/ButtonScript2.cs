using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript2 : MonoBehaviour
{
    public static bool grow4 = false;
    public Material ButtonOnMat;

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

            grow4 = true;

            transform.GetComponent<Renderer>().material = ButtonOnMat;
        }
    }
}
