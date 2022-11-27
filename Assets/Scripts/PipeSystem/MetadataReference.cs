using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetadataReference : MonoBehaviour
{
    [SerializeField] PipeMetaData pipeMetaData;

    public PipeMetaData GetMetaData()
    {
        return pipeMetaData;
    }

    public void SetMetaData(PipeMetaData pipeMetaData)
    {
        this.pipeMetaData = pipeMetaData;
    }
}
