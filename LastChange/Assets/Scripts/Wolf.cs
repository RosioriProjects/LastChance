using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wolf : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float moveSpeed = 50f;
    private Player target = null ;
    private bool following;
    Animator animator;
    void Start()
    {
        following = false;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (following)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, moveSpeed * Time.deltaTime);
            
            float transitionH = transform.position.x;
            float transitionV = transform.position.y;

            transitionH *= moveSpeed * Time.deltaTime;
            transitionV *= moveSpeed * Time.deltaTime;

            animator.SetFloat("Movement", Mathf.Abs(transitionH) + Mathf.Abs(transitionV));
            if(transitionV <= 0f && transitionH < 0f)
            {
                setAnimator("left");
            }
            else if(transitionV <0f && transitionH >= 0f)
            {
                setAnimator("back");
            }
            else if(transitionV >=0f && transitionH > 0f)
            {
                setAnimator("right");
            }
            else if(transitionV > 0f && transitionH <= 0f)
            {
                setAnimator("front");
            }

        }
    }
      
    private void setAnimator(String directie)
    {
        if (directie == "back")
        {

            animator.SetBool("Back", true);
            animator.SetBool("Front", false);
            animator.SetBool("Right", false);
            animator.SetBool("Left", false);
        }
        else if (directie == "front")
        {
            animator.SetBool("Back", false);
            animator.SetBool("Front", true);
            animator.SetBool("Right", false);
            animator.SetBool("Left", false);
        }
        else if (directie == "right")
        {
            animator.SetBool("Back", false);
            animator.SetBool("Front", false);
            animator.SetBool("Right", true);
            animator.SetBool("Left", false);
        }
        else if (directie == "left")
        {
            animator.SetBool("Back", false);
            animator.SetBool("Front", false);
            animator.SetBool("Right", false);
            animator.SetBool("Left", true);
        }


    }
    private void OnTriggerStay2D(Collider2D collision)
    {
       
        
        if (collision.gameObject.name == "Player")
        {
          
            following = true;
            target = collision.gameObject.GetComponent<Player>();
        }
    }

   
}
