using UnityEngine;
using System.Collections;

public class MoveSetManager : MonoBehaviour
{
    public float speedMax = 10f;
    public float jumpSpeed;
    public float gravity;
    private float moveSpeed;
    public Rigidbody2D rBody;
    public virtual void Activate(){}

    public virtual void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
    }

    public virtual void MeleeAttack(){}
    public virtual void HeavyAttack(){}
    public virtual void Dodge(){}
    public void Jump()
    {
        rBody.velocity = new Vector2(rBody.velocity.x, jumpSpeed);
    }

    public void Movement()
    {
        //reset moveSpeed to stop character
        moveSpeed = 0;

        //joystick input for movement left and right
        moveSpeed = Input.GetAxis("Horizontal");

        //apply moveSpeed to the characters location
        //keep the velocity below or equal to speedMax
        rBody.velocity += new Vector2(moveSpeed, 0);
        if (rBody.velocity.x > speedMax)
            rBody.velocity = new Vector2(speedMax, rBody.velocity.y);
        else if (rBody.velocity.x < -speedMax)
            rBody.velocity = new Vector2(-speedMax, rBody.velocity.y);
    }
}
