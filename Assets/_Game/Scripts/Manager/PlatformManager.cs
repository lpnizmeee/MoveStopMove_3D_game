using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : Singleton<PlatformManager>
{
    public int numberEnemiesDead;
    public int numberEnemies;

    private List<Transform> platformList;

    private void Awake()
    {
        platformList = new List<Transform>();
    }
    private void Start()
    {
        EnemySpawner.Instance.SpawnEnemies();
    }
    private void Update()
    {
        this.ReSpawnEnemies();
    }

    private void ReSpawnEnemies()
    {
        if(numberEnemiesDead > 15)
        {
            EnemySpawner.Instance.ReSpawn(15);
            numberEnemiesDead = 0;
        }
    }
}
