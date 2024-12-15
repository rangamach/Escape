using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    private string str1;
    private string str2;
    private int cnt;

    [SerializeField] private Player player;
    [SerializeField] private TextMeshProUGUI text;
    private void Awake()
    {
        text.text = "WASD or Arrow Keys to\r\nMove Around\r\nEscape to Pause\r\n\r\nPress Enter";
        str1 = "Get all the Keys to Open the Exit\r\n\r\nPress Enter";
        str2 = "Avoid hitting the \r\npatrolling guards.\r\n\r\nPress Enter";
        cnt = 0;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if(cnt == 0)
            {
                text.text = str1;
            }
            else if(cnt == 1)
            {
                text.text = str2;
            }
            else if(cnt == 2)
            {
                player.GetComponent<Player>().enabled = true;
                Destroy(this.gameObject);
            }
            cnt++;
            AudioManager.Instance.PlayAudioEffect(AudioTypes.ButtonClick);
        }
    }

}
