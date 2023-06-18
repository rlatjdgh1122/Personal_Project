using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{
    public static LevelController Instance;
    private Slider _silder;
    private TextMeshProUGUI txt;

    private int currentLevel = 1;
    public int Exp = 100;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else Destroy(this);

        txt = transform.Find("LevelText").GetComponent<TextMeshProUGUI>();
        _silder = GetComponent<Slider>();
    }
    void Start()
    {
        _silder.maxValue = Exp;
        _silder.value = 0;

        txt.text = "LEVEL : " + currentLevel.ToString();
    }
    private int sum = 0;
    public void SetLevelValue(int value)
    {
        sum += value;
        _silder.value = sum;
        if (_silder.value >= Exp)
        {
            sum -= Exp;
            currentLevel += 1;
            GameManager.Instance.ui_Controller.weaponUI.Open_Panel();
        }
        _silder.value = sum;
        txt.text = "LEVEL : " + currentLevel.ToString();
    }
}
