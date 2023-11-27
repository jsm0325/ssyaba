using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowMiddlePosition : MonoBehaviour
{
    public int range = 5;
    public float speed = 0.1f;
    private int direction = 1;

    void Update()
    {
        if(transform.position.x > range)
        {
            direction = -1;
        }
        else if (transform.position.x < -range)
        {
            direction = 1;
        }

        transform.Translate(direction * speed, 0, 0);
         
    }
}
