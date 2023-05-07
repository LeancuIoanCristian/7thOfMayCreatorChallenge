using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLookScript : MonoBehaviour
{
    private float mouse_sensitivity = 100f;
    [SerializeField] private Transform player_body;
    private float x_axis_rotation = 0f;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouse_x = Input.GetAxis("Mouse X") * mouse_sensitivity * Time.deltaTime;
        float mouse_y = Input.GetAxis("Mouse Y") * mouse_sensitivity * Time.deltaTime;
        
        x_axis_rotation -= mouse_y;

        x_axis_rotation = Mathf.Clamp(x_axis_rotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(x_axis_rotation, 0f, 0f);
        player_body.Rotate(Vector3.up * mouse_x);

       
    }
}
