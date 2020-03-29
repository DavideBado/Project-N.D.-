using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesManager : MonoBehaviour
{
    //List<EnemyAI> enemiesForTObj = new List<EnemyAI>();

    //public void ClearList()
    //{
    //    enemiesForTObj.Clear();
    //}


    public void SortEnemiesByNoiseDist(EnemyAI[] _enemies, Transform _target)
    {
        Vector2[] _distances = new Vector2[_enemies.Length];

        for (int i = 0; i < _enemies.Length; i++)
        {
            _distances[i].x = i;
            _distances[i].y = Vector3.Distance(_enemies[i].transform.position, _target.position);
        }


        _distances = _distances.OrderBy(v => v.y).ToArray<Vector2>();
        //Array.Sort(_distances, _enemies);

        if (_enemies[(int)_distances[0].x]) _enemies[(int)_distances[0].x].EmenyAloneHeardObj?.Invoke();
        {
            SetTarget(_enemies[(int)_distances[0].x], _target);
            for (int i = 1; i < _distances.Length; i++)
            {
                if (_enemies[(int)_distances[i].x]) _enemies[(int)_distances[i].x].EmenyHeardWalk?.Invoke();
                SetTarget(_enemies[(int)_distances[i].x], _target);
            }
        }
    }

    private void SetTarget(EnemyAI _enemyAI, Transform _target)
    {
        if (!_enemyAI.EnemyController.VisibleTarget) if (!_enemyAI.EnemyController.NoiseTarget) _enemyAI.EnemyController.NoiseTarget = _target;
    }
}