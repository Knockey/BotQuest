using UnityEngine;

public class InteractionCircleRotation : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed;

    private void Update()
    {
        transform.Rotate(_rotationSpeed * Time.deltaTime * Vector3.forward);
    }
}
