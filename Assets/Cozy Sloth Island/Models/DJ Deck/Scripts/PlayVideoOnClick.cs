using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayVideoOnClick : MonoBehaviour {
    public GameObject gameObject;
    public Texture renderTexture;
    public Texture offStateTexture;

    private bool isPlaying = false;
    private UnityEngine.Video.VideoPlayer videoPlayer;

    void Start () {
        videoPlayer = gameObject.GetComponent<UnityEngine.Video.VideoPlayer>();
        isPlaying = videoPlayer.isPlaying;
	}

    // Update is called once per frame
    void Update () {
        Camera camera = GameObject.FindObjectOfType<Camera>();

        if (Input.GetMouseButtonDown(0) && camera != null) { // if left button pressed...
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit)) {
                if (hit.transform == gameObject.transform) {
                    if (!isPlaying) {
                        // Play the video source
                        Debug.Log("Video Player Hit - Launching Video");
                        videoPlayer.Play();
                        isPlaying = true;
                        gameObject.GetComponent<Renderer>().material.SetTexture("_MainTex", renderTexture);
                    } else {
                        // Stop the video source
                        Debug.Log("Video Player Hit - Stopping Video");
                        videoPlayer.Stop();
                        isPlaying = false;
                        gameObject.GetComponent<Renderer>().material.SetTexture("_MainTex", offStateTexture);
                    }
                }
            }
        }
    }
}
