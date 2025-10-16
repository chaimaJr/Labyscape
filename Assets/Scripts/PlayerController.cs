using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    private Rigidbody2D rb;
    public bool action = false;

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

    }


}