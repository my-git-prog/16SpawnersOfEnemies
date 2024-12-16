using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private EnemyMover _enemyPrefab;
    [SerializeField] private List<GameObject> _spawnPoints;
    [SerializeField] private bool _isSpawning = true;
    [SerializeField] private float _spawnDeltaTime = 2f;

    [SerializeField] private float _minDirectionX = -1f;
    [SerializeField] private float _maxDirectionX = 1f;
    [SerializeField] private float _minDirectionZ = -1f;
    [SerializeField] private float _maxDirectionZ = 1f;

    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        var wait = new WaitForSeconds(_spawnDeltaTime);

        while (_isSpawning)
        {
            EnemyMover newEnemy = Instantiate(_enemyPrefab, GetRandomSpawnPosition(), Quaternion.identity);
            newEnemy.SetDirection(GetRandomMovingDirection());
            yield return wait;
        }

        yield break;
    }

    private Vector3 GetRandomSpawnPosition()
    {
        return _spawnPoints[Random.Range(0, _spawnPoints.Count)].transform.position;
    }
        private Vector3 GetRandomMovingDirection()
    {
        return new Vector3(Random.Range(_minDirectionX, _maxDirectionX), 0f, Random.Range(_minDirectionZ, _maxDirectionZ)).normalized;
    }
}
