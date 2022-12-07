using UnityEngine;
using UnityEngine.SceneManagement;

namespace UISystem
{
    public class LevelMenu : MonoBehaviour
    {
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
