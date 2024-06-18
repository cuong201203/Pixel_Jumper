using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D col;
    private Animator anim;
    private float dirx = 0f;
    private SpriteRenderer sprite;
    [SerializeField] private float movespeed = 8f;
    [SerializeField] private float jumpforce = 9f;
    [SerializeField] private LayerMask jumpableGround;
    private enum MovementState { idle, running, jumping, falling }
    [SerializeField] private AudioSource Jumpaffect;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        dirx = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirx * movespeed, rb.velocity.y);
        if (Input.GetButtonDown("Jump") && isGrounded())
        {
            Jumpaffect.Play();
            GetComponent<Rigidbody2D>().velocity = new Vector3(rb.velocity.x, jumpforce);
        }
        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        MovementState state;
        if (dirx > 0f) // Nếu sang phải
        {
            state = MovementState.running;
            sprite.flipX = false; // Không lật ảnh
        }
        else if (dirx < 0f)
        {
            state = MovementState.running;
            sprite.flipX = true;
        }
        else state = MovementState.idle;

        // Vận tốc trục y dương
        if (rb.velocity.y > .1f) state = MovementState.jumping;
        // Vận tốc trụ y âm
        else if (rb.velocity.y < -.1f) state = MovementState.falling;
        // Thiết lập trạng thái hoạt ảnh dựa trên trạng thái hiện tại của nhân vật
        anim.SetInteger("state", (int)state);
    }

    private bool isGrounded()
    {
        return Physics2D.BoxCast(col.bounds.center, col.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}
