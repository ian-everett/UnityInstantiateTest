using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private static int count;
    private int id;


    private void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        float gravity = Random.Range(0.01f, 0.1f);
        float rotation = Random.Range(0, 360);

        rb.rotation = rotation;
        rb.gravityScale = gravity;
        id = count++;
        Debug.Log("Created " + id + " with gravity:" + gravity);
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Floor")
        {
            if (count > 0)
                count--;

            Debug.Log("Enemy Destroyed:" + id + " Remaining:" + count);

            Destroy(gameObject);
        }
    }
}
