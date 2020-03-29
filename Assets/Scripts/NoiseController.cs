using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoiseController : MonoBehaviour
{
    public SphereCollider[] NoiseArea;
    public float Speed;
    float noiseOriginalRadius;
    [HideInInspector]
    public NoiseType Type;
    int m_currentColliderIndex;
    #region DelegatesDef
    public delegate void NoiseDelegate(float dimensionMod, float duration, NoiseType _type);
    #endregion

    #region Delegates
    public NoiseDelegate MakeNoiseDelegate;
    #endregion

    #region Actions
    public Action Reset;
    #endregion

    
    private void OnEnable()
    {
        MakeNoiseDelegate += MakeNoise;
    }

    private void OnDisable()
    {
        MakeNoiseDelegate -= MakeNoise;
    }

    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Space)) MakeNoise(100, 1, NoiseType.Object);    
    //}

    public void MakeNoise(float _radius, float _duration, NoiseType _type)
    {
        StopAllCoroutines();
      //  m_currentColliderIndex = (m_currentColliderIndex + 1) % NoiseArea.Length;
        Type = _type;
  /*      if (_type == NoiseType.Object)*/ TestEnemies(_radius);
        //else
        //{

        //    NoiseArea[m_currentColliderIndex].radius = _radius;
        //    NoiseArea[m_currentColliderIndex].enabled = true;
        //    StartCoroutine(NoiseLife(_duration, m_currentColliderIndex));
        //}
    }

    //########## TEST
    public LayerMask layerMask;
    public EnemiesManager enemiesManager;
    private void TestEnemies(float _radius)
    {
        Collider[] enemies = Physics.OverlapSphere(transform.position, _radius, layerMask);
        List<EnemyAI> enemyAIs = new List<EnemyAI>();
        for (int i = 0; i < enemies.Length; i++)
        {
            if (enemies[i].GetComponent<EnemyAI>()) enemyAIs.Add(enemies[i].GetComponent<EnemyAI>());
        }
        EnemyAI[] _enemies = enemyAIs.ToArray();
        enemiesManager.SortEnemiesByNoiseDist(_enemies, transform);
    }
    //###############

    IEnumerator NoiseLife(float duration, int index)
    {
        yield return new WaitForSeconds(duration);
        NoiseArea[index].enabled = false;
    }

    public enum NoiseType
    {
        Undefined,
        Walk,
        Run,
        Object
    }
}
