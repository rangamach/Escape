using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<Player>())
        {
            Player player = collision.GetComponent<Player>();
            Debug.Log("Key - " + player.key_collected);
            player.key_collected = true;
            Debug.Log("Key - " + player.key_collected);
            Destroy(this.gameObject);
        }
    }
}
