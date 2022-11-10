using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [Header("Levels to Load")]
    public int _newGameLevel;

    public void NewGame()
    {
        SceneManager.LoadScene(_newGameLevel);
    }
    
    public void ExitGame()
    {
        Application.Quit();
    }
}
