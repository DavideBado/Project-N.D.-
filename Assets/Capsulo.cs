using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Capsulo : MonoBehaviour
{
    public GameObject Graphics;
    private void OnCollisionEnter(Collision collision)
    {
        if (GameManager.instance.OnExePhase) if (collision.transform.GetComponent<PlayerMovController>())
            {
                collision.transform.GetComponent<PlayerMovController>().capsulo = this;
                Graphics.SetActive(false);
            }
    }
}
