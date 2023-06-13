using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    private bool isAttack;
    private EnemyMovement enemyMovement;

    void Awake()
    {
        enemyMovement = GetComponent<EnemyMovement>();
    }

}
