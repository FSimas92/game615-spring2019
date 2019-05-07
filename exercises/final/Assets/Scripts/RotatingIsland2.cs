using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingIsland2 : MonoBehaviour
{
    public Material grownMat;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(15, 15, 15) * Time.deltaTime);

        if (Growth2Script.grow2 == true)
        {
            transform.GetComponent<Renderer>().material = grownMat;
        }
    }
}
