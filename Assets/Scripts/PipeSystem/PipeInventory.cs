using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeInventory
{
    private List<Pipe> pipeList;

    public PipeInventory()
    {
        pipeList = new List<Pipe>();
        /*
        AddPipe(new Pipe { PipeMetaData = ScriptableObject.CreateInstance<PipeMetaData>(), Amount = 3 });
        AddPipe(new Pipe { PipeMetaData = ScriptableObject.CreateInstance<PipeMetaData>(), Amount = 0 });
        AddPipe(new Pipe { PipeMetaData = ScriptableObject.CreateInstance<PipeMetaData>(), Amount = 5 });
        AddPipe(new Pipe { PipeMetaData = ScriptableObject.CreateInstance<PipeMetaData>(), Amount = 8 });
        AddPipe(new Pipe { PipeMetaData = ScriptableObject.CreateInstance<PipeMetaData>(), Amount = 2 });
        AddPipe(new Pipe { PipeMetaData = ScriptableObject.CreateInstance<PipeMetaData>(), Amount = 6 });
        */
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
