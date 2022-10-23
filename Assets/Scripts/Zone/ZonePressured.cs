using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZonePressured : ZoneAddForce
{
    protected override void Start()
    {
        if (forceMagnitude <= 0f)
            forceMagnitude = 2.5f;
        base.Start();
    }
}