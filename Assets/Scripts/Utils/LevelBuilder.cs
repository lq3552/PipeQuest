using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBuilder : MonoBehaviour
{
    [SerializeField] GameObject gasParticle;
    GameObject parentGasParticle;
    Vector3 referencePosition;
    int numLayers;
    int numParticleAtFirstLayer;
    int numParticleIncrement;
    float spatialInterval;

    void Awake()
    {
        parentGasParticle = GameObject.Find("Natural Gas");
        referencePosition = new Vector3(0.83f, 3.04f, 0);
        numLayers = 20;
        numParticleAtFirstLayer = 7;
        numParticleIncrement = 2;
        spatialInterval = 0.16f / 3.0f;
        SpawnGasParticle();
    }

    /// <summary>
    /// spawn gas particle based on reference position, layers, spatial interval
    /// number of particles at the first layer and increment per layer
    /// </summary>
    void SpawnGasParticle()
    {
        int numParticleAtLayer = numParticleAtFirstLayer;
        for (int i = 0; i < numLayers; i++)
        {
            for (int j = 0; j < numParticleAtLayer; j++)
            {
                Instantiate(gasParticle,
                            referencePosition + new Vector3(spatialInterval * j, 0, 0),
                            Quaternion.identity, parentGasParticle.transform);
            }
            numParticleAtLayer += numParticleIncrement;
            referencePosition += new Vector3(-spatialInterval,
                                             spatialInterval,
                                             0);
        }
    }
}
