using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoalScript : MonoBehaviour
{
    public Text livesText;
    public Text lossText;
    public Text victoryText;

    public Image timer;
    public Button replayButton;
    public Button mainmenuButton;

    public GameObject ButtonGroup;
    public GameObject instantiator;

    private int lives;
    public float timeLeft;

    public AudioClip failclip;
    public AudioSource failsource;

    // Start is called before the first frame update
    void Start()
    {
        lives = 5;
        lossText.text = "";
        SetLivesText();

        victoryText.text = "";

        ButtonGroup.SetActive(false);

        failsource.clip = failclip;
    }

    // Update is called once per frame
    void Update()
    {
        timer.fillAmount -= 1.0f / timeLeft * Time.deltaTime;
        if (timer.fillAmount <= 0)
        {
            victoryText.text = "YOU WIN";
            ButtonGroup.SetActive(true);
            lossText.enabled = false;
            instantiator.SetActive(false);

            GameObject[] bombs = GameObject.FindGameObjectsWithTag("bomb");
            foreach (GameObject bomb in bombs)
                GameObject.Destroy(bomb);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("bomb"))
        {
            Destroy(other.gameObject);
            lives = lives - 1;
            SetLivesText();
            failsource.Play();
        }
    }

    void SetLivesText()
    {
        livesText.text = "LIVES: " + lives.ToString();
        if (lives <= 0)
        {
            lossText.text = "GAME OVER";
            ButtonGroup.SetActive(true);
            victoryText.enabled = false;
            timer.enabled = false;
            timer.fillAmount = 100;
            failsource.enabled = false;
        }
    }
}
