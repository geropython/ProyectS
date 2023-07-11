using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MapNode
{
    [SerializeField]
    private BuildingMapNodeSO _settings;

    public BuildingMapNodeSO Settings { get => _settings; }
    public int TotalTileSize;

    private void Awake()
    {
        TotalTileSize = _settings.WidthOnBlock + _settings.HeightOnBlock;
    }
}
