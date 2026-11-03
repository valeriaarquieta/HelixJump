using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    private float offset;

    void Start()
    {
        offset = transform.position.y - target.position.y;
    }

    void Update()
    {
       Vector3 actualPos = transform.position;
       actualPos.y = target.transform.position.y + offset;
       transform.position = actualPos;
    }
}