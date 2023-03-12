using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    public bool gameStarted;

    public GameObject platformSpawner;
    public GameObject GamePlayUI;
    public GameObject MenuUI;

    public AudioSource BgMusic;

    public Text highscoreText;
    public Text scoreText;

    int score = 0;
    int highScore;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        highScore = PlayerPrefs.GetInt("HighScore");

        highscoreText.text = "Best Score : " + highScore;
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameStarted)
        {
            if (Input.GetMouseButtonDown(0))
            {
                GameStart();
            }
        }
    }

    public void GameStart()
    {
        BgMusic.Play();
        gameStarted = true;
        platformSpawner.SetActive(true);
        MenuUI.SetActive(false);
        GamePlayUI.SetActive(true);
        StartCoroutine("UpdateScore");
    }

    public void GameOver()
    {
        platformSpawner.SetActive(false);
        StopCoroutine("UpdateScore");
        SaveHighScore();
        Invoke("ReloadLevel", 1f);
        //DontDestroyOnLoad( BgMusic);
    }

    public void ReloadLevel()
    {
        SceneManager.LoadScene("Game");
    }

    IEnumerator UpdateScore()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);

            score++;

            scoreText.text = score.ToString();
        }
    }

    public void SaveHighScore()
    {
        if (PlayerPrefs.HasKey("HighScore"))
        {
            if(score > PlayerPrefs.GetInt("HighScore"))
            {
                PlayerPrefs.SetInt("HighScore", score);
            }
        }
        else
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
    }
}
