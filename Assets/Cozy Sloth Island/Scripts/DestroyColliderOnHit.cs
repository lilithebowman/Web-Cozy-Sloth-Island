using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyColliderOnHit : MonoBehaviour {
	public GameObject gameObjectToDestroy;
	public AudioSource audioSource;
	private Collider colliderToDestroy;
	private int time = 0;
    // Start is called before the first frame update
    void Start() {
        colliderToDestroy = gameObject.GetComponent<Collider>();
    }

	void Update() {
		time++;
		if (time > 1) {
			colliderToDestroy.enabled = false;
			audioSource.Play();
			Destroy(gameObjectToDestroy);
		}
	}
	void OnCollisionEnter(Collision collision) {
		colliderToDestroy.enabled = false;
		audioSource.Play();
		Destroy(gameObjectToDestroy);
    }
}
