using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject Enemy;

    void Start()
    {
        StartCoroutine(Spawner());
    }

    IEnumerator Spawner()
    {
        Instantiate(Enemy, new Vector3(800, 0, Random.Range(-500, 500)), Quaternion.identity);
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(Spawner());
    }
}
