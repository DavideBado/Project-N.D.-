using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPlanning : PlanningPhaseState
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        GameManager.instance.InFirstPlanning = true;
        base.OnStateEnter(animator, stateInfo, layerIndex);
    }
}
