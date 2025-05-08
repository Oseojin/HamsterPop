using System;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

[Serializable]
public class GameData
{
    public int Hamppy = 0;
    public int DecreaseSeedCal = 0;
    public int IncreaseSeedQuality = 0;
    public int HamsterAmount = 0;
    public List<HamsterData> HamsterList = new List<HamsterData>();

    public int SeedAmount = 0;
}