using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

//[RequireComponent(typeof(GeneralManager))]
public class MissionView : MonoBehaviour
{
	[SerializeField] private Text _missionName;
	[SerializeField] private Text _missionDetails;
	[SerializeField] private Text _missionFundingNumber;

	[SerializeField] private GameObject _popupPanel;
	[SerializeField] private Text _missionStatus;
	[SerializeField] private Text _missionStatement;
	[SerializeField] private Text _missionSavedMoney;
   
	
	// Use this for initialization
	private void Start ()
	{
        _missionName.text = GeneralManager.instance.GetMission().Name;
        
		var missionDetails = "";
		missionDetails += "The size of this mission's crew is " + GeneralManager.instance.GetMission().AstronautCount + ".\n";
		missionDetails += "This mission will last " + GeneralManager.instance.GetMission().Duration + " days.\n";
		missionDetails += "The spacecraft we're launching prefers a maximum weight of " +
		                  GeneralManager.instance.GetMission().MaxWeight + ".\n";
		_missionDetails.text = missionDetails;

		_missionFundingNumber.text = "$" + GeneralManager.instance.GetMission().StartingFunds;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void LaunchMission()
	{
		_popupPanel.SetActive(true);
        GameObject.Find("Manager").GetComponent<GeneralManager>().LaunchMission();
		bool isSuccess = GeneralManager.instance.GetMission().CheckWin();
		if (isSuccess)
		{
			_missionStatus.text = "MISSION SUCCESS";
			_missionStatement.text = GeneralManager.instance.GetMission().MissionStatement;
			_missionSavedMoney.text = GeneralManager.instance.GetMission().SavedMoney.ToString();
		}
		else
		{
			_missionStatus.text = "MISSION FAILURE";
			_missionStatement.text = GeneralManager.instance.GetMission().MissionStatement;
			_missionSavedMoney.text = "NO MONEY SAVED";
		}
	}

	public void ClosePopup()
	{
		_popupPanel.SetActive(false);
	}
}
