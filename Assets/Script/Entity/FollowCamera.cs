using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform target;
    float offsetX;
    float offsetY;
    private float zoom;
    [SerializeField] private Camera _camera;
    private float minZoom = 2f;
    private float maxZoom = 5f;
    private float zoomMultiplyer = 4f;
    private float velocity = 0f;
    private float smoothTime = 0.25f;


    private void Start()
    {
        zoom = _camera.orthographicSize;
        if (target == null) return;

        offsetX = target.position.x - target.position.x;
        offsetY = target.position.y - target.position.y;
    }

    private void Update()
    {
        if (target == null) return;

        Vector3 pos = transform.position;
        pos.x = target.position.x + offsetX;
        pos.y = target.position.y + offsetY;
        transform.position = pos;
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        zoom -= scroll * zoomMultiplyer;
        zoom = Mathf.Clamp(zoom, minZoom, maxZoom);
        _camera.orthographicSize = Mathf.SmoothDamp(_camera.orthographicSize, zoom, ref velocity, smoothTime);
    }
}
