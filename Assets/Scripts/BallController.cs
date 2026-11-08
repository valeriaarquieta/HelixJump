using Unity.VisualScripting;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float impulseForce = 3f;

    private Rigidbody rb;
    private bool ignoreNextCollision;
    private Vector3 startPosition;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startPosition = transform.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if (ignoreNextCollision)
        {
            return;
        }
        //GameManager.singleton.AddScore(1);
        DeathPart deathPart = collision.transform.GetComponent<DeathPart>();
        if (deathPart)
        {
            GameManager.singleton.RestartLevel();
        }

        rb.linearVelocity = Vector3.zero;
        rb.AddForce(Vector3.up * impulseForce, ForceMode.Impulse);

        ignoreNextCollision = true;
        Invoke(nameof(AllowNextCollision), 0.2f);
    }

    private void AllowNextCollision()
    {
        ignoreNextCollision = false;
    }
    public void ResetBall()
    {
        transform.position = startPosition;
    }
}