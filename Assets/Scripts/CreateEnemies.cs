using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateEnemies : MonoBehaviour
{
    public GameObject Object;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 25; i++)
        {
            float x_pos = Random.Range(-10, 10);
            Instantiate<GameObject>(Object, new Vector2(x_pos, 5.0f), Quaternion.identity);
        }
    }
}
