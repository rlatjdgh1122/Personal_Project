using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHpBar : MonoBehaviour
{
    private EnemyController _enemyController;
    private Slider _slider;

    private void Awake()
    {
        _slider = GetComponentInChildren<Slider>();
        _enemyController = transform.root.transform.Find("Core").GetComponent<EnemyController>();
    }
    private void Start()
    {
        _slider.maxValue = _enemyController.EnemySoData.hp;
        _slider.value = _slider.maxValue;
    }
    private void Update()
    {
        transform.position = _enemyController.transform.position;
    }
    public void OnDamage(float damage)
    {
        _slider.value -= damage;
    }
}
