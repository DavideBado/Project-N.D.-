using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Character Movement Logic Data", menuName = "Data/Player/Execution/MovementLogic", order = 5)]
public class MovementLogic_ConfigData : ScriptableObject
{
    public MoveType[] MoveTypes;

    [System.Serializable]
    public struct MoveType
    {
        public CharacterMovType_ConfigData Idle;
        public CharacterMovType_ConfigData Move;
    }
    #region OldTest
    //[HideInInspector]
    //public float[,] MinSpeedValues;

    //public void Init(CharacterMovLogicType_ConfigData[] _movementTypeDatas)
    //{
    //    MinSpeedValues = SetupMinSpeedArray(_movementTypeDatas, PossibleHeights(_movementTypeDatas));
    //}

    //private float[] PossibleHeights(CharacterMovLogicType_ConfigData[] _movementTypeDatas)
    //{
    //    List<float> _heightsTemp = new List<float>();

    //    for (int i = 0; i < _movementTypeDatas.Length; i++)
    //    {
    //        if (_heightsTemp.Count == 0)
    //        {
    //            _heightsTemp.Add(_movementTypeDatas[i].Height);
    //        }
    //        else
    //        {
    //            for (int j = 0; j < _heightsTemp.Count; j++)
    //            {
    //                if (_heightsTemp[j] == _movementTypeDatas[i].Height) break;
    //                else if (j == _heightsTemp.Count - 1) _heightsTemp.Add(_movementTypeDatas[i].Height);
    //            }
    //        }
    //    }

    //    return _heightsTemp.ToArray();
    //}

    //private float[,] SetupMinSpeedArray(CharacterMovLogicType_ConfigData[] _movementTypeDatas, float[] _height)
    //{
    //    float[,] _TempArray = new float[2, _height.Length];
    //    List<float> _TempSpeed = new List<float>();

    //    for (int i = 0; i < _TempArray.GetLength(1); i++)
    //    {
    //        _TempSpeed.Clear();

    //        _TempArray[0, i] = _height[i];

    //        for (int j = 0; j < _movementTypeDatas.Length; j++)
    //        {
    //            if (_movementTypeDatas[j].Height == _height[i]) _TempSpeed.Add(_movementTypeDatas[j].Speed);
    //        }

    //        _TempSpeed.Sort();

    //        _TempArray[1, i] = _TempSpeed[0];
    //    }

    //    return _TempArray;
    //}
    #endregion
}
