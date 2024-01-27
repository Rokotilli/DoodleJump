using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class Controller : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText_UI;
    [SerializeField] private TextMeshProUGUI gameOverText_UI;
    [SerializeField] private Transform camera;
    [SerializeField] private Transform doodler;
    private Rigidbody2D rb2d;
    private float moveInput;
    private float speed = 10f;
    private bool isStarted = false;
    private float topScore = 0.0f;
    public Text scoreText;
    public Text startText;
    private int yCamera;
    private int yDoodler;
    [SerializeField] private int yPositionDeath;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

        rb2d.gravityScale = 0;
        rb2d.velocity = Vector3.zero;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isStarted == false)
        {
            isStarted = true;
            startText.gameObject.SetActive(false);
            rb2d.gravityScale = 5f;
        }

        if (isStarted == true)
        {
            if (moveInput < 0)
            {
                this.GetComponent<SpriteRenderer>().flipX = false;
            }
            else
            {
                this.GetComponent<SpriteRenderer>().flipX = true;
            }

            if (rb2d.velocity.y > 0 && transform.position.y > topScore)
            {
                topScore = transform.position.y;
            }

            yDoodler = (int)doodler.position.y;
            yCamera = (int)camera.position.y;

            if(yDoodler < yCamera - yPositionDeath){
                gameOverText_UI.gameObject.SetActive(true);

                if (Input.GetKeyDown(KeyCode.R)){
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                }
                if (Input.GetKeyDown(KeyCode.Q)){
                    Application.Quit();
                }
            }

            scoreText.text = "Score: " + Mathf.Round(topScore).ToString();
        }
    }

    void FixedUpdate()
    {
        if (isStarted == true)
        {
            moveInput = Input.GetAxis("Horizontal");
            rb2d.velocity = new Vector2(moveInput * speed, rb2d.velocity.y);
        }
    }
}