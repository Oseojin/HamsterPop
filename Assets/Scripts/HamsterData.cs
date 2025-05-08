using System;
using UnityEngine;

[Serializable]
public class HamsterData
{
    public int SeedPopSpeed = 0;
    public int SeedEatSpeed = 0;
    public int HamsterStomachCapacity = 0;
    public int HamsterDigestionSpeed = 0;
    public bool AutoGetSeed = false;

    public int Satiety = 0;
    public int CurrMotion = 0;
}
