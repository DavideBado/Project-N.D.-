using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.Animations;
public class NewBlend : BlendTree
{
    
}
#endif

public class A : MonoBehaviour
{
    public Animator anim;
#if UNITY_EDITOR
    AnimatorController x;
    private void Start()
    {
        x = new AnimatorController();
        
    }
#endif
}
