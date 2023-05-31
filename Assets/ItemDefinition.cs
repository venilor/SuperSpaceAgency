using System.Runtime.InteropServices;
using UnityEngine;
using FarrokhGames.Inventory;

/// <summary>
/// Scriptable Object representing an Inventory Item
/// </summary>
[CreateAssetMenu(fileName = "Item", menuName = "Inventory/Item", order = 1)]
public class ItemDefinition : ScriptableObject, IInventoryItem
{
    [SerializeField] private Sprite _sprite;
    [SerializeField] private InventoryShape _shape;

    [SerializeField] private int _weight;
    [SerializeField] private int _food;
    [SerializeField] private int _water;
    [SerializeField] private int _readiness;
    [SerializeField] private int _fuel;
    [SerializeField] private string _type;
    [SerializeField] private string _fullName;
    [SerializeField] private string _description;
    [SerializeField] private int _cost;
    
    public int Weight { get { return _weight; } }
    public int Food { get { return _food; } }
    public int Water { get { return _water; } }
    public int Readiness { get { return _readiness; } }
    public int Fuel { get { return _fuel; } }
    public string Type { get { return _type; } }
    public string FullName { get { return _fullName; } }
    public string Description { get { return _description; } }
    public int Cost { get { return _cost; } }

    public string Name { get { return this.name; } }
    public Sprite Sprite { get { return _sprite; } }
    public InventoryShape Shape { get { return _shape; } }

    /// <summary>
    /// Creates a copy if this scriptable object
    /// </summary>
    public IInventoryItem CreateInstance()
    {
        return ScriptableObject.Instantiate(this);
    }
}