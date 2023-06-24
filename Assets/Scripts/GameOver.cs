using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    GameObject gameManager;
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
    }

    public void BackToMenu()
    {
        Time.timeScale = 1;
        gameManager.GetComponent<SceneManager>().LoadScene0();
    }
}
