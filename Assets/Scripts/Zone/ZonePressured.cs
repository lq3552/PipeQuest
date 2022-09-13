using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZonePressured : ZoneAddForce
{
    protected override void Start()
    {
        base.Start();
        forceMagnitude = 2.5f;
    }
}