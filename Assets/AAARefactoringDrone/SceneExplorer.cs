using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneExplorer : MonoBehaviour
{
    float MouseX = 0;
    float MouseY = 0;
    public float Speed;
    public float RotSpeed;

    

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        MouseX += Input.GetAxis("Mouse X") * RotSpeed;
        MouseY += Input.GetAxis("Mouse Y") * RotSpeed;

        transform.rotation = Quaternion.Euler(-MouseY, MouseX, 0);

        transform.Translate(direction.normalized * Speed * Time.deltaTime, Space.Self);

        if (Input.GetKeyDown(KeyCode.Escape)) UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
