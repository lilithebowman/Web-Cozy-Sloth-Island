using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class WaypointFollow : UdonSharpBehaviour {
    public Transform[] waypoints;
    public Transform objectToMove;
    public float speed = 0.25f;
    public float accelerationSpeed = 0.25f;
    public float rotationSpeed = 0.25f;
    public float secondsToWait = 100f;
    public bool isFollowing = true;

    private float countdown;
    private string state;
    private int lastIndex;
    private int waypointIndex;
    private float currentSpeed = 0f;
    private VRCPlayerApi lp;

    void Start() {
        lp = Networking.LocalPlayer;

        Debug.Log("Local Player");
        Debug.Log(lp.GetPosition());

        if (waypoints != null && waypoints.Length > 0) {
            objectToMove.position = waypoints[0].position;
            lastIndex = 0;
            waypointIndex = 1;
            state = "waiting";
        } else {
            Debug.LogError("Waypoints not set up! Please set some waypoints first!");
        }
    }

    void LateUpdate() {
        if(isFollowing && state == "moving" && waypoints.Length > 0) {

            Vector3 nextPosition = waypoints[waypointIndex].position;
            Vector3 lastPosition = waypoints[lastIndex].position;

            currentSpeed += accelerationSpeed * Time.deltaTime;
            if ( currentSpeed >= speed ) {
                currentSpeed = speed;
			}

            objectToMove.position = Vector3.MoveTowards(objectToMove.position, nextPosition, currentSpeed * Time.deltaTime);

            Vector3 relativePos = waypoints[waypointIndex].position - objectToMove.position;

            // Draw a ray pointing at our target in
            Debug.DrawRay(objectToMove.position, relativePos, Color.red);

            // the second argument, upwards, defaults to Vector3.up
            Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
            rotation *= Quaternion.Euler(0, -90, 0); // this adds a -90 degrees Y rotation
            objectToMove.rotation = Quaternion.Lerp(objectToMove.rotation, rotation, rotationSpeed * Time.deltaTime);


            if (Vector3.Distance(objectToMove.position, waypoints[waypointIndex].position) < .1) {
                if (waypointIndex >= waypoints.Length) {
                    state = "waiting";
                    countdown = secondsToWait;
                } else {
                    state = "next";
                    countdown = 0;
                }
                Debug.Log(state);
			}
		}

        if(isFollowing && (state == "waiting" || state == "next")) {
            countdown--;

            if(countdown <= 0) {
                lastIndex++;
                if (lastIndex >= waypoints.Length) {
                    lastIndex = 0;
                }
                
                waypointIndex++;
                if (waypointIndex >= waypoints.Length) {
                    state = "waiting";
                    waypointIndex = 0;
                } else {
                    state = "moving";
                }
                Debug.Log(state);
			}
		}
	}
}
