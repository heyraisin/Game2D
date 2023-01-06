using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int food = 0;
    [SerializeField] private Text foodText;
    [SerializeField] private AudioSource jumpSoundEffect;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Food"))
        {
            jumpSoundEffect.Play();
            Destroy(collision.gameObject);
            food++;
            foodText.text = "" + food;
        }   
    }

    public int getNumberOfFood()
    {
        return food;
    }
}
