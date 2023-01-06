using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gator : MonoBehaviour
{
    private float destroyDelay = 0.65f;

    [SerializeField] private Animator animator;
    [SerializeField] private Player player;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !player.IsGrounded())
        {
            animator.SetBool("IsDeath", true);
            Destroy(gameObject, destroyDelay);
        }
    }
}
