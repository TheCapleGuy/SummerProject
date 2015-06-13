using UnityEngine;
using System.Collections;

public class AttackObjectManager : MonoBehaviour
{
    private float dodgeDeathTimer = 0;
    public int dodgeLife;
    public GameObject player;
    private Rigidbody2D pRigidBody;
    private Vector3 dodgePosition;
    private float tParam = 0;
    private Vector2 lerpStart;
    // Use this for initialization
    void Start()
    {
        //dodgeTransform = transform;
        pRigidBody = player.GetComponent<Rigidbody2D>();
        Debug.Log("RigidBody x: " + pRigidBody.transform.position.x);
        Debug.Log("gameObject x: " + player.transform.position.x);
    }

    // Update is called once per frame
    void Update()
    {
        DeathTimer(this.gameObject);
        MoveObject();
    }

    public void DeathTimer(GameObject gObject)
    {
        //death timer for dodge object
        if (dodgeDeathTimer < dodgeLife)
        {
            dodgeDeathTimer += 2 + (1 * Time.deltaTime);
            //Debug.Log("death timer" + dodgeDeathTimer);
        }
        else
        {
            DestroyObject(gObject, 3f);
            dodgeDeathTimer = 0;
        }
    }

    public void MoveObject()
    {
        //how the fuck do i get prefabs with no rigidBody to follow an
        //object it is connected too....
        //dodgePosition.x += Mathf.Lerp(transform.position.x, pBody.position.x, Time.deltaTime);
        dodgePosition = transform.position;
        //lerpStart = dodgePosition;
        //dodgePosition += new Vector3(pBody.position.x,pBody.position.y,0);
        if (tParam < 1)
        {
            tParam += 1 * Time.deltaTime;
            dodgePosition.x += Mathf.Lerp(dodgePosition.x, player.transform.position.x, tParam);
            //Debug.Log("Player position: " + player.transform.position.x);
        }
        transform.position = dodgePosition;
    }
}
