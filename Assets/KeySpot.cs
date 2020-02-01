using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeySpot : MonoBehaviour
{
    public GameObject DirectionTarget;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.GetComponent<PlayerMovController>() != null)
        {
            other.transform.GetComponent<PlayerMovController>().haveTheKey = true;
            gameObject.SetActive(false);
        }
    }
}
