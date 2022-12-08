using System;
using EnemySystem;
using UnityEngine;

namespace ResourcesSystem
{
    public class ResourcesBank
    {
        public static Action<int, int> OnAddingRemovingMaterials;
        public static event Action<int, int> OnChangeMaterial;
        
        private int _stone;
        private int _bone;
        private int _addStone;
        private float _stoneExtractionTime;
        private float _time;
        
        public ResourcesBank(int addStone, float stoneExtractionTime)
        {
            _addStone = addStone;
            _stoneExtractionTime = stoneExtractionTime;
            _time = _stoneExtractionTime;

            OnAddingRemovingMaterials += ChangeMaterials;
            EnemyWave.MiningTimerReduction += MiningTimerReduction;
        }

        private void MiningTimerReduction()
        {
            if (_stoneExtractionTime > 1f)
                _stoneExtractionTime -= 0.1f;
        }

        private void ChangeMaterials(int addStone, int addBone)
        {
            _stone += addStone;
            _bone += addBone;
            
            OnChangeMaterial?.Invoke(_stone, _bone);
        }
        
        public void Start(int countStartStone)
        {
            _stone = countStartStone;
            
            OnChangeMaterial?.Invoke(_stone, _bone);
        }
        
        public void StoneExtraction()
        {
            _time -= Time.deltaTime;
            if (_time <= 0)
            {
                ChangeMaterials(_addStone, 0);
                
                _time = _stoneExtractionTime;
            }
        }
    }
}