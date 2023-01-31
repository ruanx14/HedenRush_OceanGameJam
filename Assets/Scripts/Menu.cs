using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Unity.VisualScripting.Icons;

public class Menu : MonoBehaviour
{
    //public Dropdown m_Dropdown;
    public void Awake()
    {
        GameController.language = "English";
    }
    public void ChangeLanguage(int language)
    {
        if(language == 0)
        {
            GameController.language = "English";
        }
        if (language == 1)
        {
            GameController.language = "Portugues";
        }


    }
}
