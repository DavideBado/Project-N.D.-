using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Goal : MonoBehaviour
{

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetAxisRaw("Interact") != 0)
            if (GameManager.instance.OnExePhase)
                if (other.transform.GetComponent<PlayerMovController>() && other.transform.GetComponent<PlayerMovController>().GoldenlEgg != null)
                {
                    GameManager.instance.UI_Manager.TreasureIcon.SetActive(false);
                    GameManager.instance.PlayerGoal?.Invoke();
                }
    }
}
