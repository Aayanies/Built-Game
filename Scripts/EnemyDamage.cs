using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{   
  [SerializeField] protected float damage;


  protected void OnTriggerEnter2D(Collider2D collision)
  {
    if(collision.tag == "Player")
        Debug.Log("Arrow touches player");
        collision.GetComponent<Health>().takeDamage(damage);
  }

    
}
