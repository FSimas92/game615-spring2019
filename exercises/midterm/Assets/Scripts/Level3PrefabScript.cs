using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3PrefabScript : MonoBehaviour
{
    public GameObject prefab;
    float spawnTimer;
    public float spawnRate;

    // Start is called before the first frame update
    void Start()
    {
        spawnRate = Random.Range(1, 5);
        spawnTimer = spawnRate;
    }

    // Update is called once per frame
    void Update()
    {
        spawnRate = Random.Range(1, 5);
        spawnTimer = spawnTimer - Time.deltaTime;
        if (spawnTimer < 0)
        {
            spawnTimer = spawnRate;
            Instantiate(prefab, transform.position, Quaternion.identity);
        }
    }
}
