using UnityEngine;

public class CameraController : MonoBehaviour {

    [SerializeField]
    private Transform player;

    private Vector3 offset;

    void Start() {
        offset = transform.position - player.transform.position;
    }

    void LateUpdate() {
        transform.position = player.transform.position + offset;
    }

}