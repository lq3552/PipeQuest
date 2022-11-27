using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeInventory
{
    private List<Pipe> pipeList;

    public PipeInventory()
    {
        pipeList = new List<Pipe>();
    }

    public void AddPipe(Pipe pipe)
    {
        pipeList.Add(pipe);
    }

    public List<Pipe> GetPipeList()
    {
        return pipeList;
    }
}
