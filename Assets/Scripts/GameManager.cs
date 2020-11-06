using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static Vector2 screenDimension;

    public static int playerLife = 3;
    public static bool isRespawning,isGameOver;
    public static int score;
    public static int highScore;
    public GameObject player;

    [Header("UI")]
    public Text scoreText;
    public Text highScoreText;
    public Text GOhighScoreText;
    public GameObject gameOverPanel;

    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        screenDimension = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score:- " + score.ToString();
        highScoreText.text = "High score:-" + highScore.ToString();
        if (score > highScore)
        {
            highScore = score;            
        }
        if (playerLife <= 0)
        {
            Destroy(GameObject.FindGameObjectWithTag("Player"));
            isGameOver = true;
            GOhighScoreText.text = "Your high score is:" + highScore.ToString();
            isRespawning = true;
            gameOverPanel.SetActive(true);
        }

        Debug.Log(isGameOver);
    }

    public void Restart()
    {
        isGameOver = false;
        Instantiate(player);
        playerLife = 3;
        score = 0;
        isRespawning = false;
        GameObject lifes = GameObject.FindGameObjectWithTag("PlayerLifes");
        for (int i = 0; i < lifes.transform.childCount; i++)
        {
            lifes.transform.GetChild(i).gameObject.SetActive(true);
        }
    }

    public void RespawnCoroutine()
    {
        if(playerLife > 0)
            StartCoroutine(RespawnPlayer());
    }

    IEnumerator RespawnPlayer()
    {
        audioSource.Play();
        playerLife--;
        Debug.Log("Remaining life:-" + playerLife);
        GameObject.FindGameObjectWithTag("Life").SetActive(false);
        isRespawning = true;
        yield return new WaitForSeconds(3f);
        Instantiate(player);
        isRespawning = false;
    }

}
