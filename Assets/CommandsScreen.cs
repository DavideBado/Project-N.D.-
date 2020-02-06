using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandsScreen : MonoBehaviour
{
    bool PrevCursorV = false;
    CursorLockMode PrevCursorLock;

    private void OnEnable()
    {
        PrevCursorV = Cursor.visible;
        PrevCursorLock = Cursor.lockState;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0;
    }

    private void OnDisable()
    {
        Time.timeScale = 1;
        Cursor.visible = PrevCursorV;
        Cursor.lockState = PrevCursorLock;
    }
     
}
