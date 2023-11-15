using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Menu : MonoBehaviour
{
    public void Exit_Button()
    {
        Application.Quit();
        Debug.Log("Game Closed");
    }
    public void Start_Button()
    {
        SceneManager.LoadScene("Introduction");
    }
    public void Next_Button()
    {
        SceneManager.LoadScene("GameScene");
    }
}

