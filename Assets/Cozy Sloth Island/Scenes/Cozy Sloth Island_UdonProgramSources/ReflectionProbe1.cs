using UnityEngine;

public class ReflectionProbe1 : MonoBehaviour
{
    public GameObject probeGameObject;
    public GameObject playerGameObject;
    public Vector3 offset = new Vector3(0.0f, 0.0f, 1.0f);
    public Vector3 betweenEyes;
    public Vector3 head;

    void Start() {
#if UNITY_STANDALONE
        probeGameObject.SetActive(true);
#elif UNITY_EDITOR
        probeGameObject.SetActive(true);
#else
        probeGameObject.SetActive(false);
#endif
    }

    void LateUpdate() {
        // move realtime probe to player head
        probeGameObject.transform.position = playerGameObject.transform.position;
    }
}
