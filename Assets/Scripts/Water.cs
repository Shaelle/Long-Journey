using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerConditions player = collision.GetComponent<PlayerConditions>();

        if (player != null)
        {
            player.Drink();
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        PlayerConditions player = collision.GetComponent<PlayerConditions>();

        if (player != null)
        {
            player.StopDrink();
        }
    }
}
