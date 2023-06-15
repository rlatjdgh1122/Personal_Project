using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHpContoller : MonoBehaviour
{
    private Slider _slider;
    private TextMeshProUGUI curTxt;
    private TextMeshProUGUI maxTxt;

    private int curHp = 0;
    private int mHp = 0;
    private void Awake()
    {
        _slider = GetComponent<Slider>();
        curTxt = transform.Find("CurrentHpText").GetComponent<TextMeshProUGUI>();
        maxTxt = transform.Find("MaxHpText").GetComponent<TextMeshProUGUI>();
    }
    private void Start()
    {
        _slider.maxValue = 150;
        _slider.value = 150;

        curTxt.text = "150";
        maxTxt.text = "150";
    }
    public void SetHp(int currentHp, int maxHp)
    {
        curHp = currentHp;
        mHp = maxHp;

        curTxt.text = currentHp.ToString();
        maxTxt.text = maxHp.ToString();

        _slider.maxValue = maxHp;
        _slider.value = currentHp;
    }
}
