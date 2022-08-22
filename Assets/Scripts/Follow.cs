using UnityEngine;

public class Follow : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotationSpeed;
    [Space(15)]
    [SerializeField] private float _height;
    [SerializeField] private float _distance;
    [SerializeField] private float _offest;
    [SerializeField] private float _lookAngle;
    [SerializeField] private float _lookAngleY;

    private Vector3 _targetPosition;

    private void LateUpdate()
    {
        Move();
        Rotate();
    }

    private void Move()
    {
        _targetPosition = GetTargetPosition();
        transform.position = Vector3.Lerp(transform.position, _targetPosition, _moveSpeed * Time.deltaTime);
    }

    private Vector3 GetTargetPosition()
    {
        Vector3 targetPosition = _target.position;
        targetPosition -= _target.forward * _distance;
        targetPosition += Vector3.up * _height;
        targetPosition += _target.right * _offest;

        return targetPosition;
    }

    private void Rotate()
    {
        var targetRotation = Quaternion.LookRotation(_target.forward, Vector3.up);
        targetRotation.eulerAngles = new Vector3(_lookAngle, targetRotation.eulerAngles.y + _lookAngleY, targetRotation.eulerAngles.z);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);
    }
}
