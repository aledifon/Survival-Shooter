using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float timeBetweenAttacks;
    public int attackDamage;

    GameObject player;
    EnemyHealth enemyHealth;
    bool playerInRange;
    float timer;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        enemyHealth = GetComponent<EnemyHealth>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
            playerInRange = true;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
            playerInRange = false;
    }
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= timeBetweenAttacks && playerInRange && !enemyHealth.isDead)
            Attack();
    }
    void Attack()
    {
        timer = 0;
        Debug.Log("I remove player's health");
    }
}
