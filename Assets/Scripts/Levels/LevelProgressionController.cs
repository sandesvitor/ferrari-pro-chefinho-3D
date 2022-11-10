using UnityEngine;

public class LevelProgressionController : MonoBehaviour
{
    private GameManager _gameManager; 
    private GameObject[] members;

    void Start()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        if (_gameManager == null)
        {
            Debug.LogError("GameManager is NULL.");
        }
    }

    void Update()
    {  
    }
}
