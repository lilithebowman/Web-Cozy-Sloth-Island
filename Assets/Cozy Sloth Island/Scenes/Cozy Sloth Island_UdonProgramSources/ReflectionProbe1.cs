
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class ReflectionProbe1 : UdonSharpBehaviour
{
    public GameObject probeGameObject;
    public int renderInterval = 1000;
    private ReflectionProbe probeComponent;
    public int intervalCounter;
    void Start() {
        intervalCounter = renderInterval;
        if (probeGameObject) {
            // Add the reflection probe component
            probeComponent = probeGameObject.GetComponent<ReflectionProbe>();
        }
    }

    void LateUpdate() {
        intervalCounter--;

        if (intervalCounter == 0) {
            probeComponent.RenderProbe();
            Debug.Log("Realtime Reflection Probe Updated");
            intervalCounter = renderInterval;
        }
    }
}
