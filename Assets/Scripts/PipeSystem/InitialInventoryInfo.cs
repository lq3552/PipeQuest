using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialInventoryInfo : MonoBehaviour
{
    [field: SerializeField] public List<PipeMetaData> PipeTypeList { private set; get; }
    [field: SerializeField] public List<int> PipeAmountList { private set; get; }
}
