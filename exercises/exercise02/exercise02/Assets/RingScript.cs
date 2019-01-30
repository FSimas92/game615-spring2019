using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingScript : MonoBehaviour
{
	//This is how long the ring will move in each direction
	float moveRate = 3;
	//We will use this variable to store how much time there is left until
	//we change directions
	float moveTimer;
	//This will be how fast we move the ring each Update
	float moveSpeed = 0.05f;

    // Start is called before the first frame update
    void Start()
    {
		//Initialize the move timer to half the rate, this is tricky, but
		//it makes it so the ring will start right in front of the player shape
		//Don't worry too much about this right now.
		moveTimer = moveRate / 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            moveRate = 0;
            moveSpeed = 0;
        }


            //Decrement the timer, if it is less than zero, it is time to chenge directions!
            moveTimer = moveTimer - Time.deltaTime;
		if (moveTimer < 0) {
			//Change our move direction by multiplying the speed by -1
			moveSpeed = moveSpeed * -1;

			//Reset the timer
			moveTimer = moveRate;
		}

		//Move the transform of the gameObject using the "Translate" function
		transform.Translate(moveSpeed, 0, 0);
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.name == "InvisibleRespawnCube")
        {
            moveRate = 3;
            moveSpeed = 0.05f;
        }
    }
}
