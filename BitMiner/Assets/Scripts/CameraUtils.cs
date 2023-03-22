using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraUtils : MonoBehaviour
{
    [SerializeField] private Animator cameraAnimator;
    private const string cameraShake = "Shake";

    public void ShakeCamera()
    {
        cameraAnimator.SetTrigger(cameraShake);
    }
}
