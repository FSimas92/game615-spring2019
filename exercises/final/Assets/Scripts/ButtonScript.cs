using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public GameObject movingPlat;
    Animator PlatAnim;

    public Material ButtonOnMat;

    public static bool grow;

    // Start is called before the first frame update
    void Start()
    {
        PlatAnim = movingPlat.GetComponent<Animator>();
        PlatAnim.SetBool("Moving", false);

        grow = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlatAnim.SetBool("Moving", true);
            Debug.Log("Pressed");

            grow = true;

            transform.GetComponent<Renderer>().material = ButtonOnMat;
        }
    }
}
