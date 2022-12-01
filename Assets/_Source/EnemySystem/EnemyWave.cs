using UnityEngine;
using System;
using System.Collections.Generic;
namespace _Source.EnemySystem
{
    public class EnemyWave
    {
        public static Action<List<Transform>> OnChangeState;

        private GameObject _enemy;
        private List<Transform> _checkPointList;
        private Transform _spawnPoint;
        private float enemySpawnTimer;
        private float waveTimer;
        private int enemyCount;


        public EnemyWave(GameObject enemyPrefab, List<Transform> checkPointList, float startWaveTimer, int maxEnemyAmount)
        {
            _enemy = enemyPrefab;
            _checkPointList = checkPointList;
            waveTimer = startWaveTimer;
            enemyCount = maxEnemyAmount;
        }

        //public void Update()
        //{
        //    //if (Input.GetKeyDown(KeyCode.Space))
        //    //{
        //    //    UnityEngine.Object.Instantiate(_enemy, _spawnPoint);
        //    //    OnChangeState?.Invoke(_checkPointList);
        //    //}
        //}

        public void WaveTimer(float startWaveTimer, float startEnemySpawnTimer, int maxEnemyAmount)
        {
            enemySpawnTimer -= Time.deltaTime;
            if(enemySpawnTimer <= 0 && enemyCount != maxEnemyAmount)
            {
                enemyCount++;
                UnityEngine.Object.Instantiate(_enemy, _spawnPoint);
                OnChangeState?.Invoke(_checkPointList);
                enemySpawnTimer = startEnemySpawnTimer;
                
            } 
            else if(enemyCount == maxEnemyAmount)
            {
                waveTimer -= Time.deltaTime;
                if (waveTimer <= 0)
                {
                    waveTimer = startWaveTimer;
                    enemyCount = 0;
                }
             }

        }
    }
    
}
