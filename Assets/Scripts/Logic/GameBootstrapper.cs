using UnityEngine;
using UnityEngine.SceneManagement;

namespace Logic
{
    public class GameBootstrapper : MonoBehaviour
    {
        private const string FirstLevel = "Level1_StoneValley";
        private const string Initial = "Initial";

        public void StartFirstLevel()
            => SceneManager.LoadScene(FirstLevel);
        public void MainMenu()
            => SceneManager.LoadScene(Initial);

        public void QuitGame()
            => Application.Quit();
        
    }
}