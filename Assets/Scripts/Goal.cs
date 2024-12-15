using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Player>())
        {
            collision.gameObject.GetComponent<Animator>().SetFloat("Speed", 0.0f);
            collision.gameObject.GetComponent<Player>().enabled = false;
            collision.gameObject.GetComponent<Pause>().EnableLevelOverCanvas();
            AudioManager.Instance.PlayAudioEffect(AudioTypes.LevelComplete);
        }
    }
}
