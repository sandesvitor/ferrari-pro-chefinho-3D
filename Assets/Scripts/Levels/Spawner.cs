using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefab;

    // [SerializeField] private bool isWageSlaveHere = false;
    [SerializeField] private List<GameObject> workersInsideHumanResourcesList; 


    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            Vector3 spawnPosition = this.transform.position;
            Instantiate(prefab, spawnPosition, Quaternion.identity);
        }
    }

    // void OnTriggerEnter(Collider collider)
    // {
    //     if (collider.gameObject.tag != "WageSlave")
    //     {
    //         return;
    //     }
    
    //     workersInsideHumanResourcesList.Add(collider.gameObject);
    //     // isWageSlaveHere = true;
    // }

    // void OnTriggerExit(Collider collider)
    // {
    //     if (collider.gameObject.tag != "WageSlave")
    //     {
    //         return;
    //     }
    
    //     workersInsideHumanResourcesList.Remove(collider.gameObject);

    //     // if (workersInsideHumanResourcesList.Count == 0)
    //     // {
    //     //     isWageSlaveHere = false;
    //     // }
    // }
}
