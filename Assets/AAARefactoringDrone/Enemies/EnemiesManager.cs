using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesManager : MonoBehaviour
{
    //List<EnemyAI> enemiesForTObj = new List<EnemyAI>();

    //public void ClearList()
    //{
    //    enemiesForTObj.Clear();
    //}

   
    public void SortEnemiesByNoiseDist(EnemyAI[] _enemies, Vector3 _target)
    {
        float[] _distances = new float[_enemies.Length];

        for (int i = 0; i < _enemies.Length; i++)
        {
            _distances[i] = Vector3.Distance(_enemies[i].transform.position, _target);
        }

        Array.Sort(_distances, _enemies);
    }
}