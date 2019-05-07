using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSimpleMovementScript : MonoBehaviour
{
    float moveSpeed = 12f;
    float jumpForce = 6.0f;

    float gravityModifier = 1f;

    public float yVelocity = 0;
    bool previousIsGroundedValue;

    CharacterController cc;

    float camFollowBehind = 8f;
    float camFollowAbove = 4f;

    Vector3 startPosition;
    Quaternion startRotation;
    bool goingBackToRespawn = false;

    public BoxCollider playerCollider;

    // Start is called before the first frame update
    void Start()
    {
        cc = gameObject.GetComponent<CharacterController>();

        previousIsGroundedValue = cc.isGrounded;

        startPosition = transform.position + Vector3.up * 0.3f;
        startRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (goingBackToRespawn == false) {
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
        }

        Vector3 cameraPosition = transform.position + (Vector3.up * camFollowAbove) + (Vector3.back * camFollowBehind);
        Camera.main.transform.position = cameraPosition;
        Camera.main.transform.LookAt(transform.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Respawn1"))
        {
            Debug.Log("Fell");
            StartCoroutine(goBackToRespawn());
        }

        if (other.gameObject.CompareTag("Respawn2"))
        {
            Debug.Log("Fell");
            StartCoroutine(goBackToRespawn2());
        }

        if (other.gameObject.CompareTag("Respawn3"))
        {
            Debug.Log("Fell");
            StartCoroutine(goBackToRespawn3());
        }
    }

    IEnumerator goBackToRespawn()
    {
        goingBackToRespawn = true;

        //1. Stop moving and disable collisons
        playerCollider.enabled = false;
        cc.enabled = false;
        //0. Wait for a second or soething
        yield return new WaitForSeconds(0.5f);
        
        //2. Move toward the startPosition
        while (Vector3.Distance(startPosition, transform.position) > 0.3f)
        {
            Vector3 vecToStart = (startPosition - transform.position).normalized;
            transform.position = transform.position + vecToStart * Time.deltaTime * 30f;
            yield return null;
        }
        //3. Enable all the stuff we disabled
        playerCollider.enabled = true;
        cc.enabled = true;
        goingBackToRespawn = false;
    }

    IEnumerator goBackToRespawn2()
    {
        goingBackToRespawn = true;

        playerCollider.enabled = false;
        cc.enabled = false;

        Vector3 Checkpoint2 = new Vector3(55.48f, 23.5f, 4.05f);

        yield return new WaitForSeconds(0.5f);

        while (Vector3.Distance(Checkpoint2, transform.position) > 0.5f)
        {
            Vector3 vecToCheckpoint2 = (Checkpoint2 - transform.position).normalized;
            transform.position = transform.position + vecToCheckpoint2 * Time.deltaTime * 30f;
            yield return null;
        }

        playerCollider.enabled = true;
        cc.enabled = true;
        goingBackToRespawn = false;
    }

    IEnumerator goBackToRespawn3()
    {
        goingBackToRespawn = true;

        playerCollider.enabled = false;
        cc.enabled = false;

        Vector3 Checkpoint3 = new Vector3(42.719f, 18.87f, 244.76f);

        yield return new WaitForSeconds(0.5f);

        while (Vector3.Distance(Checkpoint3, transform.position) > 0.5f)
        {
            Vector3 vecToCheckpoint2 = (Checkpoint3 - transform.position).normalized;
            transform.position = transform.position + vecToCheckpoint2 * Time.deltaTime * 30f;
            yield return null;
        }

        playerCollider.enabled = true;
        cc.enabled = true;
        goingBackToRespawn = false;
    }
}
