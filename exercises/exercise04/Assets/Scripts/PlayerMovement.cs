using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;
    private Rigidbody p1rb;
    private Rigidbody p2rb;
    private Rigidbody p3rb;

    public PlatformRotation PR1;
    public PlatformRotation2 PR2;
    public PlatformRotation3 PR3;


    float launchForce = 0;

    Vector3 startPosition;
    Quaternion startRotation;

    Vector3 P1startPosition;
    Quaternion P1startRotation;

    Vector3 P2startPosition;
    Quaternion P2startRotation;

    Vector3 P3startPosition;
    Quaternion P3startRotation;

    GameObject Platform1;
    GameObject Platform2;
    GameObject Platform3;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        startPosition = transform.position;
        startRotation = transform.rotation;

        Platform1 = GameObject.Find("Platform1Parent");
        Platform2 = GameObject.Find("Platform2Parent");
        Platform3 = GameObject.Find("Platform3Parent");

        P1startPosition = Platform1.transform.position;
        P1startRotation = Platform1.transform.rotation;

        P2startPosition = Platform2.transform.position;
        P2startRotation = Platform2.transform.rotation;

        P3startPosition = Platform3.transform.position;
        P3startRotation = Platform3.transform.rotation;

        p1rb = Platform1.GetComponent<Rigidbody>();
        p2rb = Platform2.GetComponent<Rigidbody>();
        p3rb = Platform3.GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            launchForce = launchForce + 3f;
        }

        else
        {
            if (launchForce > 0)
            {
                launchForce = launchForce - 3f;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.name == "InvisibleRespawnCube")
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;

            gameObject.transform.position = startPosition;
            gameObject.transform.rotation = startRotation;

            Platform1.transform.position = P1startPosition;
            Platform1.transform.rotation = P1startRotation;
            p1rb.velocity = Vector3.zero;
            p1rb.angularVelocity = Vector3.zero;
            PR1.shouldRotate = true;

            Platform2.transform.position = P2startPosition;
            Platform2.transform.rotation = P2startRotation;
            p2rb.velocity = Vector3.zero;
            p2rb.angularVelocity = Vector3.zero;
            PR2.shouldRotate = true;

            Platform3.transform.position = P3startPosition;
            Platform3.transform.rotation = P3startRotation;
            p3rb.velocity = Vector3.zero;
            p3rb.angularVelocity = Vector3.zero;
            PR3.shouldRotate = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "InvisibleTriggerCube1" && Input.GetKeyUp(KeyCode.Space))
        {
            PR1.shouldRotate = false;
            p1rb.AddForce(Platform1.transform.forward * launchForce);
        }

        if (other.gameObject.name == "InvisibleTriggerCube2" && Input.GetKeyUp(KeyCode.Space))
        {
            PR2.shouldRotate = false;
            p2rb.AddForce(Platform2.transform.forward * launchForce);
        }

        if (other.gameObject.name == "InvisibleTriggerCube3" && Input.GetKeyUp(KeyCode.Space))
        {
            PR3.shouldRotate = false;
            p3rb.AddForce(Platform3.transform.forward * launchForce);
        }
    }

    private void OnGUI()
    {
        GUI.Label(new Rect(50, 50, 200, 200), launchForce.ToString());
    }
}
