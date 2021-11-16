using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float cameraSpeed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CameraRun(Vector3.forward);
        //CameraMove();
    }

    private void CameraRun(Vector3 direction)
    {
        transform.Translate(cameraSpeed * direction * Time.deltaTime);
    }

    private void CameraMove()
    {
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.position = transform.position += (new Vector3(-0.05f, 0f, 0) * cameraSpeed);
        }

        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position = transform.position += (new Vector3(0.05f, 0f, 0) * cameraSpeed);
        }
    }
}
