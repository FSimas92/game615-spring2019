using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public void MainMenuSwitcher()
    {
        SceneManager.LoadScene(0);
    }

    public void DirectionsSwitcher()
    {
        SceneManager.LoadScene(1);
    }

    public void LevelSwitcher()
    {
        SceneManager.LoadScene(2);
    }
}
