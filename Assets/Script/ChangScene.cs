using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangScene : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void RealPlay()
    {
        SceneManager.LoadScene("GameScenes");
    }

    public void Credit()
    {
        SceneManager.LoadScene("Credit");
    }

    public void back()
    {
        SceneManager.LoadScene("Menu");
    }

    public void endd()
    {
        SceneManager.LoadScene("Endd");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
