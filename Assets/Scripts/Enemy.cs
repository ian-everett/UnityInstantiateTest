using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    /*
     * Keep track of number of enemies
     */
    public static int Count { get; private set; } = 0;
    private int Id { get; set; }

    /*
     * Cerate a structure to define enemy sizes
     */
    readonly private struct Attr
    {
        public Attr(float scale, float mass)
        {
            this.Scale = scale;
            this.Mass = mass;
        }

        public float Scale { get; }
        public float Mass { get; }
    }

    /*
     * Create 3 sizes of enemy
     */
    private Attr[] _attr =
    {
        new Attr(0.5f, 1.0f),
        new Attr(1.0f, 2.0f),
        new Attr(1.5f, 3.0f),
    };


    private void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        float gravity = Random.Range(0.01f, 0.1f);
        float rotation = Random.Range(0.0f, 10.0f);

        /*
         * Set randomly set rotation and gravity 
         */
        rb.MoveRotation(rotation);
        rb.gravityScale = gravity;

        /*
         * Get type of our enemy
         */
        int type = Random.Range(0, _attr.Length);
        Attr attr = _attr[type];

        /*
         * Set enemy size and mass match
         */
        transform.localScale = new Vector2(attr.Scale, attr.Scale);
        rb.mass = (attr.Mass * attr.Mass);

        Id = Count++;
        Debug.Log("Created " + Id);
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Floor")
        {
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        if (Count > 0)
        {
            Count--;
        }

        //Debug.Log("Enemy Destroyed:" + Id + " Remaining:" + Count);
    }
}
