using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Control : MonoBehaviour
{
    [SerializeField] Button back_button;

    private void Awake()
    {
        back_button.onClick.AddListener(Back);
    }

    private void Back()
    {
        SceneManager.LoadScene(0);
    }
}
