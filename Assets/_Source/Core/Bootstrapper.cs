using System.Collections.Generic;
using EnemySystem;
using ResourcesSystem;
using UnityEngine;

namespace Core
{
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField] private GameObject winPanel;
        [SerializeField] private GameObject losePanel;
        
        [Header("Wave Settings")]
        [SerializeField] private GameObject[] enemyPrefab;
        [SerializeField] private List<int> maxEnemyAmount;
        [SerializeField] private Transform[] checkPointList1;
        [SerializeField] private Transform[] checkPointList2;
        [SerializeField] private float startNewWaveTimer;
        [SerializeField] private float spawnEnemyAfterEnemy;
        [SerializeField] private int waveAmount;
        [SerializeField] private int allEnemyCount;
        [SerializeField] private int bonusFromKillingEnemies;

        [Header("Materials Settings")] 
        [SerializeField] private int countStartStone;
        [SerializeField] private int addStone;
        [SerializeField] private float stoneExtractionTime;
        
        private EnemyWave _enemyWave;
        private ResourcesBank _resourcesBank;
        private Game _game;

        private void Start()
        {
            _enemyWave = new EnemyWave(enemyPrefab, checkPointList1, checkPointList2, 
                startNewWaveTimer, spawnEnemyAfterEnemy, waveAmount, 
                allEnemyCount, maxEnemyAmount, bonusFromKillingEnemies);
            _resourcesBank = new ResourcesBank(addStone, stoneExtractionTime);
            _game = new Game(winPanel, losePanel);
            
            _resourcesBank.Start(countStartStone);
        }
        
        private void Update()
        {
            _enemyWave.Wave();
            _resourcesBank.StoneExtraction();
        }
    }
}
