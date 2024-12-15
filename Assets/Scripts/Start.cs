using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Start : MonoBehaviour
{

    [SerializeField] Button start_button;
    [SerializeField] Button exit_button;
    [SerializeField] Button control_button;
    [SerializeField] Button about_button;
    private void Awake()
    {
        start_button.onClick.AddListener(() => Load(3));
        control_button.onClick.AddListener(() => Load(1));
        about_button.onClick?.AddListener(() => Load(2));
        exit_button.onClick.AddListener(Exit);
    }

    private void Exit()
    {
        AudioManager.Instance.PlayAudioEffect(AudioTypes.ButtonClick);
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }

    private void Load(int index)
    {
        AudioManager.Instance.PlayAudioEffect(AudioTypes.ButtonClick);
        SceneManager.LoadScene(index);
    }
}
