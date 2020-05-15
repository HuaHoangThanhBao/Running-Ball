using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreHandle : MonoBehaviour {

    Text title;
    Text scoreInGame_txt;
    Text highScore_txt;
    Image crown_Img;
    Button replay_But;

    GameObject bar;
    GameObject userGuide;

    Player player;
    PlayerProgress playerProgress;

    private void Awake()
    {
        player = FindObjectOfType<Player>();
        title = GameObject.Find("Title").GetComponent<Text>();
        scoreInGame_txt = GameObject.Find("Score In Game").GetComponent<Text>();
        highScore_txt = GameObject.Find("High Score").GetComponent<Text>();
        crown_Img = GameObject.Find("Crown").GetComponent<Image>();
        replay_But = GameObject.Find("Replay").GetComponent<Button>();
        bar = GameObject.FindGameObjectWithTag("Bar");
        userGuide = GameObject.FindGameObjectWithTag("UserGuide");
    }

    private void Start()
    {
        LoadHighScore();
        CanvasActiveHandleWhenStart();
        ScoreWhenStartGame();
    }

    private void Update()
    {
        ScoreHandler();
        CanvasActiveHandleWhenUpdate();
    }

    void CanvasActiveHandleWhenStart()
    {
        title.GetComponent<Text>().enabled = true;
        crown_Img.GetComponent<Image>().enabled = true;
        scoreInGame_txt.GetComponent<Text>().enabled = false;
        highScore_txt.GetComponent<Text>().enabled = true;
        replay_But.GetComponent<Image>().enabled = false;
        replay_But.GetComponent<Button>().enabled = false;
        bar.SetActive(true);
        userGuide.SetActive(true);
    }

    void CanvasActiveHandleWhenUpdate()
    {
        if(player.variables.gameBegin)
        {
            title.GetComponent<Text>().enabled = false;
            crown_Img.GetComponent<Image>().enabled = false;
            scoreInGame_txt.GetComponent<Text>().enabled = true;
            highScore_txt.GetComponent<Text>().enabled = false;
            bar.SetActive(false);
            userGuide.SetActive(false);
        }
        
        if(player.variables.endGame)
        {
            title.GetComponent<Text>().enabled = false;
            crown_Img.GetComponent<Image>().enabled = true;
            scoreInGame_txt.GetComponent<Text>().enabled = true;
            highScore_txt.GetComponent<Text>().enabled = true;
            replay_But.GetComponent<Image>().enabled = true;
            replay_But.GetComponent<Button>().enabled = true;
        }
    }

    void ScoreHandler()
    {
        ScoreInGame();

        if (player.variables.endGame)
        {
            SubmitHighScore(player.variables.scoreInGame);

            highScore_txt.text = "" + getHighScore().ToString();
        }
    }

    void ScoreWhenStartGame()
    {
        highScore_txt.text = "" + getHighScore().ToString();
    }

    int getHighScore()
    {
        return playerProgress.highScore;
    }

    void LoadHighScore()
    {
        playerProgress = new PlayerProgress();
        if(PlayerPrefs.HasKey("highScore"))
        {
            playerProgress.highScore = PlayerPrefs.GetInt("highScore");
        }
    }

    void SubmitHighScore(int newScore)
    {
        if(playerProgress.highScore < newScore)
        {
            playerProgress.highScore = newScore;
            PlayerPrefs.SetInt("highScore", newScore);
        }
    }

    void ScoreInGame()
    {
        scoreInGame_txt.text = "" + player.variables.scoreInGame.ToString();
    }

    public int IncreaseScore()
    {
        return player.variables.scoreInGame++;
    }

    public void LoadScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("RunningBall");
    }
}
