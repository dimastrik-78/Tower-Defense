using UnityEngine;
using System.Collections.Generic;
using _Source.EnemySystem;

namespace _Source.Core
{
    public class Bootsrtraper : MonoBehaviour
    {
        [SerializeField] private GameObject enemyPrefab;
        [SerializeField] private List<Transform> checkPointList;
        [SerializeField] private Transform spawnPoint;
        [SerializeField] private float startEnemySpawnTimer;
        [SerializeField] private float startWaveTimer;
        [SerializeField] private int maxEnemyAmount;



        private EnemyWave _enemyWave;

        private void Start()
        {
            _enemyWave = new EnemyWave(enemyPrefab, checkPointList,startWaveTimer, maxEnemyAmount);
            
        }
        
        private void Update()
        {
            _enemyWave.WaveTimer(startWaveTimer,startEnemySpawnTimer,maxEnemyAmount);
        }
    }
}
