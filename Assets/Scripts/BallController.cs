using Unity.VisualScripting;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float impulseForce = 3f;

    private Rigidbody rb;
    private bool ignoreNextCollision;
    private Vector3 startPosition;
    [HideInInspector]
    public int perfectPass;
    private int perfectPassCount = 3;
    public float superSpeed;
    public bool isSuperSpeedActive;

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

        if (isSuperSpeedActive && !collision.transform.GetComponent<GoalController>())
        {
          Destroy(collision.transform.parent.gameObject,0.2f);  
        } else
        {
            //GameManager.singleton.AddScore(1);
            DeathPart deathPart = collision.transform.GetComponent<DeathPart>();
            if (deathPart)
                {
                    GameManager.singleton.RestartLevel();
                }
        }

        rb.linearVelocity = Vector3.zero;
        rb.AddForce(Vector3.up * impulseForce, ForceMode.Impulse);

        ignoreNextCollision = true;
        Invoke(nameof(AllowNextCollision), 0.2f);
        perfectPass =0;
        isSuperSpeedActive= false;
    }

    private void Update()
    {
       if (perfectPass>=perfectPassCount && !isSuperSpeedActive)
       {
        isSuperSpeedActive = true;

        rb.AddForce(Vector3.down*superSpeed,ForceMode.Impulse);
       } 
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