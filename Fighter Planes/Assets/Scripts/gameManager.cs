using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class gameManager : MonoBehaviour
{

    public GameObject player;
    public GameObject enemy;
    public GameObject enemy2;
    public GameObject cloud;
    public GameObject Coin;
    public TextMeshProUGUI scoreText; 
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI gameovertext;
    public int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(player, transform.position, Quaternion.identity);
        InvokeRepeating("CreateEnemy", 1f, 3f);
        InvokeRepeating("CreateAnotherEnemy", 2f, 4f);
        InvokeRepeating("CreateCoin", 10f, 10f);
        CreateSky();
        scoreText.text = "Score: " +score;
        livesText.text = "LIVES: 3";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //randomly spawns enemy at top of screen
    void CreateEnemy(){
        Instantiate(enemy, new Vector3(Random.Range(-9f, 9f), 8f, 0), Quaternion.identity);
    }

    void CreateAnotherEnemy(){
        Instantiate(enemy2, new Vector3(Random.Range(-9f, 9f), 8f, 0), Quaternion.identity);
    }

    void CreateCoin(){
        Instantiate(Coin, new Vector3(Random.Range(-9f, 9f), Random.Range(-4f, 0f), 0), Quaternion.identity);
    }

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
            gameovertext.text = "GAME OVER";
        }
    }
}
