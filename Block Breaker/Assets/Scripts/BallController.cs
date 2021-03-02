using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] private Vector2 launchForce;
    [SerializeField] private Transform paddle;
    [SerializeField] private AudioClip[] hitsounds;
    [SerializeField] private float maxSpeed = 5f;
    [SerializeField] private float randomFactor = 0.2f;

    private float verticalPaddleOffset;

    private AudioSource audioSource;
    private Rigidbody2D rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rigidBody = GetComponent<Rigidbody2D>();

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
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (GameManager.instance.hasLaunched)
        {
            Vector2 velocityTweak = new Vector2(Random.Range(0.1f, randomFactor), Random.Range(0.1f, randomFactor));
            rigidBody.velocity -= velocityTweak;
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
        rigidBody.AddForce(launchForce, ForceMode2D.Impulse);
    }
}
