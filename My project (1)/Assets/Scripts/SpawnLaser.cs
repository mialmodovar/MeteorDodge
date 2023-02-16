using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLaser : MonoBehaviour
{
    public GameObject destroyer;
    public GameObject beam;
    private GameObject player;
    public float maxX;
    public float minX;
    public float maxY;
    public float minY;
    private float timeBetweenCheck = 2f; //2
    private float duration;
    private float checkTime;
    private float destroyTime;
    private float preactionDuration = 1;
    private float preactiontime;
    private bool activated;
    private GameObject current;
    private GameObject current1;
    private bool isLoading;
    private Vector3 point;
    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        checkTime = Time.time + timeBetweenCheck;
        isLoading = false;
    
    
    }   

    // Update is called once per frame
    void Update()
    {
    
        

        if(activated){

            if(Time.time > preactiontime && isLoading){ //1.3
                isLoading = false;
                current1 = Instantiate(beam, new Vector3(1f, point.y - 1.3f,0), transform.rotation);

            }

            if(Time.time > destroyTime){
                Destroy(current, 1.0f);
                Destroy(current1, 1.0f);
                activated = false;
            }

        } else {
        if(Time.time > checkTime)
        {
            int number1 = Random.Range(0,5);
            if(number1 == 3){
                activated = true;
                int value = Random.Range (1, 100000);
		        double rand = (double) value/100000;
                duration = -4 * Mathf.Log ((float)rand);
                if(duration <= 3 ||  duration >= 6)
                 //Alguns valores gerados pela distribuição não são usáveis no contexto de jogo. Para esses, manipulamos para que tenham um valor aleatório entre 3 e 7.
                 duration = Random.Range(3,7);
                Debug.Log("laser = " + duration);
                destroyTime = Time.time + duration;
                SpawnDestroyer();
            }
            checkTime = Time.time + timeBetweenCheck;
            }
        }
  
    }

    void SpawnDestroyer()
    {
        preactiontime = Time.time + preactionDuration;
        float randomX = Random.Range(minX,maxX);
        float randomY = Random.Range(minY,maxY);
        isLoading = true;
        point = player.transform.position;
        current = Instantiate(destroyer, new Vector3(-10.57f, point.y,0), transform.rotation);
        

            }

   


}
