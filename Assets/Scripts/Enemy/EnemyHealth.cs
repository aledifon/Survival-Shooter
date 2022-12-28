using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;
    public float sinkSpeed;// sinking speed
    public int scoreValue;//scored points when he dies
    public bool isDead;

    public AudioClip deathClip;

    public ParticleSystem hitParticles;

    AudioSource audioS;
    Animator anim;
    public bool isSinking;//To know if it's sinking

    void Start()
    {
        currentHealth = maxHealth;
        anim = GetComponent<Animator>();
        audioS = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (isSinking)
        {
            transform.Translate(-Vector3.up * sinkSpeed * Time.deltaTime);
        }
            
    }
    //Public method which we'll call from the script PlayerShooting
    public void TakeDamage(int amount, Vector3 point)
    {
        //If the enemy is dead, it will exit the method
        if (isDead) return;

        //We take enemy's life health & play the associated audio clip
        currentHealth -= amount;
        audioS.Play();

        //Set the Particles in the Hitting Bullet pos. (given by PlayerShooting script)
        //and reproduce the particles audio cl
        hitParticles.transform.position = point;
        hitParticles.Play();

        //Check if enemy is dead
        if (currentHealth <= 0) Death();
    }
    void Death()
    {
        //Set Death Clip as new audio clip & play it
        audioS.clip = deathClip;
        audioS.Play();

        //Enables the boolean var. isDead & also enables the Death animation
        isDead = true;
        anim.SetTrigger("Death");
    }
    //Method associated as event of the animation
    void StartSinking()
    {
        isSinking = true;
        GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
        Destroy(gameObject, 2);
    }
}
