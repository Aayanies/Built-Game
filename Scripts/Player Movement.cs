using System;
using System.Numerics;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]private float speed;
    [SerializeField]private float jumperPower;
    
    [SerializeField]private LayerMask groundlayer;
    [SerializeField]private LayerMask wallLayer;
    private Rigidbody2D body;
    private Animator anim;
    private BoxCollider2D boxCollider;
    private float jumpCoolDown;
    private float HorizontalInput;
    public GameObject Interaction;
    private UnityEngine.Vector2 boxSize = new UnityEngine.Vector2(0.1f,1f);
    

    
    // rigidbody2D and animator from the objector
    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();

    }

    private void Update()
    {
        HorizontalInput = Input.GetAxis("Horizontal");
        


//Flipping character animation when walking left or right
        if(HorizontalInput > 0.5f)
           {
            transform.localScale = new UnityEngine.Vector3(5,5,1);
           } 
        else if (HorizontalInput < -0.5f)
            {
                transform.localScale = new UnityEngine.Vector3(-5,5,1);
            }

       
        // Setting Paramators for animation
        anim.SetBool("run", HorizontalInput != 0);
        anim.SetBool("grounded", isGrounded());


//wall jumpingx 
        if (jumpCoolDown > 0.3f)
        {
            if(Input.GetKey(KeyCode.Space))
                 jump();
             body.velocity = new UnityEngine.Vector2(HorizontalInput * speed, body.velocity.y);

            if (Walls() && isGrounded())
            {
                body.gravityScale = 5;
                body.velocity = UnityEngine.Vector2.zero;
            }
            else
                body.gravityScale = 3;

            if(Input.GetKey(KeyCode.Space) && isGrounded())
            jump();

        }
        else
            jumpCoolDown += Time.deltaTime;
    {
        if(Input.GetKeyDown(KeyCode.E))
            CheckIntraction();
    }
    }


    private void jump()
    {   
        if(isGrounded())
        {
        body.velocity = new UnityEngine.Vector2(body.velocity.x, jumperPower);
        anim.SetTrigger("jump");
        }
        else if (Walls() && !isGrounded())
        {
            if (HorizontalInput == 0)
            {
                body.velocity = new UnityEngine.Vector2(-Mathf.Sign(transform.localScale.x) * 10,0);
                transform.localScale = new UnityEngine.Vector3(-Mathf.Sign(transform.localScale.x), 
                transform.localScale.y, transform.localScale.z);
            }
            else 
                body.velocity = new UnityEngine.Vector2(-Mathf.Sign(transform.localScale.x) * 3,6);

            jumpCoolDown = 0;   
        }
    
    }

    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // if(collision.gameObject.tag == "ground")
        //     // grounded = true;
    }

    
    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, UnityEngine.Vector2.down, 0.1f, groundlayer);
        return raycastHit.collider != null;
    }


    private bool Walls()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, new UnityEngine.Vector2(transform.localScale.x,0), 0.1f, wallLayer);
        return raycastHit.collider != null;
    }

    public void OpenInteractable()
    {
        Interaction.SetActive(true);
    }

    public void CloseIntractable()
    {
        Interaction.SetActive(false);
    }

    public void CheckIntraction()
    {
        RaycastHit2D[] hits = Physics2D.BoxCastAll(transform.position,boxSize, 0, UnityEngine.Vector2.zero);

        if(hits.Length > 0)
        {
            foreach(RaycastHit2D rc in hits)
            {
                if (rc.transform.GetComponent<Interaction>())
                {
                    rc.transform.GetComponent<Interaction>().Interact();
                    return;
                }
            }
        }
    }


    UnityEngine.Vector2 startPos;
    private void Start()
    {
        startPos = transform.position;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ( collision.CompareTag("Barrier"))
        {
            Die();
        }
    }

    private void Die()
    {
        Respawn();
    }
    void Respawn()
    {
        transform.position = startPos;
    }
}


