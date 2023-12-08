using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText_UI;
    [SerializeField] private TextMeshProUGUI gameOverText_UI;
    [SerializeField] private Transform camera;
    [SerializeField] private Transform doodler;
    private int yCamera;
    private int yDoodler;
    private int maxScore = 0;
    [SerializeField] private int yPositionDeath;

    void Start()
    {
        gameOverText_UI.gameObject.SetActive(false);
    }

    void LateUpdate()
    {
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

        if (maxScore < yDoodler){
            maxScore = yDoodler;
            scoreText_UI.text = maxScore.ToString();
        }
    }
}
