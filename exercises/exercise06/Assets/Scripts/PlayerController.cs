using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float moveSpeed = 12f;
    float rotateSpeed = 90f;
    float jumpForce = 0.60f;

    Vector3 startPosition;
    Quaternion startRotation;

    float gravityModifier = 0.2f;

    public float yVelocity = 0;
    bool previousIsGroundedValue;

    CharacterController cc;

    float camLookAhead = 8.5f;
    float camFollowBehind = 3.7f;
    float camFollowAbove = 2.5f;

    public GameObject key;
    public GameObject door;
    bool gotkey;

    // Start is called before the first frame update
    void Start()
    {
        cc = gameObject.GetComponent<CharacterController>();

        previousIsGroundedValue = cc.isGrounded;

        startPosition = transform.position;
        startRotation = transform.rotation;

        gotkey = false;
    }

    // Update is called once per frame
    void Update()
    {
        float hAxis = Input.GetAxis("Horizontal");
        float vAxis = Input.GetAxis("Vertical");

        transform.Rotate(0, hAxis * rotateSpeed * Time.deltaTime, 0);

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

        Vector3 amountToMove = transform.forward * vAxis * moveSpeed * Time.deltaTime;

        amountToMove.y = yVelocity;

        cc.Move(amountToMove);

        previousIsGroundedValue = cc.isGrounded;

        Vector3 cameraPosition = transform.position + (Vector3.up * camFollowAbove) + (-transform.forward * camFollowBehind);
        Camera.main.transform.position = cameraPosition;
        Camera.main.transform.LookAt(transform.position + transform.forward * camLookAhead);

        if (gotkey == true)
        {
            key.transform.position = transform.position + (Vector3.up * camFollowAbove);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Salt"))
        {
            Debug.Log("Salt hit");
            gameObject.transform.position = startPosition;
            gameObject.transform.rotation = startRotation;
        }

        if (other.gameObject.CompareTag("Key"))
        {
            Debug.Log("Key get");
            key.transform.position = transform.position + (Vector3.up * camFollowAbove);
            gotkey = true;
        }

        if (other.gameObject.CompareTag("Door") && gotkey)
        {
            Destroy(door);
            Destroy(key);
            gotkey = false;
        }
    }
}
