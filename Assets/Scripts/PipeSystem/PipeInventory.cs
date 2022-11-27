using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeInventory
{
    public static PipeInventory pipeInventory = new PipeInventory();

    public event EventHandler OnItemListChanged;

    private Dictionary<PipeMetaData, int> pipeHash;

    public PipeInventory()
    {
        pipeHash = new Dictionary<PipeMetaData, int>();
    }

    public void AddPipe(Pipe pipe)
    {
        AddPipe(pipe.PipeMetaData, pipe.Amount);
    }

    public void AddPipe(PipeMetaData pipeMetaData, int amount)
    {
        if (amount == 0)
            return;

        if (pipeHash.ContainsKey(pipeMetaData))
        {
            pipeHash[pipeMetaData] += amount;
        }
        else
        {
            pipeHash.Add(pipeMetaData, amount);
        }
        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }

    public void RemovePipe(Pipe pipe)
    {
        RemovePipe(pipe.PipeMetaData, pipe.Amount);
    }

    public void RemovePipe(PipeMetaData pipeMetaData, int amount)
    {
        if (amount == 0)
            return;

        if (pipeHash.ContainsKey(pipeMetaData))
        {
            pipeHash[pipeMetaData] -= amount;
            if (pipeHash[pipeMetaData] <= 0)
                pipeHash.Remove(pipeMetaData);
            OnItemListChanged?.Invoke(this, EventArgs.Empty);
        }
    }

    public Dictionary<PipeMetaData, int> GetPipeHash()
    {
        return pipeHash;
    }
}
