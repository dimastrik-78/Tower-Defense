using CaveSystem;
using EnemySystem;
using UnityEngine;

namespace Core
{
    public class Game
    {
        private GameObject _winPanel;
        private GameObject _losePanel;
        private int _numLevel;
        
        public Game(GameObject winPanel, GameObject losePanel)
        {
            _winPanel = winPanel;
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
            _winPanel.SetActive(true);
            
            Time.timeScale = 0;

            _numLevel = PlayerPrefs.GetInt("Completed Levels");
            PlayerPrefs.SetInt("Completed Levels", ++_numLevel);

            OnDisable();
        }
        
        private void LoseGame()
        {
            _losePanel.SetActive(true);

            Time.timeScale = 0;

            OnDisable();
        }
        
        private void OnDisable()
        {
            Cave.OnLoseGame -= LoseGame;
            EnemyWave.OnLevelPassed -= LevelPassed;
        }
    }
}
