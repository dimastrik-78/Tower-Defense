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

        private EnemyWave _enemyWave;

        private void Start()
        {
            _enemyWave = new EnemyWave(enemyPrefab, checkPointList, spawnPoint);
        }

        private void Update()
        {
            _enemyWave.Update();
        }
    }
}
