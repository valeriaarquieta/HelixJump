using UnityEngine;
using UnityEngine.InputSystem;
public class BallController : MonoBehaviour
{
    public float speed = 10f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float horizontal = Keyboard.current.aKey.isPressed ? -1 :
        Keyboard.current.dKey.isPressed ? 1 : 0;

        float vertical = Keyboard.current.sKey.isPressed ? -1 :
        Keyboard.current.wKey.isPressed ? 1 : 0;

        Vector3 movement = new Vector3(horizontal, 0, vertical);

        rb.AddForce(movement * speed);
    }
}