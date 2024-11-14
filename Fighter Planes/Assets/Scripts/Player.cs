using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float playerSpeed = 7.0f;
    public int lives = 3;
    private float hInput;
    private float vInput;
    private int shoot = 1;
    private bool hasShield = false;

    private gameManager gameManager;

    public GameObject Bullet;
    public GameObject Explosion;
    public GameObject thruster;
    public GameObject shield;
    
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("game manager").GetComponent<gameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Shooting();
    }

    void Movement(){
        hInput = Input.GetAxis("Horizontal");
        vInput = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(hInput,vInput,0) * Time.deltaTime * playerSpeed);
        //if player leaves screen then they loop around
        if (transform.position.x > 11.3f || transform.position.x <= -11.3f){
            transform.position = new Vector3(transform.position.x * -1, transform.position.y, 0);
        }

        if (transform.position.y > 0f){
            transform.position = new Vector3(transform.position.x, 0, 0);
        }else if(transform.position.y <= -4f){
            transform.position = new Vector3(transform.position.x, -4, 0);
        }
    }

    void Shooting(){
        //press SPACE to create bullets
        if(Input.GetKeyDown(KeyCode.Space)){
            switch(shoot){
                case 1:
                    Instantiate(Bullet, transform.position + new Vector3(0, 0.3f, 0), Quaternion.identity);
                    break;
                case 2:
                    Instantiate(Bullet, transform.position + new Vector3(0.5f, 0.3f, 0), Quaternion.identity);
                    Instantiate(Bullet, transform.position + new Vector3(-0.5f, 0.3f, 0), Quaternion.identity);
                    break;
                case 3:
                    Instantiate(Bullet, transform.position + new Vector3(0, 0.3f, 0), Quaternion.identity);
                    Instantiate(Bullet, transform.position + new Vector3(0.5f, 0.3f, 0), Quaternion.Euler(0, 0, -30f));
                    Instantiate(Bullet, transform.position + new Vector3(-0.5f, 0.3f, 0), Quaternion.Euler(0, 0, 30f));
                    break;
            }
        }
    }

    public void Death(){
        //player loses a life and gets a game over if lives=0
        if(hasShield == false){
            lives--;
        gameManager.loselife(lives);
        if(lives == 0){
            Instantiate(Explosion, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
        }else if (hasShield == true){
            hasShield = false;
            gameManager.PlayPowerDown();
            shield.gameObject.SetActive(false);
        }  
    }

    IEnumerator SpeedDown(){
        yield return new WaitForSeconds(3f);
        playerSpeed = 7.0f;
        gameManager.UpdatePowerUpText("");
        gameManager.PlayPowerDown();
        thruster.gameObject.SetActive(false);
    }

    IEnumerator ShootDown(){
        yield return new WaitForSeconds(3f);
        shoot = 1;
        gameManager.UpdatePowerUpText("");
        gameManager.PlayPowerDown();
    }

    IEnumerator SheildText(){
        yield return new WaitForSeconds(3f);
        gameManager.UpdatePowerUpText("");
    }

    private void OnTriggerEnter2D(Collider2D getCoin){
        if(getCoin.tag == "Respawn"){
            //player gets coin
            gameManager.EarnScore(1);
            Destroy(getCoin.gameObject);
        } else if(getCoin.tag == "Item"){
            //player gets powerup
            gameManager.PlayPowerUp();
            Destroy(getCoin.gameObject);
            int power = Random.Range(1, 5);
            switch(power){
                case 1:
                    //speed
                    playerSpeed = 10f;
                    gameManager.UpdatePowerUpText("GOT SPEED");
                    thruster.gameObject.SetActive(true);
                    StartCoroutine(SpeedDown());
                    break;
                case 2:
                    //double shot
                    shoot = 2;
                    gameManager.UpdatePowerUpText("GOT DOUBLE");
                    StartCoroutine(ShootDown());
                    break;
                case 3:
                    //triple shot
                    shoot = 3;
                    gameManager.UpdatePowerUpText("GOT TRIPLE");
                    StartCoroutine(ShootDown());
                    break;
                case 4:
                    //shield
                    gameManager.UpdatePowerUpText("GOT SHIELD");
                    hasShield = true;
                    StartCoroutine(SheildText());
                    shield.gameObject.SetActive(true);
                    break;
            }
        }
    }
}
