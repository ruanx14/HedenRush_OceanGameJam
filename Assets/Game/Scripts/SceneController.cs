
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Game 1");
    }
    public void MenuScreen()
    {
        SceneManager.LoadScene("Menu");
    }
}
