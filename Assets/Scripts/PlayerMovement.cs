using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{

    Rigidbody2D body;

    [SerializeField] [Range(1, 100)] float speed = 3;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
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
