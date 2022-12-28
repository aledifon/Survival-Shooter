using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public int damagePerShot; //Damage made by each shoot
    public float timeBetweenBulets;//time between shoots
    public float range; //raycast length Represents the weapon's range
    public LayerMask shootableMask;//Object Layer for the raycast

    float timer;
    Ray ray;
    RaycastHit hit;
    LineRenderer lineRenderer;
    AudioSource audioS;
    Light gunLight;
    float effectsDisplayTime = 0.2f;//var. which determines how long will be the effects on the screen

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        audioS = GetComponent<AudioSource>();
        gunLight = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (Input.GetMouseButtonDown(0) && timer >= timeBetweenBulets)
        {
            Shoot();
        }
        if (timer >= timeBetweenBulets * effectsDisplayTime)
        {
            lineRenderer.enabled = false;
            gunLight.enabled = false; 
        }
    }
    void Shoot()
    {
        timer = 0;
        //Play the audio clip
        audioS.Play();

        //Enable effects
        lineRenderer.enabled = true;
        gunLight.enabled = true;

        //Establish the 1st pos. of the Line Renderer
        lineRenderer.SetPosition(0, transform.position);

        ray.origin = transform.position;
        ray.direction = transform.forward;

        if (Physics.Raycast(ray, out hit, range, shootableMask))
        {
            //Save in the var. _object the GO with the Raycast is hitting
            GameObject _object = hit.collider.gameObject;
            //If the object wich the raycast is hitting has the EnemyHealth component
            if (_object.GetComponent<EnemyHealth>())
            {
                _object.GetComponent<EnemyHealth>().TakeDamage(damagePerShot,hit.point);
            }

            //Establish the 2nd pos. of the Line Renderer
            lineRenderer.SetPosition(1, hit.point);
        }
        else
        {
            //if the raycast does not hit with anything, we'll stablish the 2nd Point
            //of the line renderer "far away" but in the shoot direction
            lineRenderer.SetPosition(1, ray.origin + (ray.direction * range));


        }

    }
}
