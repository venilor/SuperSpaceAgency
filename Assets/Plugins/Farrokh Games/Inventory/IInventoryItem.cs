using UnityEngine;

namespace FarrokhGames.Inventory
{
    public interface IInventoryItem
    {
        int Weight { get; }
        int Food { get; }
        int Water { get; }
        int Readiness { get; }
        int Fuel { get; }
        string Type { get; }
        string FullName { get; }
        string Description { get; }
        int Cost { get; }
        
        string Name { get; }
        Sprite Sprite { get; }
        InventoryShape Shape { get; }
    }
}