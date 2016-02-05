using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour
{

    private float speed = 5.0f;
    private float zoomSpeed = 5.0f;

    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += new Vector3(0, 1 / Mathf.Sqrt(2), 1 / Mathf.Sqrt(2)) * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position += new Vector3(0, -1 / Mathf.Sqrt(2), -1 / Mathf.Sqrt(2)) * speed * Time.deltaTime;
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        transform.Translate(0, 0, scroll * zoomSpeed, Space.World);
    }
}
