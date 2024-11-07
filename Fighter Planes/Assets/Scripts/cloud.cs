using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cloud : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(Random.Range(-12f, 12f), Random.Range(-8f, 8f), 0);
        float temp = Random.Range(0.1f, 1f);
        transform.localScale = new Vector3(temp, temp, temp);
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, Random.Range(0.1f, 0.9f));
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, -1, 0) * Time.deltaTime * Random.Range(1f, 3f));
        if(transform.position.y <= -7.55f){
            transform.position = new Vector3(Random.Range(-11.5f, 11.5f), 8.25f, 0);
        }
    }
}
