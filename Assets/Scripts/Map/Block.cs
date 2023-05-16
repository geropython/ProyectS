using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MapNode
{
    [SerializeField]
    private BlockMapNodeSO _settings;

    private int[,] _blockMap;

    public int AvaliableSpace { get; private set; }

    private void Awake()
    {
        _blockMap = new int[_settings.Width, _settings.Height];
        AvaliableSpace = _settings.Width * _settings.Height;
    }

    public BlockMapNodeSO Settings { get => _settings; }

    /// <summary>
    /// Agrega el edificio a la manzana.
    /// </summary>
    /// <param name="building"></param>
    /// <returns>True si agrego el edificio a la manzana. - False si no habia espacio para agregarlo.</returns>
    public bool AddBuilding(Building building)
    {
        if (CheckForSpace(building))
            Children.Add(building);
        return true;
    }

    #region Metodos Privados

    private bool CheckForSpace(Building building) => (AvaliableSpace > building.TotalTileSize) ? CheckIfFits(building) : false;

    private bool CheckIfFits(Building building)
    {
        switch (building.Settings.Door)
        {
            case DoorSide.Top: 
                return CheckIfFitsTop(building.Settings.WidthOnBlock);
            case DoorSide.Left:
                return CheckIfFitsLeft(building.Settings.HeightOnBlock);
            case DoorSide.Right:
                return CheckIfFitsRight(building.Settings.HeightOnBlock);
            case DoorSide.Bottom:
                return CheckIfFitsBottom(building.Settings.WidthOnBlock);
        }
        throw new ArgumentException();
    }

    private bool CheckIfFitsTop(int size)
    {
        for (int i = 0; i < _settings.Width; i++)
        {

        }
    }

    private bool CheckIfFitsBottom(int size)
    {
        for (int i = 0; i < _settings.Width; i++)
        {

        }
    }

    private bool CheckIfFitsLeft(int size)
    {
        for (int i = 0; i < _settings.Height; i++)
        {

        }
    }
    private bool CheckIfFitsRight(int size)
    {
        for (int i = 0; i < _settings.Height; i++)
        {

        }
    }
    #endregion
}
