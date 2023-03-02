using UnityEngine;
using UnityEngine.UI;

// handles the GameManager User interface
public class GameManager : MonoBehaviour
{
    // variables for User interface text and images
    public Player player;
    public Text scoreText;
    public GameObject playButton;
    public GameObject gameOver;
    private int score;

    // Awake function that keeps the games Frames per second at 60fps
    private void Awake()
    {
        Application.targetFrameRate = 60;

        Pause();
    }

    //play button
    public void Play()
    {   
        // intializes games score to 0
        score = 0;
        // casts score text from int to string
        scoreText.text = score.ToString();

        // play button and game over text are set to false to not show up during gameplay
        playButton.SetActive(false);
        gameOver.SetActive(false);

        // The timescale starts the game and player enabled checks to see if player has started game
        Time.timeScale = 1f;
        player.enabled = true;

        // Array that creates random green pipes
        Pipes[] pipes = FindObjectsOfType<Pipes>();

        for(int i = 0; i <pipes.Length; i++){
            Destroy(pipes[i].gameObject);
        }
    }

    // stops game and animations 
    public void Pause()
    {
        Time.timeScale = 0f;
        player.enabled = false;
    }

    // when gameover function is called it brings up game over text and play button
    public void GameOver()
    {
        gameOver.SetActive(true);
        playButton.SetActive(true);

        Pause();
    }

    // Increase score function increments score text and casts scoreText int to string
    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
    }
}
