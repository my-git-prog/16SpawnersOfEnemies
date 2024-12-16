using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private const float FullCircleDegrees = 360f;

    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private List<GameObject> _spawnPoints;
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
            Instantiate(_enemyPrefab, GetRandomSpawnPosition(), GetRandomSpawnRotation());
            yield return wait;
        }

        yield break;
    }

    private Vector3 GetRandomSpawnPosition()
    {
        return _spawnPoints[Random.Range(0, _spawnPoints.Count - 1)].transform.position;
    }

    private Quaternion GetRandomSpawnRotation()
    {
        return Quaternion.Euler(0f, Random.Range(0f, FullCircleDegrees), 0f);
    }
}
