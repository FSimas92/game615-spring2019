using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantGrowth5 : MonoBehaviour
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
        if (Button3Script.grow5 == true)
        {
            anim.SetBool("Grow5", true);
        }
    }
}
