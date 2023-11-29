using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableGameObjectsOnSpawn : MonoBehaviour {
    public GameObject[] prefabsToSpawn;
    // Start is called before the first frame update
    void Start() {
        foreach (GameObject prefab in prefabsToSpawn) {
            // Instantiate at position (0, 0, 0) and zero rotation.
            Instantiate(prefab, new Vector3(0, 0, 0), Quaternion.identity);
        }
    }
}
