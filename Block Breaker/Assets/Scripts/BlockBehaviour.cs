using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockBehaviour : MonoBehaviour
{
    [SerializeField] private Sprite brokenSprite;
    [SerializeField] private AudioClip brokenAudio;

    private bool hasBeenHit;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!hasBeenHit)
        {
            GetComponent<SpriteRenderer>().sprite = brokenSprite;
            //AudioSource.PlayClipAtPoint(brokenAudio, transform.position);
            hasBeenHit = true;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
