using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondPlanning : PlanningPhaseState
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        GameManager.instance.InFirstPlanning = false;
        base.OnStateEnter(animator, stateInfo, layerIndex);
    }
}
