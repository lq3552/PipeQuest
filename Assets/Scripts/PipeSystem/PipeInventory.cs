using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeInventory : MonoBehaviour
{
    public static PipeInventory pipeInventory;

    public event EventHandler OnItemListChanged;

    private Dictionary<PipeMetaData, int> pipeHash;

    private void Awake()
    {
        if(pipeInventory != null)
        {
            Destroy(gameObject);
            return;
        }
        pipeInventory = this;

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

    public void EmptyPipeInventory()
    {
        pipeHash.Clear();
    }

    public Dictionary<PipeMetaData, int> GetPipeHash()
    {
        return pipeHash;
    }
}
