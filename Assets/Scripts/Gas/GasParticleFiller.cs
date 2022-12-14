using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasParticleFiller : MonoBehaviour
{
    [SerializeField] GameObject gasParticle;
    GameObject parentGasParticle;
    Vector3 referencePosition;
    int numLayers;
    int numParticleAtLayer;
    int numParticleIncrement;
    float spatialInterval;

    private void Start()
    {
        parentGasParticle = GameObject.Find("Natural Gas");
        referencePosition = new Vector3(1.9083f, 0.203f, 0) + transform.position;
        numLayers = 25;
        numParticleAtLayer = 9;
        numParticleIncrement = 2;
        spatialInterval = 0.16f / 3.0f;
        SpawnGasParticleAtBegining();
    }

    /// <summary>
    /// spawn gas particle at the beginning of a game session,
    /// based on reference position, layers, spatial interval
    /// number of particles at the first layer and increment per layer
    /// </summary>
    private void SpawnGasParticleAtBegining()
    {
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
