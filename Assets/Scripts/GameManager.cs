using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class GameManager : MonoBehaviour
{
    [SerializeField] private string _scene;
    [SerializeField] private Button _restart;
    [SerializeField] private Slider _speed;
   
    
    public event Action<float> ChangeSpeed;
    private void Awake()
    {
        _restart.onClick.AddListener(() => LoadScene());
        _speed.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
    }
    private void Start()
    {
        if (PlayerPrefs.HasKey("speed"))
            _speed.value = PlayerPrefs.GetFloat("speed");
        ValueChangeCheck();
    }
    private void LoadScene()
    {
        SceneManager.LoadScene(_scene);
    }
    private void ValueChangeCheck()
    {
        ChangeSpeed?.Invoke(_speed.value);
        PlayerPrefs.SetFloat("speed", _speed.value);
    }

}
