using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

[CreateAssetMenu(fileName = "New Character Movement Type Graphic Data", menuName = "Data/Player/Execution/MovementTypeGraphic", order = 3)]
public class CharacterMovTypeGraphic_ConfigData : ScriptableObject
{
    public GameObject CameraPrefab;
    [HideInInspector]
    public CinemachineVirtualCameraBase m_VirtualCamera;
    public AnimationClip m_Animation;
}
