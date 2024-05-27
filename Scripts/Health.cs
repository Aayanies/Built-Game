using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    [Header ("Health")]
    [SerializeField]private float startingHealth;
    public float currentHealth{ get; private set; }
    private Animator anim;

    private bool dead;

        [Header ("iFrame")]
        [SerializeField]private float iFrameDuration;
        [SerializeField]private int noFlashes;
        private SpriteRenderer spriteRend;



    private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
    }

    public void takeDamage(float _damage)
    {
        //Health system
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);
        Debug.Log(currentHealth);

        if(currentHealth  > 0)
        {
            //players Hurt
            anim.SetTrigger("Hurt");
            Debug.Log("Player has been hurt");
        }
        else
        {   
            if(!dead)
            {
            //players dead
            anim.SetTrigger("Die");
            GetComponent<PlayerMovement>().enabled = false;
            dead = true;
            }
        }
    }


    public void AddHeath(float _value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);
    }

    public void Respawn()
    {
        dead = false;
        AddHeath(startingHealth);
        anim.ResetTrigger("Die");
        anim.Play("ideal");
    }
    private IEnumerator Invunerbility()
    {
        Physics2D.IgnoreLayerCollision(10, 11, true);
        //Invunerable Desteration
        for (int i = 0; i < noFlashes; i++)
        {
            spriteRend.color = new Color(1,0,0, 0.5f);
            yield return new WaitForSeconds(iFrameDuration / (noFlashes));
            spriteRend.color = Color.white;
            yield return new WaitForSeconds(1);

        }
        Physics2D.IgnoreLayerCollision(10, 11, false);

    }   


    // private void Update()
    // {
    //     if(Input.GetKeyDown(KeyCode.E))
    //         takeDamage(1);
    // }



}





