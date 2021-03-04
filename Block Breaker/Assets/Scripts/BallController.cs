using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] private float launchYForce = 20f;
    [SerializeField] private float launchXForce = 10f;
    [SerializeField] private AudioClip[] hitsounds;
    [SerializeField] private float minVelocityVector = 0f;
    [SerializeField] private float maxVelocityVector = -0.2f;
    [SerializeField] private float spiningSpeed = 2f;
    
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
        if (GameManager.instance.hasLaunched == false)
        {
            // Follow the paddle
            transform.position = paddle.transform.position + new Vector3(0, verticalPaddleOffset, 0);

            // Launch the ball
            if (Input.GetButtonDown("Fire1"))
                LaunchBall();
        }

        // Spin star
        transform.Rotate(0, 0, rigidBody2D.velocity.magnitude * spiningSpeed, 0);   
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (GameManager.instance.hasLaunched)
        {
            Vector2 velocityTweak = new Vector2(Random.Range(minVelocityVector, maxVelocityVector), Random.Range(minVelocityVector, maxVelocityVector));
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
        GameManager.instance.hasLaunched = true;
        rigidBody2D.AddForce(new Vector2(Random.Range(-launchXForce, launchXForce), launchYForce), ForceMode2D.Impulse);
    }
}
