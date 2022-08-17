using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField]
    PlayerScript player;

    [SerializeField]
    StarSpawner starSpawner;

    [SerializeField]
    Vector2 initialPlayerPosition, currentPlayerPosition, distanceCovered = Vector2.zero;

    [SerializeField]
    GameObject scoreText, startText, gameOverText, blackOverlay, yourScoreText, highscoreText;

    public bool isGameOver = false;

    [SerializeField]
    float currentHighscore;

    [SerializeField]
    AudioSource musicSource;

    public bool hasStarted = false;

    public bool isGamePaused = false;

    bool isAudioMuted = false;

    [SerializeField]
    GameObject pauseButton, pauseMenu, unpauseButton, restartButton;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this.gameObject);

        blackOverlay.GetComponent<Animator>().SetTrigger("FadeOut");
    }

    // Start is called before the first frame update
    void Start()
    {
        isAudioMuted = PlayerPrefs.GetInt("Sound", 1) == 0;

        if (!isAudioMuted)
        {
            musicSource.volume = 0.5f;
        }
        else
        {
            musicSource.volume = 0;
        }


        initialPlayerPosition = currentPlayerPosition = player.transform.position;
        currentHighscore = PlayerPrefs.GetFloat("Highscore");
    }

    public void StartGame()
    {
        startText.GetComponent<Animator>().SetTrigger("FadeOut");
        scoreText.GetComponent<Animator>().SetTrigger("FadeIn");
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOver) return;

        if (player.transform.position.x > currentPlayerPosition.x)
        {
            currentPlayerPosition = player.transform.position;
            distanceCovered = currentPlayerPosition - initialPlayerPosition;
            scoreText.GetComponent<Text>().text = distanceCovered.x.ToString();
        }

    }

    public void GameOver()
    {
        restartButton.SetActive(true);

        gameOverText.GetComponent<Animator>().SetTrigger("FadeIn");
        scoreText.GetComponent<Animator>().SetTrigger("FadeOut");

        yourScoreText.GetComponent<Text>().text = "Your score: " + distanceCovered.x;
        highscoreText.GetComponent<Text>().text = "Highscore: " + currentHighscore;

        if (distanceCovered.x > currentHighscore)
        {
            PlayerPrefs.SetFloat("Highscore", distanceCovered.x);
            GPGSManager.instance.PostScore(distanceCovered.x);
        }


    }

    public void Restart()
    {
        SceneManager.LoadScene("Game");
    }

    public void RotateClockwise()
    {
        player.RotateClockwise();
    }

    public void RotateAnticlockwise()
    {
        player.RotateAntiClockwise();
    }

    public void DespawnObject(GameObject obj)
    {
        if (obj.tag == "Stars")
        {
            starSpawner.DespawnObject(obj);
        }
    }

    public void ScrolledOutOfView(GameObject obj)
    {
        if(obj.tag == "Stars")
        {
            starSpawner.SpawnNewObject();
        }
    }

    public void PauseGame()
    {
        isGamePaused = !isGamePaused;
        if (isGamePaused)
        {
            pauseButton.SetActive(false);
            pauseMenu.GetComponent<Animator>().SetTrigger("FadeIn");
            unpauseButton.SetActive(true);

        }
        else
        {
            pauseButton.SetActive(true);
            pauseMenu.GetComponent<Animator>().SetTrigger("FadeOut");
            unpauseButton.SetActive(false);
        }
    }
}
