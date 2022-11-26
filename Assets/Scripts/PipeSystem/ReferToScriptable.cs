using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReferToScriptable : MonoBehaviour
{
    [SerializeField] PipeMetaData pipeComponent;

    public PipeMetaData GetReference()
    {
        return pipeComponent;
    }
}
