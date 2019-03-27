using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridPrefabScript : MonoBehaviour
{
    public GameObject prefab;
    public int numberOfObjects = 20;
    public float radius = 60f;

    float spawnTimer;
    public float spawnRate = 4;

    void Start()
    {
        CircleGrid();

        spawnRate = 4;
        spawnTimer = spawnRate;
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer = spawnTimer - Time.deltaTime;
        if (spawnTimer < 0)
            {
                spawnTimer = spawnRate;

                CircleGrid();
            }
    }

    void CircleGrid()
    {
        for (int i = 0; i < numberOfObjects; i++)
        {
            float angle = i * Mathf.PI * 2 / numberOfObjects;
            Vector3 pos = new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle)) * radius;
            Instantiate(prefab, pos, Quaternion.identity);
        }
    }

}
