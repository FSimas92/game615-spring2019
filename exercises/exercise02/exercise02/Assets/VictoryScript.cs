using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryScript : MonoBehaviour
{

    bool playerWon = false;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.name == "InvisibleTriggerCube5")
        {
            playerWon = true;
        }

    }

    private void OnGUI()
    {

        if (playerWon)
        {
            GUI.Label(new Rect(250, 250, 200, 200), "You win!");
        }
    }
}