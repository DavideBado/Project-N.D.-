﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Goal : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(GameManager.instance.OnExePhase) if(collision.transform.GetComponent<PlayerMovController>() && collision.transform.GetComponent<PlayerMovController>().GoldenlEgg != null) GameManager.instance.PlayerGoal?.Invoke();
    }
}
