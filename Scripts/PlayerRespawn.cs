using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    [SerializeField] private AudioClip checkpointSound; //Sound will play when player runs over for check point
    private Transform currentCheckpoint; //Will start from last check Point
    private Health playersHealth;

    private void Awake()
    {
        playersHealth = GetComponent<Health>();
    }


    private void Respawn()
    {
        transform.position = currentCheckpoint.position; //Move player to current check point 
        playersHealth.Respawn();

        // move camera back to check point 

        
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "CheckPoint")
        collision.GetComponent<Collider>().enabled = false; // Deactivares checkpoint collider
    }
}

