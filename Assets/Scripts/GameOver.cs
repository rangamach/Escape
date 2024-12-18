using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    [SerializeField] private Canvas canvas;
    [SerializeField] private Button restart;
    [SerializeField] private Button exit;

    private void Awake()
    {
        restart.onClick.AddListener(() => LoadLevel(SceneManager.GetActiveScene().buildIndex));
        exit.onClick.AddListener(() => LoadLevel(3));
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0;
            canvas.gameObject.SetActive(true);
        }
    }

    private void LoadLevel(int index)
    {
        AudioManager.Instance.PlayAudioEffect(AudioTypes.ButtonClick);
        if(index != 3)
            AudioManager.Instance.PlayAudioEffect(AudioTypes.Resume);
        Time.timeScale = 1;
        SceneManager.LoadScene(index);
    }

    private void Resume()
    {
        AudioManager.Instance.PlayAudioEffect(AudioTypes.ButtonClick);
        AudioManager.Instance.PlayAudioEffect(AudioTypes.Resume);
        Time.timeScale = 1;
        canvas.gameObject.SetActive(false);
    }
}
