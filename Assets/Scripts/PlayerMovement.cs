using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class PlayerMovement : MonoBehaviour
{

    Rigidbody2D body;
    Animator animator;

    [SerializeField] [Range(1, 100)] float speed = 3;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Move(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed || context.phase == InputActionPhase.Canceled)
        {
            
            Vector2 temp = context.ReadValue<Vector2>();
            body.velocity = temp * speed;
            // body.AddForce(temp * 10);

            animator.SetFloat("Horizontal", temp.x);
            animator.SetFloat("Vertical", temp.y);
            animator.SetFloat("Speed", temp.sqrMagnitude);

       
        }
    }


    public void Jump(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            Debug.Log("jump");
        }
    }
}
