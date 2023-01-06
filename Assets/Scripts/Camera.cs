using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] GameObject player;

    private void LateUpdate()
    {
        transform.position = new Vector3(player.transform.position.x + 9, player.transform.position.y + 3, transform.position.z);
    }
}