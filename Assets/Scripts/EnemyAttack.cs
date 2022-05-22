using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] [Range(0.01f, 1)] float minDamage = 0.1f;
    [SerializeField] [Range(0.01f, 1)] float maxDamage = 0.8f;

    float damage;

    // Start is called before the first frame update
    void Start()
    {
        damage = Random.Range(minDamage, maxDamage);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        PlayerConditions player = collision.GetComponent<PlayerConditions>();

        if (player != null)
        {
            player.AddDamage(damage);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        PlayerConditions player = collision.GetComponent<PlayerConditions>();

        if (player != null)
        {
            player.RemoveDamage(damage);
        }
    }
}
