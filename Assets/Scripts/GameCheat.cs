using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameCheat : MonoBehaviour
{

    private SceneManager sceneManager;
    void Update()
    {
        // Change scene when player press "1"
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            LoadScene1();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            LoadScene2();
        }
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            LoadScene0();
        }
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            LoadSceneGameOver();
        }
        if (Input.GetKeyDown(KeyCode.F3))
        {
            InfiniteLife();
        }

    }

    public static void LoadScene1()
    {
        SceneManager.LoadScene1();
    }
    
    public static void LoadScene2()
    {
        SceneManager.LoadScene2();
    }

    public static void LoadScene0()
    {
        SceneManager.LoadScene0();
    }

    public static void LoadSceneGameOver()
    {
        SceneManager.LoadSceneGameOver();
    }

    public static void InfiniteLife()
    {
        Debug.Log("Infinite life");
        PlayerController player = GameObject.Find("Player").GetComponent<PlayerController>();
        player.IncreaseMaxHealth(9999);
        player.IncreaseHealth(9999);
    }

}
