using Hero;
using TMPro;
using UnityEngine;

namespace UI
{
    public class RepresantationOfChangesOnUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _howManyOres;
        [SerializeField] private  PickUpHandler _pickUpHandler;
        [SerializeField] private  Canvas _gameOverCanvas;

        private void OnEnable()
        {
            _pickUpHandler.OnOreTaken += GetNumberOfOresOnUI;
            AnimationEventsHandler.OnPlayerDied += ShowGameOver;
        }
        private void OnDisable()
            => _pickUpHandler.OnOreTaken -= GetNumberOfOresOnUI;
        
        void Start()
            => GetNumberOfOresOnUI();
        
        private void ShowGameOver()
        {
            _gameOverCanvas.gameObject.SetActive(true);
        }
        
        public void GetNumberOfOresOnUI()
            => _howManyOres.text = _pickUpHandler.NumberCollected.ToString();
    }
}
