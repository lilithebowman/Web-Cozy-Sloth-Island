
using UnityEngine;

public class ReflectionProbe1 : MonoBehaviour
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
