using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLookAround : MonoBehaviour
{
    [SerializeField]
    private float MouseSensitivity = 1000.0f;

    [SerializeField]
    private Transform PlayerBody;

    private float RotX = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * MouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * MouseSensitivity * Time.deltaTime;

        RotX -= mouseY;
        RotX = Mathf.Clamp(RotX, -45.0f, 90.0f);

        transform.localRotation = Quaternion.Euler(RotX, 0.0f, 0.0f);
        PlayerBody.Rotate(Vector3.up * mouseX);
    }
}
