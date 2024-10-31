using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{

    public GameObject player;
    public GameObject enemy;
    public GameObject enemy2;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(player, transform.position, Quaternion.identity);
        InvokeRepeating("CreateEnemy", 1f, 3f);
        InvokeRepeating("CreateAnotherEnemy", 2f, 4f);
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
}
