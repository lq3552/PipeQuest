using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PipeComponent", menuName = "ScriptableObjects/PipeComponent")]
public class PipeComponent : ScriptableObject
{
    public GameObject pipeComponentPrefab;
    public int width;
    public int height;
}
