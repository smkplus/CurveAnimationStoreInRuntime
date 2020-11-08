using System;
using NaughtyAttributes;
using UnityEngine;

public class RecordAnimation : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private bool isRecording;
    [SerializeField, ReorderableList] private AnimationCurveSavable[] animationCurveSavable;

    private void Awake()
    {
        if (isRecording)
        {
            animationCurveSavable[0].ClearAll();
            animationCurveSavable[1].ClearAll();
            animationCurveSavable[2].ClearAll();
        }
    }

    private void Update()
    {
        if (isRecording)
        {
            RecordPosition();
        }
        else
        {
            LoadPosition();
        }
    }

    private void RecordPosition()
    {
        var position = target.position;
        animationCurveSavable[0].AddKey(new Keyframe(Time.time, position.x));
        animationCurveSavable[1].AddKey(new Keyframe(Time.time, position.y));
        animationCurveSavable[2].AddKey(new Keyframe(Time.time, position.z));
    }

    private void LoadPosition()
    {
        target.position = new Vector3(
            animationCurveSavable[0].GetKeyAt(Time.time),
            animationCurveSavable[1].GetKeyAt(Time.time),
            animationCurveSavable[2].GetKeyAt(Time.time)
        );
    }
}