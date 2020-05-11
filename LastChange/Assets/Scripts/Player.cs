using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Animator animator;
    [SerializeField] float speed = 1.0f;
    Rigidbody2D rb;
    bool deschis = false;
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

        if (transitionV < 0f)
        {
           
            animator.SetBool("FacedBack", false);
            animator.SetBool("FacedLeft", false);
            animator.SetBool("FacedRight", false);
            animator.SetBool("FacedFront", true);
            animator.SetFloat("SpeedV",transitionV);
        }
        if (transitionV > 0f)
        {
            animator.SetBool("FacedFront", false);
            animator.SetBool("FacedLeft", false);
            animator.SetBool("FacedRight", false);
            animator.SetBool("FacedBack", true);
            animator.SetFloat("SpeedV", transitionV);
        }
        if (transitionH < 0f)
        {

            animator.SetBool("FacedBack", false);
            animator.SetBool("FacedRight", false);
            animator.SetBool("FacedFront", false);
            animator.SetBool("FacedLeft", true);
            animator.SetFloat("SpeedH", transitionH);
        }
        if (transitionH > 0f)
        {
            animator.SetBool("FacedFront", false);
            animator.SetBool("FacedLeft", false);
            animator.SetBool("FacedBack", false);
            animator.SetBool("FacedRight", true);
            animator.SetFloat("SpeedH", transitionH);
        }

        transform.Translate(transitionH ,transitionV, 0.0f);
       


    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        
        if (collision.gameObject.name == "Chest")
        {
            Debug.Log("Sunt in trigger");
            if (Input.GetKeyDown(KeyCode.C))
            {
                if (deschis)
                {
                    FindObjectOfType<Chest>().CloseChest();
                    deschis = false;
                }
                else
                {
                    FindObjectOfType<Chest>().OpenChest();
                    deschis = true;
                }
            }
        }
    }



}
