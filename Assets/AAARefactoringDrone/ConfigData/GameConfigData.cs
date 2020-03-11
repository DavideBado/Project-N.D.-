using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Game_data", menuName = "LevelData/Game", order = 2)]
public class GameConfigData : ScriptableObject
{
    public SpawnSpot spawnSpot;
    public EscapeSpot escapeSpot;
    public Vector3 KeyPos = new Vector3(0, 100000, 0);

    public List<HidingSpot> hidingSpots = new List<HidingSpot>();
    public List<CamSpot> camSpots = new List<CamSpot>();

    #region Actions
    public Action Cleared;
    #endregion


    public void ClearAll()
    {
        ResetSpawn();
        ResetEscape();
        ResetKeyPos();
        ResetHidingSpots();
        ResetCamSpots();

        Cleared?.Invoke();
    }

    private void ResetSpawn()
    {
        //Reset grafica

        spawnSpot = null;
    }

    private void ResetEscape()
    {
        //Reset grafica

        escapeSpot = null;
    }

    private void ResetKeyPos()
    {
        KeyPos = new Vector3(0, 100000, 0);
    }

    private void ResetHidingSpots()
    {
        //Reset grafica

        hidingSpots.Clear();
    }

    private void ResetCamSpots()
    {
        //Reset grafica

        camSpots.Clear();
    }
}
