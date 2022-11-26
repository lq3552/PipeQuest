using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReferToScriptable : MonoBehaviour
{
    [SerializeField] PipeComponent pipeComponent;

    public PipeComponent GetReference()
    {
        return pipeComponent;
    }
}
