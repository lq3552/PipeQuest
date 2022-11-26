using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScriptableObjects : MonoBehaviour
{
    [SerializeField] private PipeComponent testScriptableObject;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(testScriptableObject.myString);
    }

}
