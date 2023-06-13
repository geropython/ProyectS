using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class City : MapNode
{
    public List<Block> Blocks { get; private set; }

    public int AmountOfKeyBuildings { get; set; }
}
