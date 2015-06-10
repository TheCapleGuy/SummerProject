using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{
    public float speed = 6.0F;
    public float gravity;
    private float moveSpeed;

    void Start()
    {

    }

    void Update()
    {

        
        
        ////jump
        //if(Input.GetButtonDown(("Jump")))
        //{
        //    GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpSpeed);
        //}

        
        //apply gravity to player
        GetComponent<Rigidbody2D>().AddForce(new Vector2(0,-gravity));
    }
}
