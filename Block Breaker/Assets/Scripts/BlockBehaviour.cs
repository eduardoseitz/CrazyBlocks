using UnityEngine;

public class BlockBehaviour : MonoBehaviour
{
    [SerializeField] private Sprite brokenSprite;
    [SerializeField] private AudioClip brokenAudio;

    private bool hasBeenHit;

    private void Start()
    {
        GameManager.instance.blocksRemaining++;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!hasBeenHit)
        {
            DamageBlock();
        }
        else
        {
            DestroyBlock();
        }
    }

    private void DamageBlock()
    {
        GetComponent<SpriteRenderer>().sprite = brokenSprite;
        AudioSource.PlayClipAtPoint(brokenAudio, Camera.main.transform.position, 0.3f);
        hasBeenHit = true;
    }

    private void DestroyBlock()
    {
        GameManager.instance.ScoreBlock();
        Destroy(gameObject);
    }
}
