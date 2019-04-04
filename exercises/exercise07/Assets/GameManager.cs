using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    private Animator cube1anim;
    private Animator cube2anim;

    public GameObject cube1;
    public GameObject cube2;

    public GameObject speedsterPanel;
    public GameObject cube2Panel;
    public TMP_Text speedsterText;
    public TMP_Text cube2Text;

    // Start is called before the first frame update
    void Start()
    {
        cube1anim = cube1.GetComponent<Animator>();
        cube2anim = cube2.GetComponent<Animator>();

        cube1anim.SetBool("ReadyToGo", false);
        cube2anim.SetBool("ReadyToGo", false);
    }

    // Update is called once per frame
    void Update()
    {
        if (cube2Panel.activeSelf)
        {
            Vector3 cube2PanelPos = Camera.main.WorldToScreenPoint(cube2.transform.position + Vector3.up * 2f);
            cube2Panel.transform.position = cube2PanelPos;
        }

        if (speedsterPanel.activeSelf)
        {
            Vector3 cube1PanelPos = Camera.main.WorldToScreenPoint(cube1.transform.position + Vector3.up * 2f);
            speedsterPanel.transform.position = cube1PanelPos;
        }

        if (SpeedingScript.doneSpeeding == true)
        {
            SpeedingScript.doneSpeeding = false;
            StartCoroutine(TalkingScene());
        }
    }

    IEnumerator TalkingScene()
    {
        while (true)
        {

            cube2Text.text = "Whoa there! Watch it!";
            cube2Panel.SetActive(true);

            yield return new WaitForSeconds(1.5f);

            speedsterText.text = "Sorry";
            speedsterPanel.SetActive(true);
            cube2Panel.SetActive(false);

            yield return new WaitForSeconds(1.5f);

            cube2Text.text = "That was reckless.";
            cube2Panel.SetActive(true);
            speedsterPanel.SetActive(false);

            yield return new WaitForSeconds(1);

            speedsterText.text = "I know.";
            speedsterPanel.SetActive(true);
            cube2Panel.SetActive(false);

            yield return new WaitForSeconds(1);

            speedsterPanel.SetActive(false);

            yield return new WaitForSeconds(1);

            speedsterText.text = "My bad.";
            speedsterPanel.SetActive(true);

            yield return new WaitForSeconds(1.5f);

            speedsterPanel.SetActive(false);

            yield return new WaitForSeconds(2);

            speedsterText.text = "Wanna join me?";
            speedsterPanel.SetActive(true);

            yield return new WaitForSeconds(1);

            cube2Text.text = "Hell yeah.";
            cube2Panel.SetActive(true);
            speedsterPanel.SetActive(false);

            yield return new WaitForSeconds(1);

            cube2Panel.SetActive(false);
            cube1anim.SetBool("ReadyToGo", true);
            cube2anim.SetBool("ReadyToGo", true);

            yield return null;
        }
    }
}
