using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyProjectile : EnemyDamage //Will damage the player every time it touches the player
{
    [SerializeField] private float speed;
    [SerializeField] private float resetTime;
    private float LifeTime;

    public void ActiveProjectile()
    {
        LifeTime = 0;
        gameObject.SetActive(true);
    }

    private void Update()
    {
        float movementSpeed = speed * Time.deltaTime;
        transform.Translate(movementSpeed, 0, 0);

        LifeTime += Time.deltaTime;
        if(LifeTime > resetTime)
            gameObject.SetActive(false);

    }

    private new void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision); //will be executing from first parent scrupt
        gameObject.SetActive(false); //it will deactive if it hits any objects
        
    }
}
