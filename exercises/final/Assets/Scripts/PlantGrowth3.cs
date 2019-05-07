using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantGrowth3 : MonoBehaviour
{
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GridScript.grow3 == true)
        {
            anim.SetBool("Grow3", true);
        }
    }
}
