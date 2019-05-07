using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridPlatResetScript : MonoBehaviour
{
    public Material FallingMat;
    public Material normalMat;

    public MeshRenderer platMesh;

    Vector3 startPosition;
    Quaternion startRotation;

    // Start is called before the first frame update
    void Start()
    {
        platMesh = GetComponent<MeshRenderer>();

        startPosition = transform.position;
        startRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (ButtonScript2.grow4 == true && Button3Script.grow5 == true)
        {
            platMesh.enabled = true;
        }
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

        yield return new WaitForSeconds(1.0f);

        transform.GetComponent<Renderer>().material = normalMat;
        rb.useGravity = false;
        gameObject.transform.position = startPosition;
        gameObject.transform.rotation = startRotation;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        StopCoroutine(FallingGround());
    }
}
