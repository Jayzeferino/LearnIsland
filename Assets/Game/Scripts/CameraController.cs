using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public CharacterMovement characterMovement;
    public Transform CameraTarget;
    public float TargetHeight = 1f;

    public Vector2 XRotationRange = new Vector2(-70, 70);
    private Vector2 targetLook;

    public Quaternion LookRotation => CameraTarget.rotation;

    private void LateUpdate()
    {
        CameraTarget.transform.SetPositionAndRotation(characterMovement.transform.position + Vector3.up * TargetHeight, Quaternion.Euler(targetLook.x, targetLook.y, 0));
    }

    public void IncrementLookRotation(Vector2 lookdelta)
    {
        targetLook += lookdelta;
        targetLook.x = Mathf.Clamp(targetLook.x, XRotationRange.x, XRotationRange.y);
    }


}
