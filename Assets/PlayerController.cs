using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed = 280f;
    private Rigidbody2D rb;
    public bool action = false;
    //public PlayerChargesUI playerChargesUI;

    //public LayerMask enemyLayer;   // Assign "Enemy" layer in Inspector
    //public float attackRange = 0.32f; // 32px = 0.32 units if Pixels Per Unit = 100
    private SpriteRenderer sr;
    private Animator anim;

    // Track last direction for idle animation
    private Vector2 lastDirection = Vector2.down; // Default facing down

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (action == false)
        {
            float moveX = Input.GetKey(KeyCode.D) ? 1f : Input.GetKey(KeyCode.A) ? -1f : 0f;
            float moveY = Input.GetKey(KeyCode.W) ? 1f : Input.GetKey(KeyCode.S) ? -1f : 0f;
            bool isRunning = (moveX != 0 || moveY != 0);

            anim.SetBool("isrunning", isRunning);
            anim.SetFloat("moveX", moveX);
            anim.SetFloat("moveY", moveY);
                
            Vector2 movement = new Vector2(moveX, moveY);
            rb.velocity = movement * moveSpeed * Time.fixedDeltaTime;

          
        }


        //if (Input.GetButtonDown("Fire1") && playerChargesUI.charges > 0 && action == false)
        //{
        //    action = true;
        //    playerChargesUI.SetCharges(--playerChargesUI.charges);
        //    rb.velocity = Vector2.zero;
        //    var anim = GetComponent<Animator>();
        //    anim.SetBool("isrunning", false);
        //    anim.SetTrigger("hammer");
        //}




    }


    //public void HammerHit()
    //{
    //    // Determine direction player is facing
    //    float facingDir = sr.flipX ? -1f : 1f;

    //    // Calculate point in front of player (32px ahead)
    //    Vector2 hitPosition = (Vector2)transform.position + new Vector2(facingDir * attackRange, 0f);

    //    // Check if any enemies are there
    //    Collider2D hit = Physics2D.OverlapCircle(hitPosition, 0.5f, enemyLayer);
    //    if (hit != null && hit.CompareTag("enemy"))
    //    {
    //        hit.GetComponent<screnemy>()?.TakeDamage(10);
    //        // Debug.Log("Hit skeleton in front!");
    //    }
    //    else
    //    {
    //        //Debug.Log("No skeleton in front!");
    //    }



    //    Collider2D hitb = Physics2D.OverlapCircle(hitPosition, 0.5f, ~0); // ~0 = all layers

    //    if (hitb != null && hitb.CompareTag("button"))
    //    {
    //        scrbutton btn = hitb.GetComponent<scrbutton>();
    //        if (btn != null)
    //        {
    //            btn.toggleDoor();
    //            Debug.Log("Hit button in front!");
    //        }
    //        else
    //        {
    //            Debug.Log("Button tag found, but no scrbutton script attached!");
    //        }
    //    }
    //    else
    //    {
    //        Debug.Log("No button in front!");
    //    }

    //    if (hitb != null && hitb.CompareTag("carrot"))
    //    {
    //        scrcarrot carrot = hitb.GetComponent<scrcarrot>();
    //        if (carrot != null)
    //        {
    //            carrot.openCarrot();
    //            Debug.Log("Hit carrot in front!");
    //        }

    //    }




    //}
    //// Optional: show the attack zone in Scene view
    //private void OnDrawGizmosSelected()
    //{
    //    if (sr == null) sr = GetComponent<SpriteRenderer>();
    //    float facingDir = sr.flipX ? -1f : 1f;
    //    Vector2 hitPosition = (Vector2)transform.position + new Vector2(facingDir * attackRange, 0f);

    //    Gizmos.color = Color.red;
    //    Gizmos.DrawWireSphere(hitPosition, 0.5f);
    //}


    //public void SetActionFalse()
    //{

    //    action = false;

    //}
}