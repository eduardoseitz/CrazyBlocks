using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] private Vector2 launchForce;
    [SerializeField] private Transform paddle;

    private float verticalPaddleOffset;
    private bool launched;

    // Start is called before the first frame update
    void Start()
    {
        verticalPaddleOffset = transform.position.y - paddle.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (launched == false)
        {
            // Follow the paddle
            transform.position = paddle.transform.position + new Vector3(0, verticalPaddleOffset, 0);

            // Launch the ball
            if (Input.GetButtonDown("Fire1"))
                LaunchBall();
        }
    }

    private void LaunchBall()
    {
        launched = true;
        GetComponent<Rigidbody2D>().AddForce(launchForce, ForceMode2D.Impulse);
    }
}
