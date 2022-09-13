using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneDraggy : ZoneAddForce
{
    protected override void Start()
    {
        base.Start();
        forceMagnitude = -1.25f;
    }
}
