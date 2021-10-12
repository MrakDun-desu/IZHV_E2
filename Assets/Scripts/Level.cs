using System;
using UnityEngine;

[Serializable]
public class Level
{
    public float timePassed;
    [Range(1, 5)] public float speedMultiplier;
    [Range(0, 1)] public float spawnMultiplier;
}