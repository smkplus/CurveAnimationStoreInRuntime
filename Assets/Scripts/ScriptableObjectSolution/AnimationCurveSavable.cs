using NaughtyAttributes;
using UnityEngine;

[System.Serializable]
public class AnimationCurveSavable 
{
    [SerializeField,Expandable] private AnimationData animationData;
    
    public void ClearAll()
    {
        animationData.animationCurve = new AnimationCurve();
    }
    
    public void AddKey(Keyframe keyframe)
    {
        animationData.animationCurve.AddKey(keyframe);
    }

    public float GetKeyAt(float time)
    {
        return animationData.animationCurve.Evaluate(time);
    }


}
