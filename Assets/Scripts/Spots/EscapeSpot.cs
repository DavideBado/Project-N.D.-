﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeSpot : PlaceableSpot
{
    public GameObject InExeSpot, InPlanSpot;

    private void OnEnable()
    {
        GameManager.instance.OnExePhaseAction += EnableSpot;
    }

    private void OnDisable()
    {
        GameManager.instance.OnExePhaseAction -= EnableSpot;
    }

    private void EnableSpot()
    {
        if(InPlanSpot)InPlanSpot.SetActive(false);
        if(InExeSpot)InExeSpot.SetActive(true);
    }
}
