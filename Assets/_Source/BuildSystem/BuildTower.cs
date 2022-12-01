using _Source.TowerSystem;
using UnityEngine;

namespace _Source.BuildSystem
{
    public class BuildTower : MonoBehaviour
    {
        [SerializeField] private GameObject prefab;
        [SerializeField] private GameObject panelBuildTower;
        
        private PeopleSO _peopleSo;
        private Transform _spawnPoint;

        private void Start()
        {
            _peopleSo = Resources.Load<PeopleSO>("People");
            // panelBuildTower = gameObject.transform.GetChild(0).gameObject;
            _spawnPoint = gameObject.transform;
        }

        // private void Update()
        // {
        //     if (Input.GetMouseButtonDown(0) 
        //         && panelBuildTower.activeSelf)
        //     {
        //         panelBuildTower.SetActive(false);
        //         Debug.Log("false");
        //     }
        // }
        
        private void OnMouseUp()
        {
            panelBuildTower.SetActive(true);
        }

        public void Build()
        {
            // if (_peopleSo.cost <= )
            Instantiate(prefab, _spawnPoint);
            panelBuildTower.SetActive(false);
            // Destroy(gameObject);
        }
    }
}
