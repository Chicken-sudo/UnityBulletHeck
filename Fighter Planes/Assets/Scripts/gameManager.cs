using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class gameManager : MonoBehaviour
{

    public GameObject player;
    public GameObject enemy;
    public GameObject enemy2;
    public GameObject cloud;
    public GameObject Coin;
    public GameObject Powerup;

    public AudioClip powerget;
    public AudioClip powerlost;

    private bool isPlayerAlive;

    public TextMeshProUGUI scoreText; 
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI gameovertext;
    public TextMeshProUGUI restarttext;
    public TextMeshProUGUI powerUptext;
    public int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        isPlayerAlive = true;
        Instantiate(player, transform.position, Quaternion.identity);
        InvokeRepeating("CreateEnemy", 1f, 3f);
        InvokeRepeating("CreateAnotherEnemy", 2f, 4f);
        InvokeRepeating("CreateCoin", 8f, 8f);
        InvokeRepeating("CreatePowerup", 10f, 10f);
        CreateSky();
        scoreText.text = "Score: " +score;
        livesText.text = "LIVES: 3";
    }

    // Update is called once per frame
    void Update()
    {
        Restart();
    }

    //randomly spawns enemy at top of screen
    void CreateEnemy(){
        Instantiate(enemy, new Vector3(Random.Range(-9f, 9f), 8f, 0), Quaternion.identity);
    }

    void CreateAnotherEnemy(){
        Instantiate(enemy2, new Vector3(Random.Range(-9f, 9f), 8f, 0), Quaternion.identity);
    }

    //randomly spawns collectable in player zone
    void CreateCoin(){
        Instantiate(Coin, new Vector3(Random.Range(-9f, 9f), Random.Range(-4f, 0f), 0), Quaternion.identity);
    }

    void CreatePowerup(){
        Instantiate(Powerup, new Vector3(Random.Range(-9f, 9f), Random.Range(-4f, 0f), 0), Quaternion.identity);
    }

    //creates background
    void CreateSky(){
        for(int i=0; i<20; i++){
            Instantiate(cloud, transform.position, Quaternion.identity);
        }
    }

    public void EarnScore(int NewScore){
        score += NewScore;
        scoreText.text = "Score: " +score;
    }

    public void loselife(int lives){
        livesText.text = "LIVES: " + lives;
        if(lives == 0){
            gameOver();
        }
    }

    public void gameOver(){
        //ends the game
        isPlayerAlive = false;
        gameovertext.gameObject.SetActive(true);
        restarttext.gameObject.SetActive(true);
        CancelInvoke();
    }

    void Restart(){
        if(Input.GetKeyDown(KeyCode.R) && isPlayerAlive == false){
            //restarts the game
            SceneManager.LoadScene("Game");
        }
    }

    public void UpdatePowerUpText(string whichPower){
        powerUptext.text = whichPower;
    }

    public void PlayPowerUp(){
        AudioSource.PlayClipAtPoint(powerget, Camera.main.transform.position);
    }

    public void PlayPowerDown(){
        AudioSource.PlayClipAtPoint(powerlost, Camera.main.transform.position);
    }
}
