using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack2D : MonoBehaviour {

    public float timeBetweenAttacks = 0.3f;
    public int attackDamage = 1;


    //Animator anim;
    GameObject player;
    PlayerHealth playerHealth;
    //EnemyHealth enemyHealth;
    bool playerInRange;
    float timer;


    void Awake()
    {
        Debug.Log("Awake通過");
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        //enemyHealth = GetComponent<EnemyHealth>();
        //anim = GetComponent<Animator>();
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("あたった");
        if (collision.gameObject == player)
        {
            playerInRange = true;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("あたった");
        if (other.gameObject == player)
        {
            playerInRange = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log("離れた");
        if (collision.gameObject == player)
        {
            playerInRange = false;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("離れた");
        if (other.gameObject == player)
        {
            playerInRange = false;
        }
    }


    void Update()
    {

        timer += Time.deltaTime;

        if (timer >= timeBetweenAttacks && playerInRange/* &&
        enemyHealth.currentHealth > 0*/)
        {
            Attack();
        }

        if (playerHealth.currentHealth <= 0)
        {
            //anim.SetTrigger("PlayerDead");
        }
    }


    void Attack()
    {
        timer = 0f;

        if (playerHealth.currentHealth > 0)
        {
            playerHealth.TakeDamage(attackDamage);
        }
    }
}
