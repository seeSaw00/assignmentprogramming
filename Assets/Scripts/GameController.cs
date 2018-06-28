using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
    public GameObject[] hazards;
    // sets a public GameObject array to hold the hazard types
    // declares a variable array for holding the hazards
    public Vector3 spawnValues; // declares a public variable
    public int hazardCount; // used in the loop 
    public float spawnWait;
    public float startWait;
    public float waveWait;

    public GUIText scoreText;
    public GUIText restartText;
    public GUIText gameOverText;

    private bool gameOver;
    private bool restart;
    private int score;

    void Start()
    {
        gameOver = false; // since the game has just started so gameOver is false
        restart = false; 
        restartText.text = ""; // the restart and gameOver gui texts are empty upon start
        gameOverText.text = "";
        score = 0; // score is initialised at zero 




        UpdateScore();
        StartCoroutine(SpawnWaves()); //spawns each wave of enemies

    }

    void Update()
    {
        //checks whether the game is over and restart is true
        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.R))
            { 
               UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
            }// if the restart condition is met and the r key is pressed, then reloads scene 
        }
    }


    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            //keeps looping spawn through radom x values while less than hazard count
            for (int i = 0; i < hazardCount; i++)
            {
                GameObject hazard = hazards[Random.Range(0, hazards.Length)];
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);

            if (gameOver)
            {
                restartText.text = "Press 'R' for Restart";
                restart = true;
                break;
            }
        }
    }

    public void AddScore(int newScoreValue)//adds to the score value
    {
        score += newScoreValue;
        UpdateScore();
    }

    void UpdateScore() //changes the score gui text
    {
        scoreText.text = "Score: " + score;
    }
    public void GameOver() //a public function which is called by other scripts
    {
        gameOverText.text = "Game Over";
        gameOver = true;
        //sets the text to Game Over and gameOver boolean to true
    }
}
