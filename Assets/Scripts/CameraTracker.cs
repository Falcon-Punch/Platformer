using UnityEngine;

public class CameraTracker : MonoBehaviour
{
    [SerializeField] GameObject target;
    Vector3 offset;

    private void Start()
    {
        offset = target.transform.position;
        offset.x = target.transform.position.x + 10;
    }

    void Update()
    {
        offset.z = target.transform.position.z;
        transform.position = offset;
    }
}