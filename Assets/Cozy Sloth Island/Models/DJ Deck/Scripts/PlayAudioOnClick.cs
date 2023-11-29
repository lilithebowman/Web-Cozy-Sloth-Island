using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudioOnClick : MonoBehaviour {
    public GameObject gameObject;

    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start () {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update () {
		Camera camera = GameObject.FindObjectOfType<Camera>();
            
        if (Input.GetMouseButtonDown(0) && camera != null) { // if left button pressed...
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit)) {
                if (hit.transform == gameObject.transform) {
                    // Play the audio source
                    if (!audioSource.isPlaying) {
                        Debug.Log("DJ Deck is stopped, Play()-ing!");
                        Debug.Log(audioSource.isPlaying);
                        audioSource.Play();
                        gameObject.GetComponent<Renderer>().materials[0].EnableKeyword("_EMISSION");
                        gameObject.GetComponent<Renderer>().materials[1].EnableKeyword("_EMISSION");
                    } else {
                        Debug.Log("DJ Deck is playing, Stop()-ped!");
                        Debug.Log(audioSource.isPlaying);
                        audioSource.Stop();
                        gameObject.GetComponent<Renderer>().materials[0].DisableKeyword("_EMISSION");
                        gameObject.GetComponent<Renderer>().materials[1].DisableKeyword("_EMISSION");
                    }
                }
            }
        }
    }
}
