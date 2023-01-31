using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
 
    public void Update()
    {
        
    }
    public void StartGame()
    {
        SceneManager.LoadScene("Game 1");
        //Debug.Log(GameController.language);
    }
    public void MenuScreen()
    {
        SceneManager.LoadScene("Menu");
    }
}
