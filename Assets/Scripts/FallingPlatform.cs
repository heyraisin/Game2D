using System.Collections;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    private float fallDelay = 1f;
    private float destroyDelay = 1f;

    [SerializeField] private Rigidbody2D rb;

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Fall());
        }
    }

    private IEnumerator Fall()
    {
        yield return new WaitForSeconds(fallDelay);
        rb.bodyType = RigidbodyType2D.Dynamic;
        Destroy(gameObject, destroyDelay);
    }
}