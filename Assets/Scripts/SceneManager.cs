using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public static void LoadScene1()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Fase1");
    }
    
    public static void LoadScene2()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Fase2");
    }

    public static void LoadScene0()
    {
        Time.timeScale = 1;
        UnityEngine.SceneManagement.SceneManager.LoadScene("MenuInicial");
    }

    public static void LoadSceneGameOver()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameOver");
    }

    public static void QuitGame()
    {
        Application.Quit();
    }
}
