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

    private int lives;
    float timeLeft = 30.0f;

    // Start is called before the first frame update
    void Start()
    {
        lives = 5;
        lossText.text = "";
        SetLivesText();

        victoryText.text = "";

        replayButton.interactable = false;
        mainmenuButton.interactable = false;
    }

    // Update is called once per frame
    void Update()
    {
        timer.fillAmount -= 1.0f / timeLeft * Time.deltaTime;
        if (timer.fillAmount <= 0)
        {
            victoryText.text = "YOU WIN";
            replayButton.interactable = true;
            mainmenuButton.interactable = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("bomb"))
        {
            Destroy(other.gameObject);
            lives = lives - 1;
            SetLivesText();
        }
    }

    void SetLivesText()
    {
        livesText.text = "LIVES: " + lives.ToString();
        if (lives <= 0)
        {
            lossText.text = "Game Over";
            replayButton.interactable = true;
            mainmenuButton.interactable = true;
        }
    }
}
