using UnityEngine;
using System.Collections;

public class AttackObjectManager : MonoBehaviour {
    private float dodgeDeathTimer = 0;
    public int dodgeLife;
    private GameObject dodgeObject;
    public GameObject player;
    private Rigidbody2D pBody;
    private Vector3 dodgePosition;
	// Use this for initialization
	void Start () 
    {
        //dodgeTransform = transform;
        dodgeObject = this.gameObject;
        pBody = player.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        DeathTimer(dodgeObject);
        //MoveObject();
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
        dodgePosition += new Vector3(pBody.position.x,pBody.position.y,0);
        transform.position = dodgePosition;
    }
}
