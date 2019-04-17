using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSimpleMovementScript : MonoBehaviour
{
    float moveSpeed = 12f;
    float jumpForce = 5.60f;

    float gravityModifier = 1f;

    public float yVelocity = 0;
    bool previousIsGroundedValue;

    CharacterController cc;

    float camFollowBehind = 8f;
    float camFollowAbove = 2.5f;

    // Start is called before the first frame update
    void Start()
    {
        cc = gameObject.GetComponent<CharacterController>();

        previousIsGroundedValue = cc.isGrounded;
    }

    // Update is called once per frame
    void Update()
    {
        float hAxis = Input.GetAxis("Horizontal");
        float vAxis = Input.GetAxis("Vertical");

        if (!cc.isGrounded)
        {
            yVelocity = yVelocity + Physics.gravity.y * gravityModifier * Time.deltaTime;

            if (Input.GetKeyUp(KeyCode.Space) && yVelocity > 0)
            {
                yVelocity = 0;
            }
        }
        else
        {
            if (!previousIsGroundedValue)
            {
                yVelocity = 0;
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                yVelocity = jumpForce;
            }
        }

        Vector3 vMove = Vector3.forward * Time.deltaTime * vAxis * moveSpeed;
        Vector3 hMove = Vector3.right * Time.deltaTime * hAxis * moveSpeed;
        Vector3 upMove = Vector3.up * Time.deltaTime * yVelocity;

        cc.Move(vMove + hMove + upMove);

        previousIsGroundedValue = cc.isGrounded;

        Vector3 cameraPosition = transform.position + (Vector3.up * camFollowAbove) + (Vector3.back * camFollowBehind);
        Camera.main.transform.position = cameraPosition;
        Camera.main.transform.LookAt(transform.position);
    }

}
