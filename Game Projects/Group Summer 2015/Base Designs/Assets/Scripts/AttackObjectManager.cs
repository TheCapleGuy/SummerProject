﻿using UnityEngine;
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
        dodgePosition = transform.position;
        if (tParam < 1)
        {
            tParam += 1 * Time.deltaTime;
            dodgePosition.x = Mathf.Lerp(dodgePosition.x, player.transform.position.x, tParam);
            dodgePosition.y = Mathf.Lerp(dodgePosition.y, player.transform.position.y, tParam);
            
            // Debug.Log("Player position: " + player.transform.position.x);
        }
        transform.position = dodgePosition;
    }
}
 