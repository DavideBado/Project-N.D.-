using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

[CreateAssetMenu(fileName = "New Character Movement Type Data", menuName = "Data/Player/Execution/MovementType", order = 1)]
public class CharacterMovType_ConfigData : ScriptableObject
{
    public CharacterMovTypeGraphic_ConfigData GraphicsData;
    public CharacterMovLogicType_ConfigData LogicData;
}
