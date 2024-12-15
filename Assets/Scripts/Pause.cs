using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    [SerializeField] private Canvas canvas_pause;
    [SerializeField] private Canvas canvas_go;
    [SerializeField] private Canvas canvas_lo;
    [SerializeField] private Button resume;
    [SerializeField] private Button restart_pause;
    [SerializeField] private Button exit_pause;
    [SerializeField] private Button restart_go;
    [SerializeField] private Button exit_go;
    [SerializeField] private Button restart_lo;
    [SerializeField] private Button exit_lo;

    private void Awake()
    {
        restart_pause.onClick.AddListener(() => LoadLevel(SceneManager.GetActiveScene().buildIndex));
        exit_pause.onClick.AddListener(() => LoadLevel(3));
        resume.onClick.AddListener(Resume);
        restart_go.onClick.AddListener(() => LoadLevel(SceneManager.GetActiveScene().buildIndex));
        exit_go.onClick.AddListener(() => LoadLevel(3));
        restart_lo.onClick.AddListener(() => LoadLevel(SceneManager.GetActiveScene().buildIndex));
        exit_lo.onClick.AddListener(() => LoadLevel(3));
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0;
            canvas_pause.gameObject.SetActive(true);
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
        canvas_pause.gameObject.SetActive(false);
    }

    public void EnableGameOverCanvas()
    {
        canvas_go.gameObject.SetActive(true);
    }

    public void EnableLevelOverCanvas()
    {
        canvas_lo.gameObject.SetActive(true);
    }
}
