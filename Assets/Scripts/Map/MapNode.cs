using UnityEngine;
using System.Collections.Generic;

public enum DoorSide
{ 
    Top,
    Left,
    Right,
    Bottom
}
public abstract class MapNode : MonoBehaviour
{
    public List<MapNode> Children { get; private set; }
}

[CreateAssetMenu(fileName = "New block stats", menuName = "Scriptables/Block")]
public class BlockMapNodeSO : ScriptableObject
{
    #region Sets

    [SerializeField]
    private int _children;
    [SerializeField]
    private int _width;
    [SerializeField]
    private int _height;

    #endregion

    #region Gets

    public int Children { get => _children; }
    public int Width { get => _width; }
    public int Height { get => _height; }
    

    #endregion
}

[CreateAssetMenu(fileName = "New building stats", menuName = "Scriptables/Building")]
public class BuildingMapNodeSO : ScriptableObject
{

    #region Sets

    [SerializeField]
    private bool _isRepeatableInWorld;
    [SerializeField]
    private int _amountPerWorld;
    [SerializeField]
    private bool _isRepeatableInCity;
    [SerializeField]
    private int _amountPerCity;
    [SerializeField]
    private bool _isKeyBuilding;
    [SerializeField]
    [Range(1, 2)]
    /// <summary>Ancho que ocupa el edificio en la manzana.</summary>
    private int _widthOnBlock;
    [SerializeField]
    [Range(1, 2)]
    ///<summary>Alto que ocupa el edificio en la manzana.</summary>
    private int _heightOnBlock;
    [SerializeField]
    private DoorSide _door;

    #endregion

    #region Gets

    public bool IsRepeatableInWorld => _isRepeatableInWorld; 
    public int AmountPerWorld => _amountPerWorld; 
    public bool IsRepeatableInCity => _isRepeatableInCity; 
    public int AmountPerCity => _amountPerCity; 
    public bool IsKeyBuilding => _isKeyBuilding; 
    public int WidthOnBlock => _widthOnBlock;
    public int HeightOnBlock => _heightOnBlock;
    public DoorSide Door => _door;

    #endregion
}