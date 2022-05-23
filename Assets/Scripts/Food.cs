using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Food : MonoBehaviour
{
    [SerializeField] [Range(1,100)] float amount = 25;

    [SerializeField] [Range(0, 50)] float minTimer = 5;
    [SerializeField] [Range(0, 50)] float maxTimer = 30;

    [SerializeField] bool singleTimeUse = false;

    float timer = 0;

    new SpriteRenderer renderer;

    private void Awake()
    {
        renderer = GetComponent<SpriteRenderer>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (renderer.enabled)
        {
            PlayerConditions player = collision.GetComponent<PlayerConditions>();

            if (player != null)
            {
                player.Eat(amount);

                if (singleTimeUse) gameObject.SetActive(false);
                else StartCoroutine(Timer());              
            }
        }
    }


    IEnumerator Timer()
    {
        renderer.enabled = false;
        yield return new WaitForSeconds(Random.Range(minTimer, maxTimer));
        renderer.enabled = true;
    }

}
