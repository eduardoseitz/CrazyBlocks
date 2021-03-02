using UnityEngine;

public class BlockBehaviour : MonoBehaviour
{
    [SerializeField] private Sprite brokenSprite;
    [SerializeField] private AudioClip brokenAudio;
    [SerializeField] private GameObject blockParticleVFX;

    [SerializeField] private int hitPoints;

    private void Start()
    {
        if (gameObject.CompareTag("Breakable"))
            GameManager.instance.blocksRemaining++;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        AudioSource.PlayClipAtPoint(brokenAudio, Camera.main.transform.position, 0.3f);

        if (gameObject.CompareTag("Breakable"))
        {
            DamageBlock();
        }
    }

    private void DamageBlock()
    {
        GetComponent<SpriteRenderer>().sprite = brokenSprite;
        
        hitPoints--;
        if (hitPoints <= 0)
            DestroyBlock();

    }

    private void DestroyBlock()
    {
        GameManager.instance.ScoreBlock();
        Instantiate(blockParticleVFX, transform.position, transform.rotation);
        Destroy(gameObject, 0.1f);
    }
}
