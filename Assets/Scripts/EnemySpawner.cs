using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private EnemyMover _enemyPrefab;
    [SerializeField] private TargetMover _target;

    public void SpawnEnemy()
    {
        EnemyMover newEnemy = Instantiate(_enemyPrefab, transform.position, Quaternion.identity);
        newEnemy.SetTarget(_target);
    }
}
