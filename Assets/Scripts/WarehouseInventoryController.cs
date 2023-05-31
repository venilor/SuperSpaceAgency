using System.Collections;
using System.Collections.Generic;
using FarrokhGames.Inventory;
using UnityEngine;

[RequireComponent(typeof(InventoryRenderer))]
public class WarehouseInventoryController : MonoBehaviour {

	[SerializeField] private int _width = 6;
	[SerializeField] private int _height = 3;
	
	private List<ItemDefinition> _itemDefinitions;

	// Use this for initialization
	private void Start()
	{
		_itemDefinitions = new List<ItemDefinition>();
		InitializeInventory();
	}

	private void InitializeInventory()
	{
		var inventory = new InventoryManager(_width, _height);

        for(int i = 0; i < _itemDefinitions.Count; i++)
        {
            inventory.Add(_itemDefinitions[i].CreateInstance());
        }

        GetComponent<InventoryRenderer>().SetInventory(inventory);
	}

	public void AddItemDefinition(ItemDefinition item)
	{
		_itemDefinitions.Add(item);
		InitializeInventory();
	}
}
