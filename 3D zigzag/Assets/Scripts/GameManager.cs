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

    public Text scoreText;

    int score = 0;

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
        gameStarted = true;
        platformSpawner.SetActive(true);
        GamePlayUI.SetActive(true);
        StartCoroutine(UpdateScore());
    }

    public void GameOver()
    {
        platformSpawner.SetActive(false);

        Invoke("ReloadLevel", 1f);
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
}
