using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnersManager : MonoBehaviour
{
    [SerializeField] private List<EnemySpawner> _spawners;
    [SerializeField] private bool _isSpawning = true;
    [SerializeField] private float _spawnDeltaTime = 2f;

    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        var wait = new WaitForSeconds(_spawnDeltaTime);

        while (_isSpawning)
        {
            GetRandomSpawner().SpawnEnemy();
            yield return wait;
        }

        yield break;
    }

    private EnemySpawner GetRandomSpawner()
    {
        return _spawners[Random.Range(0, _spawners.Count)];
    }
}
