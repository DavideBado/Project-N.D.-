using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempButtonController : MonoBehaviour
{
    public void Quit()
    {
        Application.Quit();

    }

    public void LoadScene(int x)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(x);
    }
}
