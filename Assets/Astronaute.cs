using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Astronaute : MonoBehaviour
{
    public static int nbLives;
    public GameObject heart1, heart2, heart3, heart4, heart5, gameOver;

    public static int score;
    public GameObject zero, un, deux, trois, quatre, cinq, six, sept, gameWin;

    public int maxOxygene = 100;
    public int currentOxygene;
    public OxygeneBar oxygeneBar;
    private int nextUpdate=3;

    


   void Start()
    {
        nbLives = 5;
        heart1.gameObject.SetActive(true);
        heart2.gameObject.SetActive(true);
        heart3.gameObject.SetActive(true);
        heart4.gameObject.SetActive(true);
        heart5.gameObject.SetActive(true);
        gameOver.gameObject.SetActive(false);

        currentOxygene = maxOxygene;
        oxygeneBar.SetMaxOxygene(maxOxygene);   

        score = 0;
        zero.gameObject.SetActive(true);
        un.gameObject.SetActive(false);
        deux.gameObject.SetActive(false);
        trois.gameObject.SetActive(false);
        quatre.gameObject.SetActive(false);
        cinq.gameObject.SetActive(false);
        six.gameObject.SetActive(false);
        sept.gameObject.SetActive(false);
        gameWin.gameObject.SetActive(false);
        

    }

    void Update()
    {

        switch(nbLives){
            case 5:
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(true);
                heart3.gameObject.SetActive(true);
                heart4.gameObject.SetActive(true);
                heart5.gameObject.SetActive(true);
                break;
            case 4:
                heart1.gameObject.SetActive(false);
                heart2.gameObject.SetActive(true);
                heart3.gameObject.SetActive(true);
                heart4.gameObject.SetActive(true);
                heart5.gameObject.SetActive(true);
                break;
            case 3:
                heart1.gameObject.SetActive(false);
                heart2.gameObject.SetActive(false);
                heart3.gameObject.SetActive(true);
                heart4.gameObject.SetActive(true);
                heart5.gameObject.SetActive(true);
                break;
            case 2:
                heart1.gameObject.SetActive(false);
                heart2.gameObject.SetActive(false);
                heart3.gameObject.SetActive(false);
                heart4.gameObject.SetActive(true);
                heart5.gameObject.SetActive(true);
                break;
            case 1:
                heart1.gameObject.SetActive(false);
                heart2.gameObject.SetActive(false);
                heart3.gameObject.SetActive(false);
                heart4.gameObject.SetActive(false);
                heart5.gameObject.SetActive(true);
                break;
            case 0:
                heart1.gameObject.SetActive(false);
                heart2.gameObject.SetActive(false);
                heart3.gameObject.SetActive(false);
                heart4.gameObject.SetActive(false);
                heart5.gameObject.SetActive(false);
                break;
            
        }

        switch(score){
            case 1:
                zero.gameObject.SetActive(false);
                un.gameObject.SetActive(true);
                break;
            case 2:
                un.gameObject.SetActive(false);
                deux.gameObject.SetActive(true);
                break;
            case 3:
                deux.gameObject.SetActive(false);
                trois.gameObject.SetActive(true);
                break;
            case 4:
                trois.gameObject.SetActive(false);
                quatre.gameObject.SetActive(true);
                break;
            case 5:
                quatre.gameObject.SetActive(false);
                cinq.gameObject.SetActive(true);
                break;
            case 6:
                cinq.gameObject.SetActive(false);
                six.gameObject.SetActive(true);
                break;
            case 7:
                six.gameObject.SetActive(false);
                sept.gameObject.SetActive(true);
                break;

        }
        
        if(nbLives == 0){
            gameOver.gameObject.SetActive(true);
        }

        if (currentOxygene == 0){
            gameOver.gameObject.SetActive(true);
        }


        if(Time.time>=nextUpdate){
             //Debug.Log(Time.time+">="+nextUpdate);
             nextUpdate=Mathf.FloorToInt(Time.time)+3;
             decreseOxy(5);
         }
  
    }


    private void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.CompareTag("O2")){
            Destroy(other.gameObject);
            increseOxy(100-currentOxygene);
        }
        if(other.gameObject.CompareTag("Monstre")){
            nbLives -= 1;
        }
        if(other.gameObject.CompareTag("Vaisseau")){
            nbLives = 5;
            if(score ==7){
                gameWin.gameObject.SetActive(true);
            }
        }
        if(other.gameObject.CompareTag("Tool")){
            Destroy(other.gameObject);
            score += 1;
        }
    }

    void OnCollisionStay2D(Collision2D col) {
 
        if (col.gameObject.tag == "Monstre"){
            nbLives -= 1;
        }
            
    }


    void decreseOxy(int oxygeneMoins){
        currentOxygene -= oxygeneMoins;
        oxygeneBar.SetOxygene(currentOxygene);
    }

    void increseOxy(int oxygenePlus){
        currentOxygene += oxygenePlus;
        oxygeneBar.SetOxygene(currentOxygene);
    }
}




