using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    public float playerSpeed = 7.0f;
    public int lives = 3;
    private float hInput;
    private float vInput;

    public GameObject Bullet;
    public GameObject Explosion; 
    
    // Start is called before the first frame update
    void Start()
    {
        
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
            Instantiate(Bullet, transform.position, Quaternion.identity);
        }
    }

    public void Death(){
        lives--;
        GameObject.Find("game manager").GetComponent<gameManager>().loselife(lives);
        if(lives == 0){
            Instantiate(Explosion, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D getCoin){
        if(getCoin.tag == "Respawn"){
            //player gets coin
            GameObject.Find("game manager").GetComponent<gameManager>().EarnScore(1);
            Destroy(getCoin.gameObject);
        }
    }
}
