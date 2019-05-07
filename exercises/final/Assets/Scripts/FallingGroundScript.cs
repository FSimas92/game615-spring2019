using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingGroundScript : MonoBehaviour
{
    public Material FallingMat;
    public Material normalMat;

    Vector3 startPosition;
    Quaternion startRotation;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        startRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(FallingGround());
        }
    }

    IEnumerator FallingGround()
    {
        transform.GetComponent<Renderer>().material = FallingMat;

        yield return new WaitForSeconds(0.8f);

        Rigidbody rb = gameObject.GetComponent<Rigidbody>();
        rb.useGravity = true;

        yield return new WaitForSeconds(3.5f);

        transform.GetComponent<Renderer>().material = normalMat;
        rb.useGravity = false;
        gameObject.transform.position = startPosition;
        gameObject.transform.rotation = startRotation;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        StopCoroutine(FallingGround());
    }
}
