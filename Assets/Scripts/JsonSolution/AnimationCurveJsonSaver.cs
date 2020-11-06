using System.IO;
using System.Linq;
using NaughtyAttributes;
using UnityEngine;

public class AnimationCurveJsonSaver : MonoBehaviour
{
    [SerializeField] private bool isRecording;

    [SerializeField] private Transform target;
    [SerializeField] private AnimationCurveJson[] animationCurveJson;


    private void Awake()
    {
        if (!isRecording)
        {
            LoadJson();
            print("Load Successfully");
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
        animationCurveJson[0].AddKey(new Keyframe(Time.time, position.x));
        animationCurveJson[1].AddKey(new Keyframe(Time.time, position.y));
        animationCurveJson[2].AddKey(new Keyframe(Time.time, position.z));
    }
    
    private void LoadPosition()
    {
        print(animationCurveJson[0].GetKeyAt(Time.time));
        target.position = new Vector3(
            animationCurveJson[0].GetKeyAt(Time.time),
            animationCurveJson[1].GetKeyAt(Time.time),
            animationCurveJson[2].GetKeyAt(Time.time)
        );
    }

    private void OnApplicationQuit()
    {
        if (isRecording)
        {
            SaveJson();
            print("Saved Successfully");
        }
    }

    private void SaveJson()
    {
        print(Application.persistentDataPath + "/save.txt");
        var saveObjects = animationCurveJson.Select(x => x.saveObject).ToArray();
        var json = JsonHelper.ToJson(saveObjects, true);
        File.WriteAllText(Application.persistentDataPath + "/save.txt", json);
    }

    private void LoadJson()
    {
        var data = File.ReadAllText(Application.persistentDataPath + "/save.txt");
        var json = JsonHelper.FromJson<SaveObject>(data);
        for (int index = 0; index < animationCurveJson.Length; index++)
        {
            for (var i = 0; i < json[index].Time.Count; i++)
            {
                animationCurveJson[index].AddKey(new Keyframe(json[index].Time[i], json[index].Value[i]));
            }
        }
    }
}