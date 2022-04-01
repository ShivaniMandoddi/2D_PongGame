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
        Invoke("GoBall", 2);
        //  rb.AddForce(new Vector2(20, -15)*Time.deltaTime);

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
       
        if (collision.gameObject.tag == "Paddle2" || collision.gameObject.tag == "Paddle1")
        {

            
                Vector2 vel;
                vel.x = rb.velocity.x;
                vel.y = (rb.velocity.y / 2) + (collision.collider.attachedRigidbody.velocity.y / 3);
                rb.velocity = vel;
            
        }
        else if (collision.gameObject.tag == "Paddle1")
        {
           
            //f = 1;
        }
        if(collision.gameObject.tag=="Collider")
        {
          
        }

    }
    private void GoToAngle(Vector3 eulerAngle)
    {
        Quaternion targetRotation = Quaternion.Euler(eulerAngle);
        Vector3 targetDirection = targetRotation * Vector3.forward;
        float speed = rb.velocity.magnitude;
        rb.velocity = speed * targetDirection;
    }
    void GoBall()
    {
        float rand = Random.Range(0, 2);
        if (rand < 1)
        {
            rb.AddForce(new Vector2(20, -15));
        }
        else
        {
            rb.AddForce(new Vector2(-20, -15));
        }
    }
    void RestartGame()
    {
        ResetBall();
        Invoke("GoBall", 1);
    }
    void ResetBall()
    {
        rb.velocity = Vector2.zero;
        transform.position = Vector2.zero;
    }
}
