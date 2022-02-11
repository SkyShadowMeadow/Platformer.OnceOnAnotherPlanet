using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class GameBootstraper : MonoBehaviour
    {
        public void StartGame() 
            => SceneManager.LoadScene("Level1_StoneValley");

        public void ContinueGame()
            => Debug.Log("Saving/Load system is not set");
           //LoadProgress (level name, lives, items)
          
        
        public void QuitGame() 
            => Application.Quit();

    }
}
