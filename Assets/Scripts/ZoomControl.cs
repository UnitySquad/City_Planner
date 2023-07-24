using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomControl : MonoBehaviour
{
    public float ZoomChange;
    public float SmoothChange;
    public float MinSize, MaxSize;

    private Camera camera;

    // Start is called before the first frame update
    void Start()
    {
        camera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.mouseScrollDelta.y > 0)
        {
            camera.orthographicSize -= ZoomChange * Time.deltaTime * SmoothChange;
        }
        if(Input.mouseScrollDelta.y < 0)
        {
            camera.orthographicSize += ZoomChange * Time.deltaTime * SmoothChange;
        }

        camera.orthographicSize = Mathf.Clamp(camera.orthographicSize, MinSize, MaxSize);
    }
}
