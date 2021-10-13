using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateEnemies : MonoBehaviour
{
    public GameObject EnemyPrefab;
    private List<GameObject> EnemyList = new List<GameObject>();

    private int Wave { get; set; }

    void Start()
    {
        Wave = 1;

        /*
         * Start with spawn of enemies
         */
        SpawnEnemies(Wave);
    }

    private void SpawnEnemies(int wave)
    {
        int n_enemies = wave * 5;

        for (int i = 0; i < n_enemies; i++)
        {
            float x_pos = Random.Range(-10, 10);
            EnemyList.Add(Instantiate(EnemyPrefab, new Vector2(x_pos, 5.0f), Quaternion.identity));
        }
    }

    private void Update()
    {
        if (Enemy.Count == 0)
        {
            /*
             * Clear list
             */
            EnemyList.Clear();

            /*
             * Re-spawn next wave of enemies
             */
            SpawnEnemies(++Wave);
        }
    }


    private void RemoveEnemies()
    {
        foreach (GameObject go in EnemyList)
        {
            Destroy(go);
        }
        Debug.Log("Destory all enemies");
    }
}
