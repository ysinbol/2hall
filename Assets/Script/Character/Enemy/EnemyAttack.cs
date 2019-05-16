using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {

    public int attackDamage = 1;

    GameObject player;
    PlayerHealth playerHealth;
    bool playerInRange;


    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
   }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Contains("Player"))
        {
            playerInRange = true;
        }

    }

    void Update()
    {
        if (playerInRange)
        {
            Attack();
        }
    }


    void Attack()
    {
        if (playerHealth.currentHealth > 0)
        {
            playerHealth.TakeDamage(attackDamage);
        }

        Death();
    }

    void Death()
    {
        Destroy(this.gameObject);
    }
}
