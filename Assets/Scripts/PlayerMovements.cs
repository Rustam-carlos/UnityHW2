using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovements : MonoBehaviour
{
    [SerializeField]
    public Rigidbody rb;
    public float speed;
    public float sideForse = 500;
    [SerializeField]
    private int HighSpeedDelaySeconds;
    [SerializeField]
    private int HighSpeedSeconds;
    
    [SerializeField]
    private float HighSpeed;
    private float saveSpeed;
    private float delSeconds;
    private bool HighSpeedTime;
    private int coins = 0;
    
    void Start()
    {
        Debug.Log("speed = " + speed);
        rb.AddForce(0, 0, 500);
        saveSpeed = speed;
        HighSpeedTime = false;
        delSeconds = 0;
    }    
    void FixedUpdate()
    {
        if (HighSpeedTime == true)
        {
            delSeconds = delSeconds - Time.deltaTime;  // отнимаем время
            if (delSeconds < 0)  // время ускорения вышло
            {
                speed = saveSpeed;
                HighSpeedTime = false;
                delSeconds = 0;
            }

        }
        
        rb.AddForce(0, 0, speed * Time.deltaTime);
        if (Input.GetKey("d"))
        {
            rb.AddForce(sideForse * Time.deltaTime,0,0);
        }
        if (Input.GetKey("a"))
        {
            rb.AddForce(-sideForse * Time.deltaTime,0,0);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Coin")
        {
            coins++;
            Debug.Log("Coins sum = " + coins);
            Destroy(other.gameObject);
        }
        if(other.tag == "HighSpeedGround")
        {
            saveSpeed = speed;
            speed = HighSpeed;
            rb.AddForce(0, 50, 1500);
            HighSpeedTime = true;  // включено ускорение на время из-за столкновения с Accelerator
            //rb.velocity = new Vector2(Input.GetAxis("Horizontal"), rb.velocity.y);
            //rb.AddForce(transform.forward * 5f);
            delSeconds = HighSpeedDelaySeconds;
            Destroy(other.gameObject);
            Debug.Log("speed = " + speed);
        } 
        
    }
    
}
