using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private bool _isGameOver;

    private void Update()
    {
        if (_isGameOver == true)
        {
            SceneManager.LoadScene(0); // 0 = MainMenu
        }
    }

    public void GameOver()
    {
        _isGameOver = true;
    }
}
