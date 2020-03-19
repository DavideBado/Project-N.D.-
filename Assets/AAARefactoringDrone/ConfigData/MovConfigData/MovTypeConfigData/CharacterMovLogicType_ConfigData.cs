using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

[CreateAssetMenu(fileName = "New Character Movement Type Logic Data", menuName = "Data/Player/Execution/MovementTypeLogic", order = 2)]
public class CharacterMovLogicType_ConfigData : ScriptableObject
{
    public float Speed;
    public float Height;
}
