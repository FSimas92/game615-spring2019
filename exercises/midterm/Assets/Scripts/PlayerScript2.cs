using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript2 : MonoBehaviour
{
    float moveSpeed = 12f;
    float jumpForce = 5.60f;

    float gravityModifier = 1f;

    public float yVelocity = 0;
    bool previousIsGroundedValue;

    CharacterController cc;

    public AudioClip levelSong;
    public AudioSource songsource;

    // Start is called before the first frame update
    void Start()
    {
        cc = gameObject.GetComponent<CharacterController>();

        previousIsGroundedValue = cc.isGrounded;

        songsource.clip = levelSong;
        songsource.Play();
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
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("bomb"))
        {
            Destroy(other.gameObject);
        }
    }
}
