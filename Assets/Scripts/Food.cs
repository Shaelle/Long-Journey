using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    [SerializeField] [Range(1,100)] float amount = 25;


    private void OnTriggerEnter2D(Collider2D collision)
    {

        PlayerConditions player = collision.GetComponent<PlayerConditions>();

        if (player != null)
        {
            player.Eat(amount);
            gameObject.SetActive(false);
        }
    }

}
