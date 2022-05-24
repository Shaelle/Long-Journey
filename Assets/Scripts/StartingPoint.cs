using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingPoint : MonoBehaviour
{
    [SerializeField] Vector2[] points;

    // Start is called before the first frame update
    void Start()
    {
        if (points.Length > 0)
        {
            Vector2 pos = points[Random.Range(0, points.Length)];
            gameObject.transform.position = pos;
        }
    }


}
