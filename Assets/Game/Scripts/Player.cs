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
    public GameObject canvasAndroid;

    private float highscore;
    public static float score;
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
                Jump();
        }else 
        {
            GetComponent<Animator>().SetBool("isJumping", false);
        }
    }
    private void FixedUpdate()
    {
        verifyFloor = Physics2D.Raycast(transform.position, Vector2.down, distanceFloor, layerFloor);
    }
    public void Jump()
    {

        if (verifyFloor)
        {
            if (GameController.canMove)
            {
                rb.AddForce(Vector2.up * forceJump);
                GetComponent<Animator>().SetBool("isJumping", true);
                AudioFXManager.Instance.PlayJump();
            }
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
            AudioFXManager.Instance.PlayDeath();
            Time.timeScale = 0.6f;
            GameController.canMove = false;
            GameController.gameRunning = false;
            yourScore.text = "Your Score: " + Mathf.FloorToInt(score); 
            gameOverCanvas.SetActive(true);
            canvasAndroid.SetActive(false);

        }

    }
 }

