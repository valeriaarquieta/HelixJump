using UnityEngine;

public class BallController : MonoBehaviour
{
    public float impulseForce = 3f;

    private Rigidbody rb;
    private bool ignoreNextCollision;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if (ignoreNextCollision)
        {
            return;
        }
        GameManager.singleton.AddScore(1);

        rb.linearVelocity = Vector3.zero;
        rb.AddForce(Vector3.up * impulseForce, ForceMode.Impulse);

        ignoreNextCollision = true;
        Invoke(nameof(AllowNextCollision), 0.2f);
    }

    private void AllowNextCollision()
    {
        ignoreNextCollision = false;
    }
}