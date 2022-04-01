using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMovement : MonoBehaviour
{
    // Start is called before the first frame update
    
    public GameObject Paddle1;
    public GameObject Paddle2;
    GameObject paddle;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        float inputY = Input.GetAxis("Vertical");
        if(transform.position.x<=0f)
        {
            paddle = Paddle1;
        }
        else if(transform.position.x>0f)
        {
            paddle = Paddle2;
        }
        paddle.transform.Translate(new Vector2(0f,2*inputY*Time.deltaTime));

    }
}
