using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    public Text scoret;
    private float score;
    
    

    // Update is called once per frame
    void Update()
    {
        if(GameObject.FindGameObjectWithTag("Player") != null){

            score += 1* Time.deltaTime;
            scoreText.text = ((int)score).ToString();
            scoret.text = "Score: " + ((int)score).ToString();
        } 
        else {
            scoreText.text = "";
        }
    }

       public void Restart(){
        Debug.Log("kachow");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
