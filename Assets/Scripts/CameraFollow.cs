using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    private Vector3 offset;

    void Start()
    {
        offset = transform.position - target.position;
    }

    void LateUpdate()
    {
        transform.position = new Vector3(
            target.position.x + offset.x,
            transform.position.y,
            target.position.z + offset.z
        );
    }
}