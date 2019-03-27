using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuEffectScript : MonoBehaviour
{
    public GameObject prefab;
    public float Timer = 0.5f;

    public AudioClip menusong;
    public AudioSource songsource;

    // Start is called before the first frame update
    void Start()
    {
        songsource.clip = menusong;
        songsource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        Timer -= Time.deltaTime;
        if (Timer <= 0f)
        {
            Vector3 position = new Vector3(Random.Range(1, 20), Random.Range(1, 20), 1);
            GameObject pellet = Instantiate(prefab, position, Quaternion.identity);
            Destroy(pellet, 15f);
            Timer = 0.5f;
        }
    }
}
