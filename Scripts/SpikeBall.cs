using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class SpikeBall : EnemyDamage //inheritance
{
    [Header ("SpikeBalls Attributes")]
    [SerializeField] private float speed;
    [SerializeField] private float range;
    [SerializeField] private float checkDelay;
    [SerializeField] private LayerMask playerLayer;
 
 
    private Vector3 destination;
    private Vector3[] directions = new Vector3[4]; // directions = 4 elements
    private bool attacking;
    private float checkTimer;
 
   
 
 
    private void OnEnable()
    {
        Stop(); //object starts in idle position
    }
 
    private void Update()
    {
        //if spikebal is attacking will mvoe to destination
        if (attacking)
        {
             transform.Translate(destination * Time.deltaTime * speed);
        }
        else
        {
            checkTimer += Time.deltaTime;
 
            if (checkTimer > checkDelay)
            {
                CheckForPlayer();
            }
        }
           
    }
 
    private void CalculateDirections()
    {
        directions[0] = transform.right * range; //spikey going right
        directions[1] = -transform.right * range; //spikey going left
        directions[2] = transform.up * range; //spikey going up
        directions[3] = -transform.up * range; //spikey going down
    }
    private void CheckForPlayer()
    {
        CalculateDirections();
 
        //Will Spikey see char in all given directions
        for (int i = 0; i < directions.Length; i++)
        {
            Debug.DrawRay(transform.position, directions[i], Color.red);
            RaycastHit2D hit = Physics2D.Raycast(transform.position, directions[i], range, playerLayer);
 
            if (hit.collider != null && !attacking)
            {
                attacking = true;
                destination = directions[i];
                checkTimer = 0;
            }
        }
    }
 
    public void Stop()
    {
        destination = transform.position; //direction is set as current position
        attacking = false;
    }
 
    private void OnTriggerEnter2D(Collider2D col)
    {
        base.OnTriggerEnter2D(col); //pulling script method from enemydamage
 
        //Will stop the spike
        Stop();
    }
}






// using System.Collections;
// using System.Collections.Generic;
// using System.Numerics;
// using Unity.VisualScripting;
// using UnityEditor.Experimental.GraphView;
// using UnityEngine;

// public class SpikeBall : EnemyDamage
// {
//     [Header("SpikeBall Attributes")]
//     private UnityEngine.Vector3[] directions = new UnityEngine.Vector3[4];
//     [SerializeField]private LayerMask PlayerLayer;
//     [SerializeField]private float checkDelay;
//     private UnityEngine.Vector3 destination;
//     [SerializeField]private float speed;
//     [SerializeField]private float Range;
//     private float checkTimer;
//     private bool Attacking;
//     private void OnEnable()
//     {
//        Stop();
//     }
//     private void Update()
//     {
//         //Moving spikeball to destination 
//         if(Attacking)
//             transform.Translate(destination * Time.deltaTime * speed);
//         else
//         {
//             checkTimer += Time.deltaTime;
//                 if(checkTimer > checkDelay)
//                     CheckForPlayer();
//         }

//     }

//     private void CheckForPlayer()
//     //checks if the spike ball sees the player in all 4 directions
//     {   
//         CalculaterDirection();

//         for (int i = 0; i < directions.Length; i++)
//         {
//             Debug.DrawRay(transform.position, directions[i], Color.red);
//             RaycastHit2D hit  = Physics2D.Raycast(transform.position, directions[i], Range, PlayerLayer);
            


//             if(hit.collider != null && !Attacking)
//             {
//                 Attacking = true;
//                 destination = directions[i];
//                 checkTimer = 0;
//                 Debug.Log("Spikes ShOULD CHASE PLAYER");
//             }
//         }
//     }

//     private void CalculaterDirection()
//     {
//         directions[0] = transform.right * Range; // Right Directions
//         directions[1] = -transform.right * Range; //Left Directions
//         directions[2] = transform.up * Range; // Up directions
//         directions[3] = -transform.up * Range; //down direction
//     }


//     private void Stop()
//     {
//         destination = transform.position; // Setting destiantion to current position
//         Attacking = false;
//     }
//    private new void  OnTriggerEnter2D(Collider2D collision)
//     {

//         base.OnTriggerEnter2D(collision); 
//         //Spike Will Stop once hits player\
//         Stop();
//     }


// }
