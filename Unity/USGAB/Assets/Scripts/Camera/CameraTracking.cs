using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTracking : MonoBehaviour
{
    public Transform trackedObject;
    public Vector2 trackingOffset;
    public float updateSpeed = 3.0f;
    private Vector3 offset;
    private void Start()
    {
        offset = (Vector3)trackingOffset;
        offset.z = transform.position.z - trackedObject.position.z;

    }
    private void LateUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position,trackedObject.position+offset, updateSpeed * Time.deltaTime);
    }
}
