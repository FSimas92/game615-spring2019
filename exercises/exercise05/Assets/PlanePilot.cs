using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanePilot : MonoBehaviour
{
    public float speed = 15.0f;
    public float rollSpeed = 35f;
    public float pitchSpeed = 20f;

    public GameObject StarEffectPrefab;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveCamTo = transform.position - transform.forward * 10.0f + Vector3.up * 5.0f;
        float bias = 0.90f;
        Camera.main.transform.position = Camera.main.transform.position * bias + moveCamTo * (1.0f - bias);
        Camera.main.transform.LookAt(transform.position + transform.forward * 30.0f);

        transform.position += transform.forward * Time.deltaTime * speed;
        speed -= transform.forward.y * Time.deltaTime * 50.0f;
        if (speed < 5.0f)
        {
            speed = 5.0f;
        }
        if (speed > 100.0f)
        {
            speed = 100.0f;
        }

        float hAxis = Input.GetAxis("Horizontal");
        float vAxis = Input.GetAxis("Vertical");
        transform.Rotate(vAxis * rollSpeed * Time.deltaTime, hAxis * pitchSpeed / 4 * Time.deltaTime, -hAxis * pitchSpeed * Time.deltaTime, Space.Self);

        float terrainHeight = Terrain.activeTerrain.SampleHeight(transform.position);
        if (terrainHeight > transform.position.y)
        {
            transform.position = new Vector3(transform.position.x, terrainHeight, transform.position.z);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("RingTrigger"))
        {
            GameObject effect = Instantiate(StarEffectPrefab, gameObject.transform.position + gameObject.transform.forward * speed, Quaternion.identity);
            Destroy(effect, 5);
        }
    }
}
