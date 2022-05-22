using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyMovement : MonoBehaviour
{
    Rigidbody2D body;

    [SerializeField] [Range(0,20)] float minTimer = 3;
    [SerializeField] [Range(1, 30)] float maxTimer = 10;

    [SerializeField] [Range(1, 40)] float forceMagnitude = 15;

    [SerializeField] [Range(0, 1)] float velocityThreshold = 0.01f;

    float delay;
    float timer;


    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }


    // Start is called before the first frame update
    void Start()
    {
        delay = Random.Range(minTimer, maxTimer);
        timer = delay;

        SetDirection();
    }


    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
        {
            if (body.velocity.magnitude < velocityThreshold)
            {
                timer = delay;
                SetDirection();
            }
            timer -= Time.deltaTime;
        }
        else
        {
            timer = delay;
            SetDirection();
        }
    }


    void SetDirection()
    {

        Vector2 force = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        
        force *= forceMagnitude;

        body.velocity = force;
    }
}
