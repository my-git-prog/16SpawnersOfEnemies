using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _speed = 3f;

    private TargetMover _target;

    private void Update()
    {
        Rotate();
        Move();
    }

    private void Rotate()
    {
        transform.LookAt(_target.transform.position);
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target.transform.position, _speed * Time.deltaTime);
    }

    public void SetTarget(TargetMover target)
    {
        _target = target;
    }
}
