using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Character Movement Data", menuName = "Data/Player/Execution/Movement", order = 0)]

public class Movement_ConfigData : ScriptableObject
{
    public CharacterMovType_ConfigData[] characterMovType_Datas;
    public MovementAnimation_ConfigData AnimationData;

    public void Init(Animator _GObjAnimator)
    {
        AnimationData.Init(DataConvertForAnimationInit(), _GObjAnimator);
    }

    MovementAnimation_ConfigData.BlendData[] DataConvertForAnimationInit()
    {
        MovementAnimation_ConfigData.BlendData[] _blendDatas = new MovementAnimation_ConfigData.BlendData[characterMovType_Datas.Length];
        for (int i = 0; i < _blendDatas.Length; i++)
        {
            _blendDatas[i].m_animationClip = characterMovType_Datas[i].GraphicsData.m_Animation;
            _blendDatas[i]._xBlendValue = characterMovType_Datas[i].LogicData.Speed;
            _blendDatas[i]._yBlendValue = characterMovType_Datas[i].LogicData.Height;
        }
        return _blendDatas;
    }
}