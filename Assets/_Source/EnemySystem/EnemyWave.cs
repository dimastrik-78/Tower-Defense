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

        public EnemyWave(GameObject enemyPrefab, List<Transform> checkPointList, Transform spawnPoint)
        {
            _enemy = enemyPrefab;
            _checkPointList = checkPointList;
        }

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                UnityEngine.Object.Instantiate(_enemy, _spawnPoint);
                OnChangeState?.Invoke(_checkPointList);
            }
        }
    }
    
}
