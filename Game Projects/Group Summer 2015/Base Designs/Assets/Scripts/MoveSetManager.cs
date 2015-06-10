using UnityEngine;
using System.Collections;

public class MoveSetManager : MonoBehaviour
{
    public float speed = 6.0F;
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
        moveSpeed = speed * Input.GetAxis("Horizontal");

        //apply moveSpeed to the characters location
        rBody.velocity = new Vector2(moveSpeed, rBody.velocity.y);
    }
}
