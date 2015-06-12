using UnityEngine;
using System.Collections;

public class AttackObjectManager : MonoBehaviour
{
    private float dodgeDeathTimer = 0;
    public int dodgeLife;
    public GameObject player;
    private Vector3 dodgePosition;
    private float tParam = 0;
    private Vector2 lerpStart;
    // Use this for initialization
    void Start()
    {
        //dodgeTransform = transform;    
    }

    // Update is called once per frame
    void Update()
    {
        //DeathTimer(this.gameObject);
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
        /*
         * First of all you are setting your public player variable in the editor with a prefab. You don't instantiate a new player with it,
         * you seem to be trying to call the player INSTANCE that is in your scene when you load it.  It's just like a class isn't an object you can manipulate,
         * it's a blueprint for an object, you have to instantiate the class and assign it to a variable and then you can call functions on it.
         * So, you either grab a handle on the player on your scene at run-time using findobject methods (expensive if not needed) or you hook up your public variable 
         * with the gameobject instance in your scene.
         */


        //dodgePosition.x += Mathf.Lerp(transform.position.x, pBody.position.x, Time.deltaTime);
        dodgePosition = transform.position;
        //lerpStart = dodgePosition;
        //dodgePosition += new Vector3(pBody.position.x,pBody.position.y,0);
        if (tParam < 1)
        {
            tParam += 1 * Time.deltaTime;
            //you were adding the result instead of just assigning it.
            dodgePosition.x = Mathf.Lerp(dodgePosition.x, player.transform.position.x, tParam);
            Debug.Log("Player position: " + player.transform.position.x);
        }
        transform.position = dodgePosition;
    }
}
