using BuildSystem;
using CaveSystem;
using EnemySystem;
using ResourcesSystem;
using TMPro;
using TowerSystem;
using UnityEngine;
using UnityEngine.UI;

namespace UISystem
{
    public class GameUI : MonoBehaviour
    {
        [Header("Game information")]
        [SerializeField] private TextMeshProUGUI textHeal;
        [SerializeField] private TextMeshProUGUI textStone;
        [SerializeField] private TextMeshProUGUI textBone;
        [SerializeField] private TextMeshProUGUI wave;
        [SerializeField] private Slider enemyLeft;

        [Header("Towers")] 
        [SerializeField] private TowerSO[] towerSo;
        [SerializeField] private GameObject buildPanel;
        [SerializeField] private TextMeshProUGUI[] textTowerCost;

        [SerializeField] private Upgrade upgrade;
        
        private Transform _spawnPoint;

        private void Start()
        {
            for (int i = 0; i < towerSo.Length; i++)
            {
                textTowerCost[i].text = towerSo[i].BuildCost.ToString();
            }
        }

        private void WaveNow(int waveNow)
        {
            wave.text = waveNow.ToString();
        }
        
        private void ChangeEnemyLeft(int EnemyLeft)
        {
            this.enemyLeft.value = EnemyLeft;
        }
        
        private void ChangeCaveHeal(int caveHeal)
        {
            textHeal.text = caveHeal.ToString();
        }
        
        private void ChangeMaterials(int stone, int flesh)
        {
            textStone.text = stone.ToString();
            textBone.text = flesh.ToString();
        }
        
        private void OnEnable()
        {
            BuildTower.OnSelectBuildZone += Settings;
            ResourcesBank.OnChangeMaterial += ChangeMaterials;
            Cave.OnChangeHeal += ChangeCaveHeal;
            EnemyWave.OnChangeWave += WaveNow;
            EnemyWave.OnChangeEnemyCount += ChangeEnemyLeft;
        }

        private void OnDisable()
        {
            BuildTower.OnSelectBuildZone -= Settings;
            ResourcesBank.OnChangeMaterial -= ChangeMaterials;
            Cave.OnChangeHeal -= ChangeCaveHeal;
            EnemyWave.OnChangeWave -= WaveNow;
            EnemyWave.OnChangeEnemyCount -= ChangeEnemyLeft;
        }

        private void Settings(Transform spawnPoint)
        {
            _spawnPoint = spawnPoint;

            buildPanel.SetActive(true);
        }

        public void BuildArcherTower()
        {
            if (int.Parse(textStone.text) >= towerSo[0].BuildCost)
            {
                Instantiate(towerSo[0].TowerBase, _spawnPoint).GetComponent<Archer>().Upgrade = upgrade;
                ResourcesBank.OnAddingRemovingMaterials?.Invoke(-towerSo[0].BuildCost, 0);
                    
                buildPanel.SetActive(false);
            }
        }
        
        public void BuildSpearmanTower()
        {
            if (int.Parse(textStone.text) >= towerSo[1].BuildCost)
            {
                Instantiate(towerSo[1].TowerBase, _spawnPoint).GetComponent<Spearmen>().Upgrade = upgrade;
                    
                ResourcesBank.OnAddingRemovingMaterials?.Invoke(-towerSo[1].BuildCost, 0);
                
                buildPanel.SetActive(false);
            }
        }
        
        public void BuildCatapultTower()
        {
            if (int.Parse(textStone.text) >= towerSo[2].BuildCost)
            {
                Instantiate(towerSo[2].TowerBase, _spawnPoint).GetComponent<Catapults>().Upgrade = upgrade;
                    
                ResourcesBank.OnAddingRemovingMaterials?.Invoke(-towerSo[2].BuildCost, 0);
                    
                buildPanel.SetActive(false);
            }
        }
    }
}
