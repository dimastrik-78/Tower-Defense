using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UISystem
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private GameObject tutorialPanel;
        
        public void Play()
        {
            SceneManager.LoadScene(1);
        }

        public void Tutorial()
        {
            tutorialPanel.SetActive(true);
        }

        public void Back()
        {
            tutorialPanel.SetActive(false);
        }
    }
}
