using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryScript : MonoBehaviour
{

    bool playerWon = false;
    public object Body;


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

        if (other.gameObject.name == "Body") 
        {
            Debug.Log("you won");
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