using System.Collections;
using System.Collections.Generic;
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


    private void FixedUpdate()
    {
        _targetPosition = _target.position;
        _targetPosition -= _target.forward * _distance;
        _targetPosition += Vector3.up * _height;
        _targetPosition += _target.right * _offest;
        transform.position = Vector3.Lerp(transform.position, _targetPosition, _moveSpeed * Time.deltaTime);

        var targetRotation = Quaternion.LookRotation(_target.forward, Vector3.up);
        targetRotation.eulerAngles = new Vector3(_lookAngle, targetRotation.eulerAngles.y + _lookAngleY, targetRotation.eulerAngles.z);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);
    }
}
