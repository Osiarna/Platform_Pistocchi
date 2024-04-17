using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Playermovement : MonoBehaviour
{
    public GameObject Player;
    public float jumptimer;
    public float xMove;
    public float speed;
    public float gravity;
    public float jump;
    public bool pressedW;
    public bool isGrounded;

    bool stopped;
    public bool wathleft;

    public Rigidbody2D rb;

    public LayerMask GroundMask;
    public float dashpower;
    public float dashtimer;
    public bool hasdash;
    public float dashcd = .4f;
    public bool WJL; /*(è attaccato al muro di sinistra)*/
    public bool WJR; /*(è attaccato al muro di destra)*/
    public float WJCD = 20F; /*(cooldown walljump)*/
    
    // Start is called before the first frame update
    void Start()
    {
        rb.freezeRotation = true;
        dashtimer = dashcd;
    }

    // Update is called once per frame
    void Update()
    //DASH SYTEM
    {
        if(Input.GetKeyDown("space") && hasdash == false && !stopped)
        {
            StartCoroutine (dashcoroutine());
        }
        if(Input.GetKeyDown("space") && hasdash == false && !stopped)
        {
           StartCoroutine (dashcoroutine());
        }
         if (hasdash)
         {
            dashtimer -= Time.deltaTime;
         }
         if (dashtimer <= 0)
         {
            dashtimer = dashcd; 
            hasdash = false;
         }
        //ANTISPAM

        if (Input.GetKeyDown("w")) pressedW = true;
        if (Input.GetKeyUp("w")) pressedW = false;

        //GRAVITY

        rb.AddForce(Vector2.down * gravity);

        //MOVEMENT

        if (!stopped)
        {
        xMove = Input.GetAxisRaw("Horizontal");
        if (!hasdash)
        {
             rb.velocity = new Vector2 (xMove * speed, rb.velocity.y);
        }
       
        }
        //JUMP
        if (isGrounded && !pressedW && !stopped)
        {
            jumptimer = .5f;
        }
        else
        {
            jumptimer -= Time.deltaTime;
        }
        if(Input.GetKey("w") && jumptimer > 0 && !stopped) rb.velocity = new Vector2 (rb.velocity.x, jump);
         if(Input.GetKeyUp("w")) jumptimer = 0;
        
    //JUMP COLLISION
        
     RaycastHit2D Boxcast = Physics2D.BoxCast (new Vector2(transform.position.x, transform.position.y), new Vector2 (0.1F, 0.1F), 90F, Vector2.down, .5F, GroundMask);
     if (Boxcast.collider != null)
     {
        isGrounded = true;
     }
     else
     {
        isGrounded = false;
     }
     RaycastHit2D Boxcastleft = Physics2D.BoxCast (new Vector2(transform.position.x, transform.position.y), new Vector2 (0.1f, 0.1f), 90f, Vector2.left, .5f, GroundMask);
    if (Boxcastleft.collider != null && wathleft)
    {
        WJL = true;
    }
    else
    {
        WJL = false;
    }
    RaycastHit2D Boxcastright = Physics2D.BoxCast (new Vector2(transform.position.x, transform.position.y), new Vector2 (.1f, .1f), 90f, Vector2.right, .5f, GroundMask);
    if (Boxcastright.collider != null && !wathleft)
    {
        WJR = true;
    }
    else
    {
        WJR = false;
    }
    //WALL JUMP
    if (Input.GetKeyDown("w") && !stopped && WJCD > 0)
    {
        StartCoroutine (jumpcoroutine());
    }
    if (Input.GetKeyDown("w") && !stopped && WJCD > 0)
    {
        StartCoroutine (jumpcoroutine());
    }
    //PLAYER POV   
     if(Input.GetKey("a"))
     {
        wathleft = true;
        transform.localScale = new Vector3 (-3, 3, 1);
     }
     else if (Input.GetKey("d"))
     {
        wathleft = false;
        transform.localScale = new Vector3 (3, 3, 1);
     }
     if (Input.GetKeyUp("a"))
     {
        transform.localScale = new Vector3 (-3, 3, 1);
     }
       
    }
      public void stopplayer()
    {
        stopped = true;
    }

    public void startplayer()
    {
        stopped = false;
    }
    private IEnumerator dashcoroutine()
    {
        if(!wathleft)
        {
            rb.AddForce(Vector2.right * dashpower, ForceMode2D.Impulse);
        }
        if (wathleft)
        {
            rb.AddForce(Vector2.left * dashpower, ForceMode2D.Impulse);
        }
        hasdash = true;
        yield return null;
    }
    private IEnumerator jumpcoroutine()
    {
    if (WJL)
    {
        rb.AddForce(Vector2.right * jump * 2, ForceMode2D.Impulse);
        rb.AddForce(Vector2.up * jump * 2, ForceMode2D.Impulse);
        WJCD -= Time.deltaTime;
    }
    if(WJR)
    {
        rb.AddForce(Vector2.left * jump * 2, ForceMode2D.Impulse);
        rb.AddForce(Vector2.up * jump * 2, ForceMode2D.Impulse);
        WJCD -= Time.deltaTime;
    }
    if (!WJL && !WJR )
    {
        WJCD = 20F;
    }
    yield return null;
    }
    public void playersetup ()
    {
        transform.position = new Vector3 (-7.7f, -6.54f, 0f);
    }
}
