using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    public float playerSpeed;
    private bool isInvencible = true;
    private Rigidbody2D rb;
    private Vector2 playerDirection;
    public float bonusTime;
    private float spawnTime;
    private ParticleSystem bonuspart;
    public ParticleSystem destroyed;
    
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector2(-1,-5);
        rb = GetComponent<Rigidbody2D>();
        bonuspart = GameObject.Find("bonuspart").GetComponent<ParticleSystem>();
        bonuspart.enableEmission = false;
    }

    // Update is called once per frame
    void Update()
    {
        

        if(isInvencible && Time.time > spawnTime){
                if(Time.time > spawnTime){
            isInvencible = false;
            Debug.Log("BONUS OVER");
            bonuspart.enableEmission = false;
            }
        }
        
        float directionX = Input.GetAxisRaw("Horizontal");
        float directionY = Input.GetAxisRaw("Vertical");
        playerDirection = new Vector2(directionX,directionY).normalized;
    }

    void FixedUpdate(){
        rb.velocity = new Vector2(playerDirection.x  * playerSpeed,playerDirection.y * playerSpeed); 
    }

    
    

    private void OnTriggerEnter2D(Collider2D collision)
    {

        

        if(collision.tag == "Obstacle")
        {
            if(!isInvencible){
                Instantiate(destroyed, transform.position, Quaternion.identity);
                Destroy(this.gameObject);
            }
            else {
                Destroy(collision.gameObject);
            }
        }
        if(collision.tag == "Beam") {
            if(!isInvencible) {
                Instantiate(destroyed, transform.position, Quaternion.identity);
                Destroy(this.gameObject);
            }
        }
        
        if(collision.tag == "Bonus")
        {
            Destroy(collision.gameObject);
            isInvencible = true;
            bonuspart.enableEmission = true;
            bonusTime = NormalDist(8,2);
            Debug.Log(bonusTime);
            spawnTime = Time.time + bonusTime;
        }
    }

    private float NormalDist(float mean, float stDev){
            int value1 = Random.Range (1, 10000);
            int value2 = Random.Range (1, 10000);
            float u1 = (float) value1/10000;  
            float u2 = (float) value2/10000;
            float randStdNormal = Mathf.Sqrt(-2.0f * Mathf.Log(u1)) * Mathf.Sin(2.0f * Mathf.PI * u2); 
            return  mean + stDev * randStdNormal; 
            
    }      

}
    

