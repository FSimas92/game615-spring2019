using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IslandScript : MonoBehaviour
{
    public Material grownMat;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 25, 0) * Time.deltaTime);

        if (ButtonScript.grow == true)
        {
            transform.GetComponent<Renderer>().material = grownMat;
        }
    }
}
