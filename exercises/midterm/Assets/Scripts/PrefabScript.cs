using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabScript : MonoBehaviour
{
    public GameObject prefab;
    public float Timer = 3;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Timer -= Time.deltaTime;
        if (Timer <= 0f)
        {
            Vector3 position1 = new Vector3(Random.Range(1.5f, 12.5f), 1, Random.Range(-1.5f, -3f));
            Vector3 position2 = new Vector3(Random.Range(11f, 12.5f), 1, Random.Range(-1.5f, -12.5f));
            Vector3 position3 = new Vector3(Random.Range(1.5f, 3f), 1, Random.Range(-1.5f, -12.5f));
            Vector3 position4 = new Vector3(Random.Range(1.5f, 12.5f), 1, Random.Range(-11f, -13f));
            Instantiate(prefab, position1, Quaternion.identity);
            Instantiate(prefab, position2, Quaternion.identity);
            Instantiate(prefab, position3, Quaternion.identity);
            Instantiate(prefab, position4, Quaternion.identity);
            Timer = 2;
        }
    }
}
