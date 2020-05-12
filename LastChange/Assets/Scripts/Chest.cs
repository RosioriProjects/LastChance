using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void OpenChest()
    {
        animator.SetBool("Open", true);
        Debug.Log("Am deschis Chest-ul");
    }
    public void CloseChest()
    {
        animator.SetBool("Open", false);
        Debug.Log("Am inchis Chest-ul");
    }
}
