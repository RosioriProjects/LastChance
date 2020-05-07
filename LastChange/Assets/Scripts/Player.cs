using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Animator animator;
    [SerializeField] float speed = 1.0f;
    Rigidbody2D rb;
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        float transitionH = Input.GetAxis("Horizontal");
        float transitionV = Input.GetAxis("Vertical");
      
        transitionH *= speed * Time.deltaTime;
        transitionV *= speed * Time.deltaTime;
        rb.velocity = new Vector2(transitionH, transitionV);
        Debug.Log(transitionV);
        if (transitionV < 0f)
        {
           
            animator.SetBool("FacedBack", false);
            animator.SetBool("FacedFront", true);
            animator.SetFloat("Speed",transitionV);
        }
        if (transitionV > 0f)
        {
            animator.SetBool("FacedFront", false);
            animator.SetBool("FacedBack", true);
            animator.SetFloat("Speed", transitionV);
        }

        transform.Translate(transitionH ,transitionV, 0.0f);
       
    }
}
