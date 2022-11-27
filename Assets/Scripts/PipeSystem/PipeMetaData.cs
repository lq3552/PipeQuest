using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PipeMetaData", menuName = "ScriptableObjects/PipeMetaData")]
public class PipeMetaData : ScriptableObject
{
    public enum PipeType
    {
        BurnerHorizontal,
        BurnerVertical,
        JointThreeWayDown,
        JointThreeWayLeft,
        JointThreeWayRight,
        JointThreeWayUp,
        JointTwoWayLeftDown,
        JointTwoWayRightDown,
        JointTwoWayUpLeft,
        JointTwoWayUpRight,
        PipeDraggyHorizontal,
        PipeDraggyVertical,
        PipeNormalHorizontal,
        PipeNormalVertical,
        PipePressuredDown,
        PipePressuredLeft,
        PipePressuredRight,
        PipePressuredUp,
        Pump,
        Receiver
    }

    public PipeType pipeType;
    public int width;
    public int height;

    public GameObject GetPipeAsset()
    {
        switch (pipeType)
        {
            default: return null;
            case PipeType.BurnerHorizontal: return PipeAssets.Container.PrefabBurnerHorizontal;
            case PipeType.BurnerVertical: return PipeAssets.Container.PrefabBurnerVertical;
            case PipeType.JointThreeWayDown: return PipeAssets.Container.PrefabJointThreeWayDown;
            case PipeType.JointThreeWayLeft: return PipeAssets.Container.PrefabJointThreeWayLeft;
            case PipeType.JointThreeWayRight: return PipeAssets.Container.PrefabJointThreeWayRight;
            case PipeType.JointThreeWayUp: return PipeAssets.Container.PrefabJointThreeWayUp;
            case PipeType.JointTwoWayLeftDown: return PipeAssets.Container.PrefabJointTwoWayLeftDown;
            case PipeType.JointTwoWayRightDown: return PipeAssets.Container.PrefabJointTwoWayRightDown;
            case PipeType.JointTwoWayUpLeft: return PipeAssets.Container.PrefabJointTwoWayUpLeft;
            case PipeType.JointTwoWayUpRight: return PipeAssets.Container.PrefabJointTwoWayUpRight;
            case PipeType.PipeDraggyHorizontal: return PipeAssets.Container.PrefabPipeDraggyHorizontal;
            case PipeType.PipeDraggyVertical: return PipeAssets.Container.PrefabPipeDraggyVertical;
            case PipeType.PipeNormalHorizontal: return PipeAssets.Container.PrefabPipeNormalHorizontal;
            case PipeType.PipeNormalVertical: return PipeAssets.Container.PrefabPipeNormalVertical;
            case PipeType.PipePressuredDown: return PipeAssets.Container.PrefabPipePressuredDown;
            case PipeType.PipePressuredLeft: return PipeAssets.Container.PrefabPipePressuredLeft;
            case PipeType.PipePressuredRight: return PipeAssets.Container.PrefabPipePressuredRight;
            case PipeType.PipePressuredUp: return PipeAssets.Container.PrefabPipePressuredUp;
            case PipeType.Pump: return PipeAssets.Container.PrefabPump;
            case PipeType.Receiver: return PipeAssets.Container.PrefabReceiver;
        }
    }

    public int[,] GetSpatialSpan()
    {
        int[,] spatialSpan = new int[width * height, 2];
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                int index = x * height + y;
                spatialSpan[index, 0] = x;
                spatialSpan[index, 1] = y;
            }
        }
        return spatialSpan;
    }
}
