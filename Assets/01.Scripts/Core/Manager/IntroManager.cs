using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class IntroManager : MonoBehaviour
{
    public GameObject _light;
    public GameObject settingPanel;

    public GameObject explainPanel;

    private Button explain;
    private Button setting;
    private Button gameStart;
    private Button exit;
    private AudioSource audioSource;
    private void Awake()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;

        explain = root.Q<Button>("explain");
        setting = root.Q<Button>("setting");
        gameStart = root.Q<Button>("gameStart");
        exit = root.Q<Button>("exit");

        explain.RegisterCallback<ClickEvent>(Explain);
        setting.RegisterCallback<ClickEvent>(Setting);
        gameStart.RegisterCallback<ClickEvent>(GameStart);
        exit.RegisterCallback<ClickEvent>(Exit);

        Off_Panel();
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        Show();
    }
    public void Cancel_Expian()
    {
        explainPanel.SetActive(false);
    }
    public void BG_Sound(float value)
    {
        audioSource.volume = value;
    }
    public void Off_Panel()
    {
        settingPanel.SetActive(false);
    }
    public void Exit()
    {
        Application.Quit();
    }
    private void Exit(ClickEvent evt)
    {
        Application.Quit();
    }

    private void Hiden()
    {
        explain.RemoveFromClassList("button-show");
        setting.RemoveFromClassList("button-show");
        gameStart.RemoveFromClassList("button-show");
        exit.RemoveFromClassList("button-show");
    }
    private void Show()
    {
        explain.AddToClassList("button-show");
        setting.AddToClassList("button-show");
        gameStart.AddToClassList("button-show");
        exit.AddToClassList("button-show");
    }
    private void GameStart(ClickEvent evt)
    {
        SceneManager.LoadScene(1);
    }

    private void Setting(ClickEvent evt)
    {
        settingPanel.SetActive(true);
    }

    private void Explain(ClickEvent evt)
    {
        explainPanel.SetActive(true);
    }

    private void Update()
    {
        float angle = Time.deltaTime * 10f;
        _light.transform.Rotate(new Vector3(angle, 0, 0));
    }
}
