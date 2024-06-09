using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Controls Player movement and animator parameters
    private float speed = 4f;
    private Rigidbody2D myRigidbody;
    private Vector3 playerMovement;
    [SerializeField] Animator bodyAnimator,outfitAnimator,hairAnimator;

    private void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        playerMovement = Vector3.zero;
        playerMovement.x = Input.GetAxisRaw("Horizontal");
        playerMovement.y = Input.GetAxisRaw("Vertical");
        UpdateAnimationAndMove();
    }
   

    private void UpdateAnimationAndMove()
    {
        if (playerMovement != Vector3.zero)
        {
            MoveCharacter();
            bodyAnimator.SetFloat("moveX", playerMovement.x);
            bodyAnimator.SetFloat("moveY", playerMovement.y);
            bodyAnimator.SetBool("moving", true);
            outfitAnimator.SetFloat("moveX", playerMovement.x);
            outfitAnimator.SetFloat("moveY", playerMovement.y);
            outfitAnimator.SetBool("moving", true);
            hairAnimator.SetFloat("moveX", playerMovement.x);
            hairAnimator.SetFloat("moveY", playerMovement.y);
            hairAnimator.SetBool("moving", true);
            if (!AudioManager.instance.SFXSource.isPlaying)
            {
               
                AudioManager.instance.PlayOneshotSFX(AudioManager.AudioSamples.steps);
            }
        }
        else
        {
          
            bodyAnimator.SetBool("moving", false);
            outfitAnimator.SetBool("moving",false);
            hairAnimator.SetBool("moving", false) ;
            
        }
    }

    private void MoveCharacter()
    {
        myRigidbody.MovePosition(transform.position + playerMovement * speed * Time.deltaTime);
    }
}

