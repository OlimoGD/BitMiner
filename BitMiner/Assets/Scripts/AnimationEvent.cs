using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEvent : MonoBehaviour
{
    public delegate void AnimationFinishedDelegate(string animationName);
    public event AnimationFinishedDelegate OnAnimationFinished;
    public void AnimationFinished(string animationName)
    {
        OnAnimationFinished?.Invoke(animationName);
    }
}
