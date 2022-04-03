using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RacketMovement : MonoBehaviour
{
    // Start is called before the first frame update

    Rigidbody2D rb;
    int f = 0;
    public Text paddle1score;
    public Text paddle2score;
    public GameObject winPanel;
    public Text winText;
    int score1;
    int score2;
    public bool IsGameOver = false;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //Invoke("GoBall", 2);
        //  rb.AddForce(new Vector2(20, -15)*Time.deltaTime);
        rb.velocity = new Vector2(4f, 0f);
    }

    // Update is called once per frame
    void Update()
    {

        if (IsGameOver == true)
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
        if(score1==10)
        {
            winPanel.SetActive(true);
            winText.text = "Player1 Win";
            IsGameOver = true;
        }
        if(score2==10)
        {
            winPanel.SetActive(true);
            winText.text = "Player2 Win";
            IsGameOver = true;
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        //float y;
        if (collision.gameObject.tag == "Collider")                 // When it touches bottom collider
            rb.velocity = new Vector2(rb.velocity.x, 1);
        if (collision.gameObject.tag == "Collider1")
            rb.velocity = new Vector2(rb.velocity.x, -1);           // When object touches top collider
        if (collision.gameObject.tag == "Left")                    // Score updating of right paddle
        {
            score2 += 1;
            paddle2score.text = score2.ToString();
        }
        if (collision.gameObject.tag == "Right")                //Score updating of left paddle
        {
            score1 += 1;
            paddle1score.text = score1.ToString();
        }

        //Debug.Log(collision.gameObject);
        // Debug.Log(vel.y);


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        float y = 0;
        if (collision.gameObject.tag == "Top")      // When racket touches the top of paddle, then moves up
            y = 1;
        else if (collision.gameObject.tag == "Bottom") // when racket touches the bottom of paddle , then moves down
            y = -1;
        rb.velocity = new Vector2(rb.velocity.x, y);     // If touches at the middle , then no velocity 

    }
   
}
