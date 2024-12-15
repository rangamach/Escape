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
        Time.timeScale = 1;
        SceneManager.LoadScene(index);
    }

    private void Resume()
    {
        Time.timeScale = 1;
        canvas.gameObject.SetActive(false);
    }
}
