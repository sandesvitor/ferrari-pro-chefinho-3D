using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController instance;

    public Transform cameraTransform;
    public Transform followTransform;

    public float movementSpeed;
    public float movementTime;
    public float rotationAmount;
    public Vector3 zoomAmount;
    public Vector3 zoomMaxLimit;
    public Vector3 zoomMinLimit;

    public Vector3 newPosition;
    public Quaternion newRotation;
    public Vector3 newZoom;

    public Vector3 dragStartPosition;
    public Vector3 dragCurrentPosition;

    void Start()
    {
        instance = this;

        newPosition = this.transform.position;
        newRotation = this.transform.rotation;
        newZoom = cameraTransform.localPosition;
    }

    void Update()
    {
        if (followTransform != null)
        {
            this.transform.position = followTransform.position;
        }
        else
        {
            HandleMovementInput();
            HandleMouseInput();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            followTransform = null;
        }

    }

    // FIX: mouse zoom limit!!!
    void HandleMouseInput()
    {
        // Mouse Camera Zoom
        if (Input.mouseScrollDelta.y != 0 && (newZoom.y >= zoomMaxLimit.y && newZoom.z <= zoomMaxLimit.z))
        {
            newZoom += Input.mouseScrollDelta.y * zoomAmount;
        }
        if (Input.mouseScrollDelta.y != 0 && (newZoom.y <= zoomMinLimit.y && newZoom.z >= zoomMinLimit.z)
        )
        {
            newZoom += Input.mouseScrollDelta.y * zoomAmount;
        }

        // Mouse Camera Movement
        if(Input.GetMouseButtonDown(0))
        {
            Plane plane = new Plane(Vector3.up, Vector3.zero);

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            float entry;

            if (plane.Raycast(ray, out entry))
            {
                dragStartPosition = ray.GetPoint(entry);
            }
        }
        if(Input.GetMouseButton(0))
        {
            Plane plane = new Plane(Vector3.up, Vector3.zero);

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            float entry;

            if (plane.Raycast(ray, out entry))
            {
                dragCurrentPosition = ray.GetPoint(entry);

                newPosition = this.transform.position + dragStartPosition - dragCurrentPosition;
            }
        }
    }

    void HandleMovementInput()
    {
        // Camera Movement
        if (Input.GetKey("w") || Input.GetKey(KeyCode.UpArrow))
        {
            newPosition += (transform.forward * movementSpeed);
        }
        if (Input.GetKey("s") || Input.GetKey(KeyCode.DownArrow))
        {
            newPosition += (transform.forward * (-1f) * movementSpeed);
        }
        if (Input.GetKey("d") || Input.GetKey(KeyCode.RightArrow))
        {
            newPosition += (transform.right * movementSpeed);
        }
        if (Input.GetKey("a") || Input.GetKey(KeyCode.LeftArrow))
        {
            newPosition += (transform.right * (-1f) * movementSpeed);
        }

        // Camera Rotation
        if(Input.GetKey("q"))
        {
            newRotation *= Quaternion.Euler(Vector3.up * rotationAmount);
        }
        if(Input.GetKey("e"))
        {
            newRotation *= Quaternion.Euler(Vector3.up * (-1f) * rotationAmount);
        }

        // Camera Zoom
        if(Input.GetKey("r") && (newZoom.y >= zoomMaxLimit.y && newZoom.z <= zoomMaxLimit.z))
        {
            newZoom += zoomAmount;
        }
        if(Input.GetKey("f") && (newZoom.y <= zoomMinLimit.y && newZoom.z >= zoomMinLimit.z))
        {
            newZoom -= zoomAmount;
        }

        transform.position = Vector3.Lerp(this.transform.position, newPosition, Time.deltaTime * movementTime);
        transform.rotation = Quaternion.Lerp(this.transform.rotation, newRotation, Time.deltaTime * movementTime);
        cameraTransform.localPosition = Vector3.Lerp(cameraTransform.localPosition, newZoom, Time.deltaTime * movementTime);
    }
}
