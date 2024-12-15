using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Levels : MonoBehaviour
{
    [SerializeField] private Button tutorial;
    [SerializeField] private Button easy;
    [SerializeField] private Button medium;
    [SerializeField] private Button hard;
    [SerializeField] private Button back;
  
    private void Awake()
    {
        tutorial.onClick.AddListener(() => LoadLevel(4));
        easy.onClick.AddListener(() => LoadLevel(5));
        medium.onClick.AddListener(() => LoadLevel(6));
        hard.onClick.AddListener(() => LoadLevel(7));
        back.onClick.AddListener(Back);
    }

    private void Back()
    {
        AudioManager.Instance.PlayAudioEffect(AudioTypes.ButtonClick);
        SceneManager.LoadScene(0);
    }

    private void LoadLevel(int level)
    {
        AudioManager.Instance.PlayAudioEffect(AudioTypes.ButtonClick);
        SceneManager.LoadScene(level);
    }
}
