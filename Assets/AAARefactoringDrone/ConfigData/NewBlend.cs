using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.Animations;

public class NewBlend : BlendTree
{
    
}

public class A : MonoBehaviour
{
    public Animator anim;

    AnimatorController x;

    private void Start()
    {
        x = new AnimatorController();
        
    }
}
