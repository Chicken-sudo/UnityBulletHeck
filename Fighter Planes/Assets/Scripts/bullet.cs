using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, 8, 0) * Time.deltaTime);
        if(transform.position.y > 7.55f){
            Destroy(this.gameObject);//bullet destroys itself when leaving screen
        }
    }
}