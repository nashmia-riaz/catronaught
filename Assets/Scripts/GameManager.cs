using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
    Text scoreText;

    public bool isGameOver = false;

    [SerializeField]
    float currentHighscore;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        initialPlayerPosition = currentPlayerPosition = player.transform.position;
        currentHighscore = PlayerPrefs.GetFloat("Highscore");
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOver) return;

        if (player.transform.position.x > currentPlayerPosition.x)
        {
            currentPlayerPosition = player.transform.position;
            distanceCovered = currentPlayerPosition - initialPlayerPosition;
            scoreText.text = distanceCovered.x.ToString();
        }

    }

    public void GameOver()
    {
        if (distanceCovered.x > currentHighscore)
        {
            PlayerPrefs.SetFloat("Highscore", distanceCovered.x);
        }
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
}
