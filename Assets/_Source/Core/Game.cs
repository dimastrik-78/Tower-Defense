using CaveSystem;
using EnemySystem;
using UnityEngine;

namespace Core
{
    public class Game
    {
        private GameObject _losePanel;
        
        public Game(GameObject losePanel)
        {
            _losePanel = losePanel;

            OnEnable();
            
            Time.timeScale = 1;
        }

        private void OnEnable()
        {
            Cave.OnLoseGame += LoseGame;
            EnemyWave.OnLevelPassed += LevelPassed;
        }

        private void LevelPassed()
        {
            
        }
        
        private void LoseGame()
        {
            _losePanel.SetActive(true);

            Time.timeScale = 0;
            
            Cave.OnLoseGame -= LoseGame;
        }
    }
}
