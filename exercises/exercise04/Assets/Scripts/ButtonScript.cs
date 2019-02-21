using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    public GameObject player;

    public GameObject coincube;
    public GameObject coinmodel;
    public GameObject confetticube;

    public Text countText;
    public Text winText;
    private int count;
    public float speed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        SetCountText();
        winText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider player)
    {
        Renderer renderer = gameObject.GetComponent<Renderer>();
        Color buttonpressed = new Color(0, 255, 0);
        renderer.material.color = buttonpressed;

        count = count + 1;
        SetCountText();

        GameObject coin = Instantiate(coinmodel, coincube.transform.position, coincube.transform.rotation);
        Destroy(coin, 5);
    }

    void SetCountText()
    {
        countText.text = "Buttons: " + count.ToString();
        if (count >= 3)
        {
            winText.text = "Victory!";
            confetticube.SetActive(true);
        }
    }
}
