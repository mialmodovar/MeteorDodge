using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacles : MonoBehaviour
{
    public GameObject obstacle1;
    public GameObject obstacle2;
    public GameObject obstacle3;
    public GameObject bonus;
    public float maxX;
    public float minX;
    public float maxY;
    public float minY;
    public float timeBetweenSpawn;
    private float spawnTime;
    private float bonusSpawnTime;
    
    
    // Update is called once per frame
    void Update()
    {
        
        if(Time.time > spawnTime)
        {
            int numberofmeteors;

		    int value = Random.Range (0, 10);
		    double random = (double) value/10;

		    if (random < 0.5) {
			    numberofmeteors = 1;
		    } else if (random < 0.75) {
			    numberofmeteors = 2;
		    } else {
			    numberofmeteors = 3;
		    }
            for (int i = 0; i < numberofmeteors + 1; i++) 
            {
                SpawnObstacle();
            }
            
            int number1 = Random.Range(0,10);
            if(number1 == 7){
                Spawn();
            }
            spawnTime = Time.time + timeBetweenSpawn;
        }
    }

    void SpawnObstacle()
    {
        GameObject meteor;
		int value = Random.Range (0, 10);
		double random = (double) value/10;
		if (random < 0.5) {
			meteor = obstacle1;
		} else if (random < 0.9) {
			meteor = obstacle2;
		} else {
			meteor = obstacle3;
		    }
        float randomX = Random.Range(minX,maxX);
        float randomY = Random.Range(minY,maxY);

        Instantiate(meteor, transform.position + new Vector3(randomX, randomY,0), transform.rotation);
        
            }

    void Spawn()
    {
        float randomX = Random.Range(-2.57f,13.9f);
        float randomY = Random.Range(14,15);

        Instantiate(bonus, transform.position + new Vector3(randomX, randomY,0), transform.rotation);
            }


}
