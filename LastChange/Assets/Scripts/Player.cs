using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Animator animator;
    [SerializeField] float speed = 10.0f;
    void Start()
    {
        animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("isJump",true);
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            
            animator.SetBool("isJump", false);
        }
        float transitionH = Input.GetAxis("Horizontal");
        float transitionV = Input.GetAxis("Vertical");
        animator.SetFloat("Horizontal", (Mathf.Abs(transitionH) + Mathf.Abs(transitionV)) * speed);
         transitionH = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
         transitionV = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        Debug.Log(Input.GetAxis("Horizontal") * speed + " " + animator.GetFloat("Horizontal"));
        transform.Translate(transitionH ,transitionV, 0.0f);
       
    }
}
