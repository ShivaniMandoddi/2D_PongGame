using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacketMovement : MonoBehaviour
{
    // Start is called before the first frame update

    Rigidbody2D rb;
    int f = 0;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //Invoke("GoBall", 2);
        //  rb.AddForce(new Vector2(20, -15)*Time.deltaTime);
        rb.velocity = new Vector2(3f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        /* int rand = Random.Range(0, 2);
         Debug.Log(rand);
         if(rand<1)
         {
             rb.AddForce(new Vector2(20, -15));
         }
         else
         {
             rb.AddForce(new Vector2(20, 15));
         }*/
       if(f==0)
        {
            //rb.velocity = new Vector2(2f, rb.velocity.y);
        }
        /* if (f == 1)
         {
             float x = Random.Range(1, 3);
             float y = Random.Range(1, 3);
             rb.velocity = new Vector2(x*2, y*2);
         }*/
        //GoToAngle(targetAngle);
       

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        //float y;
        if (collision.gameObject.tag == "Collider")
            rb.velocity = new Vector2(rb.velocity.x, 1);
        if (collision.gameObject.tag == "Collider1")
            rb.velocity = new Vector2(rb.velocity.x, -1);

        Debug.Log(collision.gameObject);
        // Debug.Log(vel.y);
        
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        float y = 0;
        if (collision.gameObject.tag == "Top")
            y = 1;
        else if (collision.gameObject.tag == "Bottom")
            y = -1;
        rb.velocity = new Vector2(rb.velocity.x, y);



    }
    void GoBall()
    {
        float rand = Random.Range(0, 2);
        if (rand < 1)
        {
            rb.AddForce(new Vector2(20, 2)*3);
        }
        else
        {
            rb.AddForce(new Vector2(-20, 2)*3);
        }
    }
  
}
