using UnityEngine;
using System.Collections;

public class DeathTimer : MonoBehaviour
{
    private float dodgeDeathTimer = 0;
    public int dodgeLife;
    private GameObject rockWall;

    void Start()
    {
        rockWall = this.gameObject;
    }

    // Update is called once per frame
	void Update () 
    {
        //death timer for dodge object
        if (dodgeDeathTimer < dodgeLife)
        {
            dodgeDeathTimer += 2 + (1 * Time.deltaTime);
            Debug.Log("death timer" + dodgeDeathTimer);
        }
        else
        {
            DestroyObject(rockWall, 3f);
            dodgeDeathTimer = 0;
        }
	}
}
