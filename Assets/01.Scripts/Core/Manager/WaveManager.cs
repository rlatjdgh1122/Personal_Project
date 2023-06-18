using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

[Serializable]
public class Wave
{
    public GameObject[] Enemys;
    public int EnemyCount;
    public float Spawn_delay;
}

public class WaveManager : MonoBehaviour
{
    public static WaveManager instance;
    public List<Wave> waves = new();
    public TextMeshProUGUI waveTxt;
    public GameObject nextBtn;

    public int currentEnemyCount = 0;

    private int currentWave = 1;
    private bool isWaving = true;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else Destroy(this);
    }
    private void Start()
    {
        Spawn(0);
        nextBtn.SetActive(false);
        waveTxt.text = $"WAVE {currentWave}";
    }
    private void Update()
    {
        if (isWaving)
        {
            if (currentEnemyCount == 0)
            {
                nextBtn.SetActive(true);
                isWaving = false;
            }
        }
    }
    private void Spawn(int idx)
    {
        Start_Spwan(waves[idx].Enemys, waves[idx].Spawn_delay, waves[idx].EnemyCount);
    }
    private void Start_Spwan(GameObject[] enemys, float delay, int enemyCount)
    {
        currentEnemyCount = enemyCount;
        StartCoroutine(Co_Spawn(enemys, delay, enemyCount));
    }

    private IEnumerator Co_Spawn(GameObject[] enemys, float delay, int enemyCount)
    {
        while (enemyCount != 0)
        {
            yield return new WaitForSeconds(delay);
            Vector3 randomPos = GameManager.Instance.playerPos.position + Vector3.forward * 30;
            randomPos += new Vector3(Random.Range(-7.5f, 7.5f), 2, Random.Range(-7.5f, 7.5f));

            GameObject g = enemys[Random.Range(0, enemys.Length)];
            Instantiate(g, randomPos, Quaternion.identity);
            enemyCount -= 1;
        }
    }

    public void NextWave()
    {
        isWaving = true;
        nextBtn.SetActive(false);
        Spawn(++currentWave);
    }
}
