using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float _constYPosition, _constZPosition;
    [SerializeField] private float _additionalXPosition;
    [SerializeField] private Transform _target;
    [SerializeField] private float _speed;

    private void Update()
    {
        Vector3 targetPosition = _target.position;

        targetPosition.z = _constZPosition;
        targetPosition.y = _constYPosition;
        targetPosition.x += _additionalXPosition;

        transform.position = Vector3.Lerp(transform.position, targetPosition, _speed * Time.deltaTime);
    }
}
