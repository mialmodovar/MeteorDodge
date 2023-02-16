using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : MonoBehaviour
{
    public float fallSpeed = 8.0f;
    public float spinSpeed = 250.0f;

    // Start is called before the first frame update
    void Start()
    {
    
    }

    void Update(){

        transform.Translate(Vector3.down * fallSpeed * Time.deltaTime, Space.World);
        
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Border" || collision.tag == "Beam")
        {
            Destroy(this.gameObject);
        }
        
    }
    
}
