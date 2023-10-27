using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    private Animator anim;
    public static bool god = false;
    [SerializeField] public LayerMask jumpableGround;
    private float dirX = 0f;
    private bool canControl = true;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 12f;
    private enum MovementState {idle, running, jumping, falling };

    [SerializeField] private AudioSource jumpSoundEffect;
    [SerializeField] private AudioSource swipeSound;
    [SerializeField] private AudioSource slashSound;
    [SerializeField] private AudioSource walkingSound;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        if(canControl){
             rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
        }

        if(Input.GetButtonDown("Jump") && isGrounded() && canControl){
            jumpSoundEffect.Play();
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

         if(Input.GetMouseButtonDown(0) && isGrounded() && canControl){
            Swipe();
        }
        
        if(Input.GetMouseButtonDown(1)&& isGrounded() & canControl){
            Slash();
        }

        if(Input.GetKeyDown("g") && !god){
            god = true;
            jumpForce += 15;
            moveSpeed += 5;
        }
        else if(Input.GetKeyDown("g") && god){
            god = false;
            jumpForce -= 15;
            moveSpeed -= 5;
        }

        if(rb.bodyType != RigidbodyType2D.Static) UpdateAnimationState();
    }

    private void UpdateAnimationState(){
        MovementState state;

        if(dirX > 0f){
            state = MovementState.running;
            sprite.flipX = false;
        }
        else if(dirX < 0f){
            state = MovementState.running;
            sprite.flipX = true;
        }
        else{
            state = MovementState.idle;
        }

        if(rb.velocity.y > .1f){
            state = MovementState.jumping;
        }
        else if(rb.velocity.y < -.1f){
            state = MovementState.falling;
        }

        anim.SetInteger("State", (int)state);
    }

    private bool isGrounded(){
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }

    private void Swipe(){
        canControl = false;
        anim.SetBool("Swipe", true);
        swipeSound.Play();
    }

    private void stopSwipe(){
        anim.SetBool("Swipe", false);
        canControl = true;
    }

    private void Slash(){
        canControl = false;
        anim.SetBool("Slash", true);
        slashSound.Play();
    }

    private void stopSlash(){
        anim.SetBool("Slash", false);
        canControl = true;
    }

    private void playWalking(){
        walkingSound.Play();
    }
}
