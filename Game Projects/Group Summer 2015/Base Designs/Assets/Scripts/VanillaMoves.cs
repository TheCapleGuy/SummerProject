using UnityEngine;
using System.Collections;

public class VanillaMoves : MoveSetManager {

    //rockwall used on dodge function
    public GameObject rockWall;
    public GameObject soundWave;
    private float dodgeRespawnTimer = 10;
    public int dodgeDelay;
    private float dodgeInstanceTimer = 0;
    public int dodgeInstanceLife;

	// Use this for initialization
    public override void Start () 
    {
        base.Start();
        rockWall.GetComponent<AttackObjectManager>().player = gameObject;
	}
	
	// Update is called once per frame
	public override void Update () 
    {
        //adjusting time on the timers 

        dodgeInstanceTimer += 1 * Time.deltaTime;

        //doin stuff and stuff, cause of stuff
        //used for inherited functions, like attacking and jumping
        //apply those functions in here
        Activate();

        //Using default Controller Input
        base.Update();
        
	}

    public override void Activate()
    {
        //jump
        if (Input.GetButtonDown("Jump"))
            Jump();
        //dodge
        else if (Input.GetButtonDown("Dodge") && dodgeRespawnTimer > dodgeDelay)
        {
            Dodge();
            dodgeRespawnTimer = 0;
        }
        else if (Input.GetButtonDown("Ranged"))
            HeavyAttack();
        else
            dodgeRespawnTimer += 1f * Time.deltaTime;
    }
    //overrride dodge logic here...
    //*duh*
    public override void Dodge()
    {
        //make if state timer to delay creating multiple walls
        if (dodgeInstanceTimer < dodgeInstanceLife)
            return;
        else
        {
            dodgeInstanceTimer = 0;
            Instantiate(rockWall, new Vector2(rBody.position.x, rBody.position.y), Quaternion.identity);
            rockWall.GetComponent<AttackObjectManager>().player = gameObject;
            
        }    
    }

    public override void HeavyAttack()
    {
        //base.HeavyAttack();
        soundWave.GetComponent<SoundWave>().direction = new Vector2(xDirection, yDirection);
        Instantiate(soundWave, new Vector2(rBody.position.x, rBody.position.y), Quaternion.identity);
        
    }
}
