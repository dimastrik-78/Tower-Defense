using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UISystem
{
    public class LevelMenu : MonoBehaviour
    {
        [SerializeField] private Button[] levelButtons;
        [SerializeField] private Transform[] textResultLevel;

        private void Start()
        {
            if (!PlayerPrefs.HasKey("Completed Levels"))
                PlayerPrefs.SetInt("Completed Levels", 1);
            
            Debug.Log(PlayerPrefs.GetInt("Completed Levels"));
            
            for (int i = 0; i < levelButtons.Length; i++)
            {
                if (PlayerPrefs.GetInt("Completed Levels") - 2 >= i)
                {
                    levelButtons[i].interactable = true;
                    textResultLevel[i].GetChild(0).gameObject.SetActive(true);
                    textResultLevel[i].GetChild(1).gameObject.SetActive(false);
                }
            }
        }

        public void OneLevel()
        {
            SceneManager.LoadScene(2);
        }
        
        public void TwoLevel()
        {
            SceneManager.LoadScene(3);
        }
        
        public void ThreeLevel()
        {
            SceneManager.LoadScene(4);
        }

        public void MainMenu()
        {
            SceneManager.LoadScene(0);
        }
    }
}
