using UnityEngine;
using UnityEngine.SceneManagement;

namespace UISystem
{
    public class PauseMenu : MonoBehaviour
    {
        [SerializeField] private GameObject pausePanel;

        public void Pause()
        {
            Time.timeScale = 0;
            pausePanel.SetActive(true);
        }

        public void Resume()
        {
            Time.timeScale = 1;
            pausePanel.SetActive(false);
        }

        public void Menu()
        {
            SceneManager.LoadScene(0);
        }
    }
}
