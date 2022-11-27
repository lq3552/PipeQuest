using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A container of pipe components
/// </summary>
public class PipeAssets : MonoBehaviour
{
    public static PipeAssets Container { get; private set; }

    private void Awake()
    {
        Container = this;
    }

    [field:SerializeField] public GameObject PrefabBurnerHorizontal { private set; get; }
    [field:SerializeField] public GameObject PrefabBurnerVertical { private set; get; }
    [field:SerializeField] public GameObject PrefabJointThreeWayDown { private set; get; }
    [field:SerializeField] public GameObject PrefabJointThreeWayLeft { private set; get; }
    [field:SerializeField] public GameObject PrefabJointThreeWayRight { private set; get; }
    [field:SerializeField] public GameObject PrefabJointThreeWayUp { private set; get; }
    [field:SerializeField] public GameObject PrefabJointTwoWayLeftDown { private set; get; }
    [field:SerializeField] public GameObject PrefabJointTwoWayRightDown { private set; get; }
    [field:SerializeField] public GameObject PrefabJointTwoWayUpLeft { private set; get; }
    [field:SerializeField] public GameObject PrefabJointTwoWayUpRight { private set; get; }
    [field:SerializeField] public GameObject PrefabPipeDraggyHorizontal { private set; get; }
    [field:SerializeField] public GameObject PrefabPipeDraggyVertical { private set; get; }
    [field:SerializeField] public GameObject PrefabPipeNormalHorizontal { private set; get; }
    [field:SerializeField] public GameObject PrefabPipeNormalVertical { private set; get; }
    [field:SerializeField] public GameObject PrefabPipePressuredDown { private set; get; }
    [field:SerializeField] public GameObject PrefabPipePressuredLeft { private set; get; }
    [field:SerializeField] public GameObject PrefabPipePressuredRight { private set; get; }
    [field:SerializeField] public GameObject PrefabPipePressuredUp { private set; get; }
    [field:SerializeField] public GameObject PrefabPump { private set; get; }
    [field:SerializeField] public GameObject PrefabReceiver { private set; get; }
}
