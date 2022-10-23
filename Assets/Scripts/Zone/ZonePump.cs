using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZonePump : ZoneAddForce
{
    protected override void Start()
    {
        if (forceMagnitude <= 0f)
            forceMagnitude = 5.0f;
        base.Start();
    }
}
