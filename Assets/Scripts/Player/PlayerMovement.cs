using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public int speed;
    public LayerMask layerGround; //the layer where will be the ground

    Rigidbody rb;
    Animator anim;
    Vector3 movement;//var. where I'm going to save my dir. of movement
    float horizontal;
    float vertical;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        InputPlayer();
        Animating();
    }
    private void FixedUpdate()
    {
        Move();
        Turning();
    }
    void InputPlayer()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        movement = new Vector3(horizontal, 0, vertical);//movement direction.
        movement.Normalize();//we normalize the vector, it means his module is 1 in order to avoid
        //to go faster than the player in diagonal than horizontal or in depth
    }
    void Move()
    {
        rb.MovePosition(transform.position + (movement * speed * Time.deltaTime));
    }
    void Animating()
    {
        if (horizontal != 0 || vertical != 0)
            anim.SetBool("IsMoving", true);
        else
            anim.SetBool("IsMoving", false);
    }
    void Turning()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerGround))
        {
            Vector3 playerToMouse = hit.point - transform.position;
            playerToMouse.y = 0; //Vector stays in the XZ plane.

            //Generates a rotation according to playerToMouse vector
            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
            //Applies the rotation to the Rigid Body of the player
            rb.MoveRotation(newRotation);

            //Debug.Log("HitPoint = (" + hit.point.x + "," + hit.point.y + "," + hit.point.z + ")" +
            //          "PlayerPos =(" + transform.position.x + "," + 
            //                            transform.position.y + "," +
            //                            transform.position.z + ")" +
            //          "PlayerToMouse =(" + playerToMouse.x + "," +
            //                            playerToMouse.y + "," +
            //                            playerToMouse.z + ")");
        }
        Debug.DrawRay(ray.origin, ray.direction * 100, Color.red);
    }
}
