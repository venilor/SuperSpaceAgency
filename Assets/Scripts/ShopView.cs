using UnityEngine;
using UnityEngine.UI;

public class ShopView : MonoBehaviour
{
	[SerializeField] private ItemDefinition[] _shopItems;
	[SerializeField] private GameObject _shopContent;
	[SerializeField] private GameObject _itemButton;

	[SerializeField] private GameObject _shopDetailImage;
	[SerializeField] private GameObject _shopDetailTitle;
	[SerializeField] private GameObject _shopDetailInfo;

	[SerializeField] private GameObject _shopPurchaseButton;

	[SerializeField] private WarehouseInventoryController _warehouse;

	[SerializeField] private GameObject _balanceText;
	[SerializeField] private int _funds;

    public AudioSource kaching;
	
	private void Start()
	{
        _funds = GeneralManager.instance.GetMission().Funds;
		_balanceText.GetComponent<Text>().text = "$" + _funds;
        kaching = this.gameObject.GetComponent<AudioSource>();
			
		foreach (var shopItem in _shopItems)
		{
			GameObject tempObject = Instantiate(_itemButton);
			tempObject.transform.GetChild(0).GetComponent<Image>().sprite = shopItem.Sprite;
			tempObject.transform.GetChild(0).GetComponent<Image>().preserveAspect = true;

			tempObject.transform.SetParent(_shopContent.transform);
			tempObject.transform.localScale = Vector2.one;

			tempObject.GetComponent<Button>().onClick.AddListener(() => SelectItem(shopItem));
		}


	}

	private void SelectItem(ItemDefinition item)
	{
		_shopDetailImage.GetComponent<Image>().sprite = item.Sprite;
		_shopDetailImage.GetComponent<Image>().preserveAspect = true;
		if (!_shopDetailImage.activeSelf) _shopDetailImage.SetActive(true);
		_shopDetailTitle.GetComponent<Text>().text = item.FullName;

		var itemDetails = "Weight: " + item.Weight;

		if (item.Type != "modify")
		{
			if (item.Food > 0)
				itemDetails += "\n+" + item.Food + " to Food";
			
			if (item.Water > 0)
				itemDetails += "\n+" + item.Water + " to Water";
			
			if (item.Readiness > 0)
				itemDetails += "\n+" + item.Readiness + " to Crisis Readiness";
		}
		else
		{
			if (item.Food > 1)
				itemDetails += "\nx" + item.Food + " Food";
			
			if (item.Water > 1)
				itemDetails += "\nx" + item.Water + " Water";
			
			if (item.Readiness > 1)
				itemDetails += "\nx" + item.Readiness + " Crisis Readiness";
		}
		 
		_shopDetailInfo.GetComponent<Text>().text = itemDetails;
        _shopPurchaseButton.GetComponent<Button>().onClick.RemoveAllListeners();
		_shopPurchaseButton.GetComponent<Button>().onClick.AddListener(() => PurchaseItem(item));
		_shopPurchaseButton.transform.GetChild(0).GetComponent<Text>().text = "PURCHASE FOR $" + item.Cost + " ea.";
	}

	private void PurchaseItem(ItemDefinition item)
	{
		if (item.Cost >= _funds) return;
        kaching.Play();
		_warehouse.AddItemDefinition(item);
		_funds -= item.Cost;
        GeneralManager.instance.GetMission().Funds = _funds;
		_balanceText.GetComponent<Text>().text = "$" + _funds;
	}
}
