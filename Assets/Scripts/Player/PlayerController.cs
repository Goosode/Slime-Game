using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private float speed = 0.7f;
    private float collisionOffset = 0.02f;

    public ContactFilter2D movementFilter;

    Animator animator;
    Vector2 movementInput;
    SpriteRenderer spriteRenderer;
    Rigidbody2D rb;
    List<RaycastHit2D> castCollision = new List<RaycastHit2D>();


    void Start(){
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    private void FixedUpdate(){
        //Movement && Sprint
        if(movementInput != Vector2.zero){   
            bool success = TryMove(movementInput);

            if(!success && movementInput.x > 0){
                success = TryMove(new Vector2(movementInput.x, 0));
            }
            if(!success && movementInput.y > 0){
                success = TryMove(new Vector2(0, movementInput.y));
            }
            else if(!PlayerStamina.isRunning){
                speed = 0.7f;
            }
            else if(PlayerStamina.isRunning){
                speed = 1.4f;
            }
            
        //animator
            animator.SetBool("isMoving", success);
        } 
        else {
            animator.SetBool("isMoving", false);
        }

        //Animation position
        if(movementInput.x < 0){
            spriteRenderer.flipX = true;
        } 
        else if(movementInput.x > 0){
            spriteRenderer.flipX = false;
        }
    }


    private bool TryMove(Vector2 direction){   
        if(direction != Vector2.zero){
            int count = rb.Cast(
                direction,
                movementFilter,
                castCollision,
                speed * Time.fixedDeltaTime + collisionOffset);

            if(count == 0){
                rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);
                return true;
            } else {
                return false;
            }
        } else {
            return false;
        }
    }


    void OnMove(InputValue movementValue){
        movementInput = movementValue.Get<Vector2>();
    }
}