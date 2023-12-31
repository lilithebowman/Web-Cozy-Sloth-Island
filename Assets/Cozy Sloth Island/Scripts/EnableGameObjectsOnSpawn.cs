﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableGameObjectsOnSpawn : MonoBehaviour {
    public GameObject[] prefabsToSpawn;
    // Start is called before the first frame update
    void Start() {
        foreach (GameObject prefab in prefabsToSpawn) {
            // Instantiate at position (0, 0, 0) and zero rotation.
            Destroy(prefab);
        }
    }
}
