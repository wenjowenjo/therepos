using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingplayer : MonoBehaviour
{
    private float horizontal;
    private float speed = 8f;

    private Animator anim;
   
   

   [SerializeField] private Rigidbody2D rb;
   
   
   

    // Update is called once per frame
    void Update()
    {
       anim = GetComponent<Animator>();
       
        horizontal = Input.GetAxisRaw("Horizontal");

        /* jump */
        if (Input.GetKey(KeyCode.Space))
        rb.velocity = new Vector2(rb.velocity.x, speed);

        /*flip*/
        if (horizontal > 0.01f)
            transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        else if (horizontal < -0.01f)
            transform.localScale = new Vector3(-0.5f, 0.5f, 0.5f);

        /* run animation */
        anim.SetBool("run", horizontal != 0);
    }
    
    



    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }


 
}