using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FrogScript : MonoBehaviour
{
    public GameObject player;
    public GameObject mainCam;
    public Camera cam;
    public Transform rotator;
    float speed = 17f;
    public ParticleSystem ps;
    public Text victory;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
            ps.Play();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player.transform.parent = gameObject.transform;

            mainCam.transform.parent = rotator.transform;
            rotator.transform.Rotate(0, Time.deltaTime * 20f, 0);

            player.GetComponent<PlayerSimpleMovementScript>().enabled = false;
            transform.position = transform.position + transform.forward * speed * Time.deltaTime;

            victory.text = "you did it! safe travels!";
        }
    }
}
