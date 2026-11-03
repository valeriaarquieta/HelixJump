using UnityEngine;

public class HelixController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Vector3 startPosition;
    private Vector2 lastTapPosition;
    void Start()
    {
       startPosition = transform.localEulerAngles; 
    }

    // Update is called once per frame
    void Update()
{
    if (Input.GetMouseButton(0))
    {
        Vector2 currentTapPosition = Input.mousePosition;

        if (lastTapPosition == Vector2.zero)
        {
            lastTapPosition = currentTapPosition;
        }

        float distance = lastTapPosition.x - currentTapPosition.x;
        lastTapPosition = currentTapPosition;
    }
}
}
