using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialog : MonoBehaviour
{
    [Header("Lines")]
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed = 0.07f;
    private int indexLines;

    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject scenarioSpawn;

    void Start()
    {
        textComponent.text = string.Empty;
        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(textComponent.text == lines[indexLines])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[indexLines];
            }
        }
    }
    void StartDialogue()
    {
        indexLines = 0;
        StartCoroutine(writeLine());
    }
    IEnumerator writeLine()
    {
        foreach(char letter in lines[indexLines])
        {
            textComponent.text += letter;
            yield return new WaitForSeconds(textSpeed);
        }
        yield return null;
    }
    void NextLine()
    {
        if(indexLines < lines.Length -1)
        {
            indexLines++;
            textComponent.text = string.Empty;
            StartCoroutine(writeLine());
        }
        else
        {
            gameObject.SetActive(false);

            /*
            player.GetComponent<Animator>().SetBool("isRunning", true);
            GameController.gameRunning= true;
            scenarioSpawn.SetActive(true);*/
        }
    }
}
