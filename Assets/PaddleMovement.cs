using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMovement : MonoBehaviour
{
    // Start is called before the first frame update
    
    public GameObject Paddle1;
    public GameObject Paddle2;
    GameObject paddle;
    public float paddleSpeed;
    RacketMovement racketMovement;
    void Start()
    {
        racketMovement = GameObject.Find("Racket").GetComponent<RacketMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (racketMovement.IsGameOver == false)
        {
            float inputY = Input.GetAxis("Vertical");
            if (transform.position.x <= 0f)
            {
                paddle = Paddle1;
            }
            else if (transform.position.x > 0f)
            {
                paddle = Paddle2;
            }
            paddle.transform.Translate(new Vector2(0f, paddleSpeed * inputY * Time.deltaTime));
        }

    }
}
