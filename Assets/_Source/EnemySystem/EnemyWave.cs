using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = System.Random;

namespace EnemySystem
{
    public class EnemyWave
    {
        public static event Action OnLevelPassed;
        public static event Action MiningTimerReduction;
        public static event Action<Transform[]> OnChangeState;
        
        private GameObject[] _enemy;
        private Transform[] _checkPointList;
        private Transform _spawnPoint;
        private float _startNewWaveTime;
        private float _enemySpawnTime;
        private float _enemySpawnTimer;
        private int _waveAmount;
        private int _waveNow;
        private int _allEnemyCount;
        private int _enemyWaveCount;
        private int _enemyCountNow;
        private List<int> _enemyAmount;
        private List<int> _enemyAmountNow;
        private int _bonusFromKillingEnemies;
        private int _enemyDeathByTower;
        private Random _random;
        private int _randomNumber;


        public EnemyWave(GameObject[] enemyPrefabs, Transform spawnPoint, Transform[] checkPointList, 
            float startNewWaveTime, float spawnEnemyAfterEnemy, 
            int waveAmount, int allEnemyCount, List<int> enemyAmount,
            int bonusFromKillingEnemies)
        {
            _random = new Random();
            
            _enemy = enemyPrefabs;
            
            _spawnPoint = spawnPoint;
            _checkPointList = checkPointList;
            
            _startNewWaveTime = startNewWaveTime;
            
            _enemySpawnTime = spawnEnemyAfterEnemy;
            
            _enemySpawnTimer = startNewWaveTime;
            
            _waveAmount = waveAmount;
            
            _allEnemyCount = allEnemyCount;
            
            _enemyWaveCount = allEnemyCount;
            _enemyAmount = enemyAmount;
            
            SettingsEnemyList();

            _bonusFromKillingEnemies = bonusFromKillingEnemies;

            OnEnable();
        }

        private void OnEnable()
        {
            EnemyBase.OnDeadTwoAction += EnemyDie;
        }
        
        private void SettingsEnemyList()
        {
            _enemyAmountNow = new List<int>();
            
            for (int i = 0; i < _enemyAmount.Count; i++)
            {
                _enemyAmountNow.Add(_enemyAmount[i]);
            }
        }
        
        public void Wave()
        {
            _enemySpawnTimer -= Time.deltaTime;
            if (_enemySpawnTimer <= 0
                && _enemyCountNow < _enemyWaveCount)
            {
                RandomNumber();
                
                Object.Instantiate(_enemy[_randomNumber], _spawnPoint);
                
                OnChangeState?.Invoke(_checkPointList);
                
                _enemyCountNow++;
                _enemyAmountNow[_randomNumber]--;

                _enemySpawnTimer = _enemySpawnTime;
            }

            if (ZeroEnemyList(_enemyAmountNow)
                && _enemyCountNow <= 0)
                NewWave();

            if (_waveNow > _waveAmount)
            {
                EnemyBase.OnDeadTwoAction -= EnemyDie;
                OnLevelPassed?.Invoke();
            }
        }

        private void EnemyDie(bool deathByTower)
        {
            if (deathByTower)
                _enemyDeathByTower++;
            
            _enemyCountNow--;
            _enemyWaveCount--;

            CheckingKilledEnemies();
        }

        private void CheckingKilledEnemies()
        {
            if (_enemyDeathByTower >= _bonusFromKillingEnemies)
            {
                _enemyDeathByTower -= _bonusFromKillingEnemies;
                
                MiningTimerReduction?.Invoke();
            }
        }
        
        private void NewWave()
        {
            _waveNow++;
            _enemyWaveCount = _allEnemyCount;
            _enemySpawnTimer = _startNewWaveTime;

            SettingsEnemyList();
        }
        
        private void RandomNumber()
        {
            _randomNumber = _random.Next(0, _enemyAmountNow.Count);
            while (_enemyAmountNow[_randomNumber] == 0 
                   && !ZeroEnemyList(_enemyAmountNow))
            {
                _randomNumber = _random.Next(0, _enemyAmountNow.Count);
            }
        }
        
        private bool ZeroEnemyList(List<int> enemyList)
        {
            for (int i = 0; i < enemyList.Count; i++)
            {
                if (enemyList[i] != 0)
                    return false;
            }
            
            return true;
        }
    }
}
