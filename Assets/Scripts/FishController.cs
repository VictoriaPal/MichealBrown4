using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FishController : MonoBehaviour
{
    Animator fishAnimator;
    public float fishKnockback; //default 200
    public float fishJumpback; //default 75
    
    public AudioClip []slapSounds;

    int wetnessFactor = 10;
    public int randomSlipFactor = 0;
    public int slipNumber;

    Vector3 lastParentDirection;

    private void Awake()
    {
      
    }

    void Start()
    { 
        fishAnimator = gameObject.GetComponent<Animator>();
        fishAnimator.SetBool("IsAttacking", false);

        
    }

    void Update()
    {
        KeyCode fishAttack = GetComponentInParent<PlayerController>().GetAttackKey();

        if (Input.GetKeyDown(fishAttack))
        {
            fishAnimator.SetBool("IsAttacking", true);
            
        }
        else
        {
            fishAnimator.SetBool("IsAttacking", false);
        }

        lastParentDirection = GetComponentInParent<PlayerController>().GetDirection();

    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        KeyCode fishAttack = GetComponentInParent<PlayerController>().GetAttackKey();


        if (Input.GetKeyDown(fishAttack))
        {

            if (collider.gameObject.tag == "Player")
            {
                collider.GetComponent<Rigidbody2D>().AddForce(GetComponentInParent<PlayerController>().GetDirection() * fishKnockback, ForceMode2D.Impulse);
                collider.GetComponent<Rigidbody2D>().AddForce(collider.transform.up * fishJumpback, ForceMode2D.Impulse);
                int slapIndex = Random.Range(0, slapSounds.Length);
                AudioSource.PlayClipAtPoint(slapSounds[slapIndex], transform.position);

                Slider enemyWetnessMeter = collider.GetComponent<PlayerController>().GetWetnessMeter();
                enemyWetnessMeter.value += wetnessFactor;
                Debug.Log("ouch!");

                slipNumber = Random.Range(1, randomSlipFactor);

                return;
                
            }


            randomSlipFactor++;

            if (randomSlipFactor > 5)
            {
                //the more times your fishsuccessful doens't slip, the more likely it is to slip out the next time
                slipNumber = (Random.Range(1, randomSlipFactor));

                if (slipNumber > 5)
                {
                  
                    //Rigidbody2D tempRigidbody = gameObject.AddComponent<Rigidbody2D>();
                    //tempRigidbody.simulated = true;
                    //tempRigidbody.mass = 150;
                    //tempRigidbody.AddForce(lastParentDirection * fishKnockback, ForceMode2D.Impulse);
                    slipNumber = 0;
                }
            }

        }

       
    }
    
}
