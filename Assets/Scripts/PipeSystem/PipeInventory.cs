using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeInventory
{
    public event EventHandler OnItemListChanged;

    private Dictionary<PipeMetaData, int> pipeHash;

    public PipeInventory()
    {
        pipeHash = new Dictionary<PipeMetaData, int>();
    }

    public void AddPipe(Pipe pipe)
    {
        if (pipeHash.ContainsKey(pipe.PipeMetaData))
        {
            pipeHash[pipe.PipeMetaData] += pipe.Amount;
        }
        else
        {
            pipeHash.Add(pipe.PipeMetaData, pipe.Amount);
            OnItemListChanged?.Invoke(this, EventArgs.Empty);
        }
    }

    public Dictionary<PipeMetaData, int> GetPipeHash()
    {
        return pipeHash;
    }
}
