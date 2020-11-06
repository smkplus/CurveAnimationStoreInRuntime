using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AnimationCurveJson 
{
    public AnimationCurve animationCurve;

    public SaveObject saveObject = new SaveObject();
    
    public void AddKey(Keyframe keyframe)
    {
        animationCurve.AddKey(keyframe);
        saveObject.AddKey(keyframe);
    }

    public float GetKeyAt(float time)
    {
        return animationCurve.Evaluate(time);
    }
}
[System.Serializable]
public class SaveObject
{

    public List<float> Time = new List<float>();
    public List<float> Value = new List<float>();
        
    public void AddKey(Keyframe keyframe)
    {
        Time.Add(keyframe.time);   
        Value.Add(keyframe.value);   
    }
}