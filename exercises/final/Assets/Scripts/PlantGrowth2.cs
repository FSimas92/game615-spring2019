using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantGrowth2 : MonoBehaviour
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
        if (Growth2Script.grow2 == true)
        {
            anim.SetBool("Grow2", true);
        }
    }
}
