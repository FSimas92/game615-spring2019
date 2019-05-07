using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Growth2Script : MonoBehaviour
{
    public static bool grow2;
    public GameObject player;
    public BoxCollider box;

    // Start is called before the first frame update
    void Start()
    {
        grow2 = false;
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("grow2");
            grow2 = true;

            player.transform.Rotate(0f, -90f, 0f);
            box.enabled = false;
        }
    }
}
