using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    private Vector3 Origin;
    private Vector3 Difference;
    private Vector3 ResetCamera;

    public bool drag = false;

    public float movementSpeed;
    public float movementTime;

    public Vector3 newPosition;

    // 범위를 지정하는 변수들 (public으로 선언하여 Inspector에서 값을 수정할 수 있도록 함)
    public Vector3 minBound = new Vector3(-163f, 38f, 14f);
    public Vector3 maxBound = new Vector3(-127f, 58f, 71f);

    // Start is called before the first frame update
    void Start()
    {
        ResetCamera = Camera.main.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //마우스로 움직임
        if(Input.GetMouseButton(0))
        {
            Difference = (Camera.main.ScreenToWorldPoint(Input.mousePosition)) - Camera.main.transform.position;
            if(drag == false)
            {
                drag = true;
                Origin = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }
        }
        else
        {
            drag = false;
        }

        if(drag)
        {
            Camera.main.transform.position = Origin - Difference;
            newPosition = Origin - Difference;

            // 범위를 벗어나지 못하도록 제한
            newPosition.x = Mathf.Clamp(newPosition.x, minBound.x, maxBound.x);
            newPosition.y = Mathf.Clamp(newPosition.y, minBound.y, maxBound.y);
            newPosition.z = Mathf.Clamp(newPosition.z, minBound.z, maxBound.z);
        }

        if(Input.GetKey(KeyCode.F1))
        {
            Camera.main.transform.position = ResetCamera;
            newPosition = ResetCamera;
        }

        // 키보드로 움직임
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            newPosition += (transform.up * movementSpeed);
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            newPosition += (transform.up * -movementSpeed);
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            newPosition += (transform.right * movementSpeed);
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            newPosition += (transform.right * -movementSpeed);
        }

        // 범위를 벗어나지 못하도록 다시 한번 제한
        newPosition.x = Mathf.Clamp(newPosition.x, minBound.x, maxBound.x);
        newPosition.y = Mathf.Clamp(newPosition.y, minBound.y, maxBound.y);
        newPosition.z = Mathf.Clamp(newPosition.z, minBound.z, maxBound.z);

        transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * movementTime);
    }
}
