using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.Animations;

[CreateAssetMenu(fileName = "New Character Movement Animation Data", menuName = "Data/Player/Execution/MovementAnimation", order = 4)]

public class MovementAnimation_ConfigData : ScriptableObject
{
    AnimatorController m_AnimatorController;
    BlendTree m_BlendTree;

    private void Awake()
    {
#if UNITY_EDITOR
        if (m_BlendTree) Destroy(m_BlendTree);
        if (m_AnimatorController) Destroy(m_AnimatorController);
#endif
    }

    public void Init(BlendData[] _blendDatas, Animator _GObjAnimator)
    {
#if UNITY_EDITOR
        if (!m_BlendTree) GenerateBlendTree(_blendDatas);
        if (!m_AnimatorController) GenerateAnimatorController();
#endif
        SetAnimator(_GObjAnimator);
    }

    #region BlendTree
    private void GenerateBlendTree(BlendData[] _blendDatas)
    {
        m_BlendTree = new BlendTree
        {
            name = "MovementBlend",
            blendType = BlendTreeType.FreeformDirectional2D

        };

        for (int i = 0; i < _blendDatas.Length; i++)
        {
            AnimationClip _animClip = _blendDatas[i].m_animationClip;
            float _x = _blendDatas[i]._xBlendValue;
            float _y = _blendDatas[i]._yBlendValue;
            m_BlendTree.AddChild(_animClip, new Vector2(_x, _y));
        }
    }

    public struct BlendData
    {
        public AnimationClip m_animationClip;
        public float _xBlendValue;
        public float _yBlendValue;
    }

    #endregion

    #region AnimatorController
    private void GenerateAnimatorController()
    {
        m_AnimatorController = AnimatorController.CreateAnimatorControllerAtPath("Assets/AAARefactoringDrone/ConfigData/MovConfigData/##TEST##/AnimatorControllers/NewAnimatorController");

        m_AnimatorController.name = "CharacterAnimController";

        m_AnimatorController.AddLayer("Movement");

        m_AnimatorController.AddMotion(m_BlendTree);

        m_AnimatorController.AddParameter("Speed", AnimatorControllerParameterType.Float);
        m_AnimatorController.AddParameter("Height", AnimatorControllerParameterType.Float);

        m_BlendTree.blendParameter = "Speed";
        m_BlendTree.blendParameterY = "Height";
    }
    #endregion

    #region Animator
    private void SetAnimator(Animator _Animator)
    {
        _Animator.runtimeAnimatorController = m_AnimatorController as RuntimeAnimatorController;
    }
    #endregion
}