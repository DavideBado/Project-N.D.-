using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceableSpot : SpotBase
{
    public Collider ColliderForRayCast;
    public PlaceableSpotGraphicsController Graphics;
    public PlaceableSpotType SpotType;
     
    public enum PlaceableSpotType
    {
        EscapePoint,
        StartinPoint,
        Hiding,
        Cam,
        Multi
    }

    private void OnEnable()
    {
        GameManager.instance.OnExePhaseAction += DisableCollider;
    }

    private void OnDisable()
    {
        GameManager.instance.OnExePhaseAction -= DisableCollider;
    }

    private void DisableCollider()
    {
        if (ColliderForRayCast) ColliderForRayCast.enabled = false;
    }
}
