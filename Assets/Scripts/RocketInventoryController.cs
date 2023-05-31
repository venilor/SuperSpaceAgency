using System.Collections;
using System.Collections.Generic;
using FarrokhGames.Inventory;
using UnityEngine;
using UnityEngine.Analytics;

[RequireComponent(typeof(InventoryRenderer))]
public class RocketInventoryController : MonoBehaviour {
	
	[SerializeField] private int _width = 8;
	[SerializeField] private int _height = 4;
	[SerializeField] private ItemDefinition[] _definitions;
	
	// Use this for initialization
	private void Start ()
	{
		
		var inventory = new InventoryManager(_width, _height)
		{
			OnItemAdded = delegate(IInventoryItem item) { GeneralManager.instance.GetMission().Add(item); }
		};

        inventory.OnItemRemoved = delegate (IInventoryItem item) { GeneralManager.instance.GetMission().Remove(item); };

		GetComponent<InventoryRenderer>().SetInventory(inventory);
	}
	
	// Update is called once per frame
	private void Update () {
		
	}
}
