using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefab;
    [SerializeField] private bool isWageSlaveHere = false;

    void Update()
    {
        if (Input.GetKeyDown("space") && isWageSlaveHere == true)
        {
            Vector3 spawnPosition = this.transform.position;
            Instantiate(prefab, spawnPosition, Quaternion.identity);
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "WageSlave")
        {
            isWageSlaveHere = true;
        }
    }
}
