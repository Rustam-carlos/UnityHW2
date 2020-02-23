using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCollision : MonoBehaviour
{
    public int coins = 0;
    public PlayerMovements movement;
    public GameManager gm;
    
    //PlayerMovements playerMovements;
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Coin")
        {
            coins++;
            Debug.Log("Coins sum = " + coins);
            Destroy(other.gameObject);
        }
        // if(other.tag == "HighSpeedGround")
        // {
        //     //movement.speed = 30000;
        //     //movement.rb.velocity = new Vector2(Input.GetAxis("Horizontal") *20, movement.rb.velocity.y);
        //     movement.rb.AddForce(transform.forward * 50f);
        //     //gm.EndGame();
        //     Destroy(other.gameObject);
        //     //movement.speed = 30000;
        // } 
        
    }

    

    void Start() 
    {
        gm = FindObjectOfType<GameManager>();
    }
    void Update() 
    {        
        if(transform.position.y < -2)
        {
            gm.EndGame();
        }
    }
    // void OnTriggerHighSpeed(Collider other) 
    // {        
        
    // }

    void OnCollisionEnter(Collision other) 
    {
        if(other.collider.tag == "Obstacle")   
        {
            gm.EndGame();
            movement.enabled = false;
        }       
        if(other.collider.tag == "Finish")   
        {
            gm.WinGame();
            movement.enabled = false;
        }
    }

    
    
    
}
