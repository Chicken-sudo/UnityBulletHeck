using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
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
}
