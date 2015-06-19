using UnityEngine;
using System.Collections;

public class MoveSetManager : MonoBehaviour
{
    public float speedMax = 2f;
    private bool isGrounded;
    public float jumpSpeed;
    public float gravity;
    protected float xDirection;
    protected float yDirection;
    public Rigidbody2D rBody;
    public virtual void Activate(){}

    public virtual void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
        xDirection = Input.GetAxis("Horizontal");
        yDirection = Input.GetAxis("Vertical");
    }
    //functions to be overloaded per character
    public virtual void MeleeAttack(){}
    public virtual void HeavyAttack(){}
    public virtual void Dodge(){}
    public void Jump()
    {
        rBody.velocity = new Vector2(rBody.velocity.x, jumpSpeed);
    }
    //function to apply effect on player
    public void KnockBack(Vector2 knockBackForce)
    {
        Debug.Log("KnockBack!");
        rBody.AddForce(knockBackForce);
    }
    public void Movement()
    {
        //reset moveSpeed to stop character
        xDirection = 0;

        //joystick input for movement left and right
        xDirection = Input.GetAxis("Horizontal");

        //apply moveSpeed to the characters location
        //keep the velocity below or equal to speedMax
        rBody.velocity += new Vector2(xDirection, 0);
        if (rBody.velocity.x > speedMax)
            rBody.velocity = new Vector2(speedMax, rBody.velocity.y);
        else if (rBody.velocity.x < -speedMax)
            rBody.velocity = new Vector2(-speedMax, rBody.velocity.y);
    }

    public virtual void Update()
    {
        Movement();

    }
}
