using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class Player : MonoBehaviour
{
    //Jump
    [Header("Jump Settings")]
    private Rigidbody2D rb;
    [SerializeField]
    private float forceJump;
    [SerializeField]
    private float distanceFloor;
    [SerializeField]
    private LayerMask layerFloor;
    [SerializeField]
    private bool verifyFloor;
    private Animator playerAnimator;
    public GameObject gameOverCanvas;

    private float highscore;
    public float score;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highscoreText;

    public TextMeshProUGUI yourScore;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        highscore = PlayerPrefs.GetFloat("highscore", highscore);
        highscoreText.text = $"Highscore: {Mathf.FloorToInt(PlayerPrefs.GetFloat("highscore"))}";
    }
    void Update()
    {
        if(GameController.gameRunning)
        {
            score += Time.deltaTime * 10;
            scoreText.text = "Score: " + Mathf.FloorToInt(score).ToString();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (GameController.canMove) { 
                Jump();
            }
        }else 
        {
            GetComponent<Animator>().SetBool("isJumping", false);
        }
    }
    private void FixedUpdate()
    {
        verifyFloor = Physics2D.Raycast(transform.position, Vector2.down, distanceFloor, layerFloor);
    }
    private void Jump()
    {
        if (verifyFloor)
        {
            rb.AddForce(Vector2.up * forceJump);
            GetComponent<Animator>().SetBool("isJumping", true);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            
            if (score > highscore)
            {
                highscore = score;
                PlayerPrefs.SetFloat("highscore", highscore);
            }
            //endGameAudioSource.Play();


            playerAnimator.SetBool("isDead", true);
            Time.timeScale = 0.6f;
            GameController.canMove = false;
            GameController.gameRunning = false;
            yourScore.text = "Your Score: " + score; 

            gameOverCanvas.SetActive(true);
        }

    }
 }

