using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Camera cameraUserView;
    [SerializeField] private GameObject target;
    [SerializeField] private float movementSpeed = 0.1f;

    void Start()
    {
        print("Ready for action!");
    }

    void Update()
    {
        // Lock view onto center of world while holding shift
        if (Input.GetKey(KeyCode.LeftShift))
            transform.LookAt(target.transform);

        // Panning
        if (Input.GetKey("w"))
            transform.Translate(0, movementSpeed, 0, cameraUserView.transform);
        else if (Input.GetKey("a"))
            transform.Translate(-movementSpeed, 0, 0, cameraUserView.transform);
        else if (Input.GetKey("s"))
            transform.Translate(0, -movementSpeed, 0, cameraUserView.transform);
        else if (Input.GetKey("d"))
            transform.Translate(movementSpeed, 0, 0, cameraUserView.transform);

        // Zooming
        if (Input.GetKey("-"))
            transform.Translate(0, 0, -movementSpeed, cameraUserView.transform);
        else if (Input.GetKey("="))
            transform.Translate(0, 0, movementSpeed, cameraUserView.transform);

        // Rotating
        if (Input.GetKey("q"))
            transform.RotateAround(target.transform.position, Vector3.up, 200 * Time.deltaTime);
        else if (Input.GetKey("e"))
            transform.RotateAround(target.transform.position, Vector3.down, 200 * Time.deltaTime);        
    }
}
