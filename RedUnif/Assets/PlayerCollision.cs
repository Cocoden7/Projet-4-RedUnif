using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("vide"))
        {
            print("Chute");
            //dead = true;
        }

        if (col.gameObject.CompareTag("glue"))
        {
            print("Glue collision");
        }
    }
}
