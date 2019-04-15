using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject seeker;
    private Vector3 offset;

    private void Start()
    {
        offset = transform.position - seeker.transform.position;
    }

    private void LateUpdate()
    {
        transform.position = seeker.transform.position + offset;
    }
}
