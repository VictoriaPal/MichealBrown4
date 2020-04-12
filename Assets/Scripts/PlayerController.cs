using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public float force; //175
    public float runSpeed = 1; //400
    Vector3 runSpeedVector = Vector3.right;
    Vector3 jumpForce = Vector3.up;
    //mass of 5
    //linear drag 5
    //gravity scale 10

    Vector3 playerDirectionStorage;
    Rigidbody2D playerRigidbody;
    
    public KeyCode jump;
    public KeyCode right;
    public KeyCode left;
    public KeyCode attack;
    public KeyCode throwAndPickUp;
    public KeyCode shake;

    bool isOnGround = true;
    

    public Slider wetnessMeter;
    public int shakeFactor = 1;
    public ParticleSystem waterDrops;

    

    


    void Awake()
    {
        playerRigidbody = gameObject.GetComponent<Rigidbody2D>();
        waterDrops = gameObject.GetComponentInChildren<ParticleSystem>();

    }

    void Update()
    {
        waterDrops.transform.position = playerRigidbody.position;
        
        //GetComponent<CamController>().GetMaxCamSize();
        if (Input.GetKeyDown(jump) && isOnGround == true)
        {

            playerRigidbody.AddForce(jumpForce * force, ForceMode2D.Impulse);
            isOnGround = false;
            
        }
        


        if (Input.GetKey(right))
        {
            playerRigidbody.AddForce(runSpeed * runSpeedVector, ForceMode2D.Force);
            playerDirectionStorage = runSpeedVector;
            transform.localScale = new Vector3(.75f, .75f, 1);
            
        }

        if (Input.GetKey(left))
        {

            playerRigidbody.AddForce(-runSpeed * runSpeedVector, ForceMode2D.Force);
            playerDirectionStorage = -runSpeedVector;
            transform.localScale = new Vector3(-.75f, .75f, 1);
        }

        if (Input.GetKeyDown(throwAndPickUp))
        {

        }

        //particle systems are bitches and fuck unity
        if (Input.GetKeyDown(shake))
        {
            if (wetnessMeter.value != 0)
            {
                waterDrops.Play();
            }
            

        }

        if (Input.GetKey(shake))
        {
            //cannot shake when moving/jumping
            if (playerRigidbody.velocity.magnitude < 0.1f || playerRigidbody.IsSleeping())
            {
                wetnessMeter.value -= shakeFactor;
                
            }
            if (wetnessMeter.value == 0)
            {
                waterDrops.Stop();
            }
        }

        else
        {
            waterDrops.Stop();
        }


    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //check to see if player on ground or not so player can't double jump
        if (collision.gameObject.tag == "ground")
        {
            isOnGround = true;

        }
       
        

        
    }
    public Vector3 GetDirection()
    {
        return playerDirectionStorage;
    }

    public KeyCode GetAttackKey()
    {
        return attack;
    }

    public Slider GetWetnessMeter()
    {
        return wetnessMeter;
    }

   

}
