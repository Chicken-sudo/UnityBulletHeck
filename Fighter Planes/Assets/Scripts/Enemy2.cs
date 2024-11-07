using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    public GameObject Explosion;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, -5, 0) * Time.deltaTime);
        if(transform.position.y < -7.55f){
            Destroy(this.gameObject);//enemy destroys itself when leaving screen
        }
    }

    private void OnTriggerEnter2D(Collider2D getHit){
        if(getHit.tag == "Player"){
            //player gets hit
            getHit.GetComponent<Player>().Death();
            Instantiate(Explosion, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
        if(getHit.tag == "Bullet"){
            //enemy gets hit
            GameObject.Find("game manager").GetComponent<gameManager>().EarnScore(10);
            Instantiate(Explosion, transform.position, Quaternion.identity);
            Destroy(getHit.gameObject);
            Destroy(this.gameObject);
        }
    }
}
