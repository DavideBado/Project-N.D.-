using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanningCheckPoint_ConfigData : ScriptableObject
{
    [HideInInspector]
    public SpawnSpot spawnSpot;
    [HideInInspector]
    public EscapeSpot escapeSpot;
    [HideInInspector]
    public List<HidingSpot> hidingSpots = new List<HidingSpot>();
    [HideInInspector]
    public List<CamSpot> camSpots = new List<CamSpot>();

    public void ClearAll()
    {
        spawnSpot.Graphics.SetSelectedGraphichs(false);
        spawnSpot = null;

        escapeSpot.Graphics.SetSelectedGraphichs(false);
        escapeSpot = null;

        for (int i = 0; i < hidingSpots.Count; i++)
        {
            ClearList(hidingSpots[i]);
        }
        hidingSpots.Clear();

        for (int i = 0; i < camSpots.Count; i++)
        {
            ClearList(camSpots[i]);
        }
        camSpots.Clear();
       
    }

    private void ClearList(MultiSpotItemBase _Obj)
    {
        for (int j = 0; j < _Obj.MyMultiSpot.SpotTypesForMulti.Count; j++)
        {
            _Obj.MyMultiSpot.SpotsForMultiExe[j].SetActive(false);
            _Obj.MyMultiSpot.SpotsForMultiPlan[j].SetActive(false);
        }
    }
}