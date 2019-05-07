using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridScript : MonoBehaviour
{
    public GameObject prefab;
    public float gridX = 5f;
    public float gridY = 5f;
    private float spacing = 8f;

    private Vector3 startGridPos;

    public BoxCollider gridColl;

    public static bool grow3 = false;

    void Start()
    {
        startGridPos = new Vector3(26.7f, 17.27f, 253f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Grid");

            gridColl.enabled = false;

            for (int y = 0; y < gridY; y++)
            {
                for (int x = 0; x < gridX; x++)
                {
                    Vector3 pos = new Vector3(x, 0, y) * spacing;
                    Instantiate(prefab, startGridPos + pos, Quaternion.identity);
                }
            }

            grow3 = true;
        }
    }
}
