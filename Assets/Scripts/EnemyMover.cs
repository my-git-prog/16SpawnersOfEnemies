using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _speed = 3f;

    private Vector3 _direction;

    private void Update()
    {
        transform.Translate(_direction * _speed * Time.deltaTime, Space.World);
    }

    public void SetDirection(Vector3 direction)
    {
        _direction = direction;
        transform.LookAt(transform.position + direction);
    }
}
