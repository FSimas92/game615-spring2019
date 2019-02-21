using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfettiScript : MonoBehaviour
{
    float dropRate;
    float dropTimer;

    public GameObject ConfettiPrefab;

    // Start is called before the first frame update
    void Start()
    {
        dropRate = 0.01f;
        dropTimer = dropRate;
    }

    // Update is called once per frame
    void Update()
    {
        dropTimer -= Time.deltaTime;
        if (dropTimer < 0)
        {
            makeDrop();
            dropTimer = dropRate;
        }
    }
    void makeDrop()
    {
        float x = transform.position.x + Random.Range(-transform.localScale.x / 2 * 10, transform.localScale.x / 2 * 10);
        float z = transform.position.z + Random.Range(-transform.localScale.z / 2 * 10, transform.localScale.z / 2 * 10);
        Vector3 pos = new Vector3(x, transform.position.y + 5, z);

        GameObject drop = Instantiate(ConfettiPrefab, pos, Quaternion.identity);
        Material dropMat = drop.GetComponent<Renderer>().material;
        dropMat.color = new Color(Random.value, Random.value, Random.value);

        drop.transform.Rotate(0, Random.Range(0, 180), 0, Space.World);
        Rigidbody dropRB = drop.GetComponent<Rigidbody>();
        dropRB.AddForce(drop.gameObject.transform.forward * Random.Range(5, 10));

        Destroy(drop, 3);
    }
}
