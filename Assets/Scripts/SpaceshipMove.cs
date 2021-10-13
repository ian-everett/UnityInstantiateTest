using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipMove : MonoBehaviour
{
    public float speed = 10f;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.AddForce(Vector2.right * speed);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {   
            rb.AddForce(Vector2.left * speed);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * speed, ForceMode2D.Force);
        }

        Vector2 pos = transform.position;
        if (pos.y < -4)
        {
            pos.y = -4;
        }
        transform.position = pos;
    }
}
