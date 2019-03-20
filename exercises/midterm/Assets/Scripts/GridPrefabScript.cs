using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridPrefabScript : MonoBehaviour
{
    public GameObject prefab;
    public int numberOfObjects = 20;
    public float radius = 60f;
    public Image timer;

    void Start()
    {
        CircleGrid();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer.fillAmount == 0.75f)
        {
            CircleGrid();
        }

        if (timer.fillAmount == 0.5f)
        {
            CircleGrid();
        }

        if (timer.fillAmount == 0.25f)
        {
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
