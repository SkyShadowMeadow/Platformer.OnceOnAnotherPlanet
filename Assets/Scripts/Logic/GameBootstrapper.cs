using UnityEngine;
using UnityEngine.SceneManagement;

namespace Logic
{
    public class GameBootstrapper : MonoBehaviour
    {
        private const string FirstLevel = "Level1_StoneValley";

        public void StartFirstLevel()
            => SceneManager.LoadScene(FirstLevel);

        public void QuitGame()
            => Application.Quit();
        
    }
}