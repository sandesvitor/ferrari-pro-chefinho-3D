using UnityEngine;

public class LevelProgression : MonoBehaviour
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
