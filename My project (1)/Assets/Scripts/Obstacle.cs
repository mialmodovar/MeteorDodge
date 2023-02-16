using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private float fallSpeed;
    public float spinSpeed = 250.0f;
    private GameObject player;
    SpawnObstacles spawn;
    // Start is called before the first frame update
    void Start()
    {
        
        int value = Random.Range (1, 100000);
		double rand = (double) value/100000;
        fallSpeed =  (7+2) * Mathf.Sqrt(-Mathf.Log((float) rand));
        if(fallSpeed < 8f ||  fallSpeed >=14f){
            //Alguns valores gerados pela distribuição não são usáveis no contexto de jogo. Para esses, manipulamos para que tenham um valor aleatório entre 8 e 14.
            fallSpeed = Random.Range(8,15);
        }
    //fallSpeed =  (9+1) * Mathf.Sqrt(-Mathf.Log((float) rand));
      //  if(fallSpeed > 14){
       //     fallSpeed = 14;
      
        Debug.Log(fallSpeed);
    }

    void Update(){

        transform.Translate(Vector3.down * fallSpeed * Time.deltaTime, Space.World);
        transform.Rotate(Vector3.forward, spinSpeed * Time.deltaTime);
    }


    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Border" || collision.tag == "Beam" )
        {
            Destroy(this.gameObject);
        }
        
        
    }

    public void setSpeed(int speed)
    {
        fallSpeed = speed;

        
    }
    
}
