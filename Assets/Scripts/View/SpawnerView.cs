using UnityEngine;

public class SpawnerView : MonoBehaviour
{
    public GameObject Spawn(GameObject template, Vector3 spawnPoint, Transform container)
    {
        var spawned = Instantiate(template, spawnPoint, Quaternion.identity, container);
        return spawned;
    }
}
