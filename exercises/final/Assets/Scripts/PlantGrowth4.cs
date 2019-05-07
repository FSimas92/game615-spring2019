using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantGrowth4 : MonoBehaviour
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
        if (ButtonScript2.grow4 == true)
        {
            anim.SetBool("Grow4", true);
        }
    }
}
