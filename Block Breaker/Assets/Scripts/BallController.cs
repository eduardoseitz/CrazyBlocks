using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] private float launchYForce = 20f;
    [SerializeField] private float launchXForce = 10f;
    [SerializeField] private AudioClip[] hitsounds;
    [SerializeField] private float minBumpTweak = 0f;
    [SerializeField] private float maxBumpTweak = -0.2f;
    [SerializeField] private float spiningSpeed = 2f;
    [SerializeField] private float minVelocity = 5f;
    [SerializeField] private float maxVelocity = 100f;

    private Transform paddle;
    private AudioSource audioSource;
    private Rigidbody2D rigidBody2D;

    private float verticalPaddleOffset;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rigidBody2D = GetComponent<Rigidbody2D>();

        paddle = FindObjectOfType<PaddleController>().gameObject.transform;

        verticalPaddleOffset = transform.position.y - paddle.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.hasBallLaunched == false)
        {
            // Follow the paddle
            transform.position = paddle.transform.position + new Vector3(0, verticalPaddleOffset, 0);

            // Launch the ball
            if (GameManager.instance.isAutoTestEnabled)
            {
                // Ai movement
                LaunchBall();
            }
            else
            {
                // Player movement
                if (Input.GetButtonDown("Fire1"))
                    LaunchBall();
            }
        }
        else
        {
            float currentVelocity = rigidBody2D.velocity.magnitude;

            // Bug fix to when ball is to slow launch again
            if (currentVelocity < minVelocity) 
            {
                rigidBody2D.AddForce(new Vector2(Random.Range(-launchXForce, launchXForce), launchYForce) * 0.5f, ForceMode2D.Impulse);
            }
            // Limit velocity
            else if (currentVelocity > maxVelocity)
            {
                float brakeSpeed = currentVelocity - maxVelocity;
                Vector2 normalisedVelocity = rigidBody2D.velocity.normalized;
                Vector2 brakeVelocity = normalisedVelocity * brakeSpeed;

                rigidBody2D.AddForce(-brakeVelocity);
            }

            // Spin star
            transform.Rotate(0, 0, rigidBody2D.velocity.magnitude * spiningSpeed, 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (GameManager.instance.hasBallLaunched)
        {
            Vector2 velocityTweak = new Vector2(Random.Range(minBumpTweak, maxBumpTweak), Random.Range(minBumpTweak, maxBumpTweak));
            rigidBody2D.velocity += velocityTweak;
            PlayRandomHitSound();
        }
    }

    private void PlayRandomHitSound()
    {
        audioSource.PlayOneShot(hitsounds[Random.Range(0, hitsounds.Length - 1)]);
    }

    private void LaunchBall()
    {
        transform.position = paddle.transform.position + new Vector3(0, verticalPaddleOffset, 0);
        transform.rotation = Quaternion.identity;

        GameManager.instance.hasBallLaunched = true;
        rigidBody2D.AddForce(new Vector2(Random.Range(-launchXForce, launchXForce), launchYForce), ForceMode2D.Impulse);
    }
}
