using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WolfAttack : MonoBehaviour
{
    float timeBtwAttack;
    public float startTimeBtwAttack;
    private Wolf wolf = null;
    // Start is called before the first frame update
    void Start()
    {
        wolf = GetComponentInParent<Wolf>();
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (timeBtwAttack <= 0)
        {

            if (collision.gameObject.name == "Player")
            {
                collision.gameObject.GetComponent<Player>().takeDamage(wolf.damage);
            }
            timeBtwAttack = startTimeBtwAttack;
        }
        else
        {
            timeBtwAttack -= Time.deltaTime;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
