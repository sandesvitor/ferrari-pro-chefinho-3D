using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefab;

    [SerializeField] private List<GameObject> workersInsideHumanResourcesList; 


    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            Vector3 spawnPosition = this.transform.position;
            Instantiate(prefab, spawnPosition, Quaternion.identity);
        }
    }
}
