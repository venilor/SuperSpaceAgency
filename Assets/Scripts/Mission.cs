
using FarrokhGames.Inventory;
using UnityEngine;
using System;
using System.Collections;

public class Mission
{
	private string _name;
	private int _food;
	private int _water;
	private int _readiness;
	private int _weight;
	private int _funds;
	private int _startingFunds;
	private int _astronautCount;
	private int _duration;
    private bool _modFood;
    private bool _modWater;

    private int _reqFood;
    private int _reqWater;
    private int _maxWeight;
    private float _riskChance;
    private string _missionStatement;
    private int _savedMoney;

    public Mission(string name = "Orion", int food = 0, int water = 0, int readiness = 0, int weight = 0, int funds = 0, int astronautCount = 0, int duration = 0, int maxWeight = 0, float riskChance = 0)
    {
	    _name = name;
		_food = food;
		_water = water;
		_readiness = readiness;
		_weight = weight;
		_funds = funds;
		_startingFunds = funds;
		_astronautCount = astronautCount;
		_duration = duration;

        _reqFood = _duration * _astronautCount;
        _reqWater = duration * _astronautCount;
        _maxWeight = maxWeight;
        _riskChance = riskChance;
	}

    public Mission()
    {
        _name = "Orion";
        _food = 0;
        _water = 0;
        _readiness = 0;
        _weight = 0;
        _funds = 10000;
        _startingFunds = 10000;
        _astronautCount = 4;
        _duration = 36;

        _reqFood = _duration * _astronautCount;
        _reqWater = _duration * _astronautCount;
        _maxWeight = 600;
        _riskChance = 5f;
    }

	public void Add(IInventoryItem item)
	{
		if (item.Type == "modify")
		{
			Modify(item);
		}
		else
		{
			_food += item.Food;
			_water += item.Water;
			_readiness += item.Readiness;
		}

		_weight += item.Weight;
	}

    public void Remove(IInventoryItem item)
    {
        if (item.Type == "modify")
        {
            UnModify(item);
        }
        else
        {
            _food -= item.Food;
            _water -= item.Water;
            _readiness -= item.Readiness;
        }

        _weight -= item.Weight;
    }

	private void Modify(IInventoryItem item)
	{
        if (item.Food > 1) _modFood = true;
        if (item.Water > 1) _modWater = true;
	}

    private void UnModify(IInventoryItem item)
    {
        if (item.Food > 1) _modFood = false;
        if (item.Water > 1) _modWater = false;
    }

    public bool CheckWin()
    {
        SavedMoney = StartingFunds - Funds;
        int newFood = Food;
        if (ModFood) newFood *= 2;
        int foodDif = ReqFood - newFood;
        if(foodDif > 0 && foodDif < 11)
        {
            RiskChance += foodDif;
        }
        else if(foodDif < 0 || foodDif == 0)
        {
            RiskChance -= Math.Abs(foodDif) / 2;
        }
        else
        {
            MissionStatement = "The crew did not have enough FOOD to survive during their travels, so all of them starved to death.";
            return false;
        }

        int newWater = Water;
        if (ModWater) newWater *= 2;
        int waterDif = ReqWater - newWater;
        Debug.Log(ReqWater);
        if (waterDif > 0 && waterDif < 11)
        {
            RiskChance += waterDif;
        }
        else if (waterDif < 0 || waterDif == 0)
        {
            RiskChance -= Math.Abs(waterDif) / 2;
        }
        else
        {
            MissionStatement = "The crew did not have enough WATER to survive during their travels, so all of them died of dehydration.";
            return false;
        }

        int weightDif = MaxWeight - Weight;
        if(weightDif < 0)
        {
            MissionStatement = "As the Rocket was about to break the cloud layer, the extra WEIGHT caused it to take nose a dive right towards Disney, killing everyone on board and 1 or 2 happy families.";
            return false;
        }

        float disasterChance = UnityEngine.Random.Range(0f, 100f);

        if(RiskChance > disasterChance)
        {
            float saviorChance = UnityEngine.Random.Range(0f, 100f);
            if(Readiness > saviorChance)
            {
                MissionStatement = "Oh no! There was a gas leak in the Rocket but luckily the crew was READY and solved the issue.";
                return true;
            }
            else
            {
                MissionStatement = "Oh no! There was a gas leak in the Rocket and the crew was not READY enough so they all suffocated and will forever float in space.";
                return false;
            }
        }
        else
        {
            MissionStatement = "Congratulations! The voyage was successful and no problems occured. You have made Florida proud.";
            return true;
        }
    }

	public string Name
	{
		get { return _name; }
		set { _name = value; }
	}

	public int Food
	{
		get { return _food; }
		set { _food = value; }
	}

	public int Water
	{
		get { return _water; }
		set { _water = value; }
	}

	public int Readiness
	{
		get { return _readiness; }
		set { _readiness = value; }
	}

	public int Weight
	{
		get { return _weight; }
		set { _weight = value; }
	}

	public int Funds
	{
		get { return _funds; }
		set { _funds = value; }
	}

	public int StartingFunds
	{
		get { return _startingFunds; }
		set { _startingFunds = value; }
	}

	public int AstronautCount
	{
		get { return _astronautCount; }
		set { _astronautCount = value; }
	}

	public int Duration
	{
		get { return _duration; }
		set { _duration = value; }
	}

    public bool ModFood
    {
        get { return _modFood; }
        set { _modFood = value; }
    }

    public bool ModWater
    {
        get { return _modWater; }
        set { _modWater = value; }
    }

    public int ReqFood
    {
        get { return _reqFood; }
        set { _reqFood = value; }
    }

    public int ReqWater
    {
        get { return _reqWater; }
        set { _reqWater = value; }
    }

    public int MaxWeight
    {
        get { return _maxWeight; }
        set { _maxWeight = value; }
    }

    public float RiskChance
    {
        get { return _riskChance; }
        set { _riskChance = value; }
    }

    public string MissionStatement
    {
        get { return _missionStatement; }
        set { _missionStatement = value; }
    }

    public int SavedMoney
    {
        get { return _savedMoney; }
        set { _savedMoney = value; }
    }
}
