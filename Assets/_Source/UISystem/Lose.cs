using UnityEngine;
using UnityEngine.SceneManagement;

namespace UISystem
{
    public class Lose : MonoBehaviour
    {
        public void ResetLevel()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
