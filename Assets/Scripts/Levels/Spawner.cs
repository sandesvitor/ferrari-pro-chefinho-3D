using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefab;
    [SerializeField] private bool isWageSlaveHere = false;

    void OnMouseDown()
    {
        if (isWageSlaveHere == true)
        {
            Vector3 spawnPosition = this.transform.position;
            Instantiate(prefab, spawnPosition, Quaternion.identity);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "WageSlave")
        {
            isWageSlaveHere = true;
        }
    }
}
