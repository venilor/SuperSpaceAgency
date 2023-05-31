using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GeneralManager : MonoBehaviour
{
    public static GeneralManager instance;
	public Canvas RocketCanvas;
	public Canvas MissionCanvas;
	public Canvas ShopCanvas;
    
    public Text FoodName;
    public Text WaterName;

    public Text WeightVal;
    public Text ReadinessVal;
    public Text FoodVal;
    public Text WaterVal;

    // Music
    public AudioClip mainMenuTheme;
    public AudioClip shopMenuTheme;
    public AudioClip missionTheme;

    // Sound Effects
    public AudioClip buttonPress;
    public AudioClip launchButtonPress;
    public AudioClip purchaseSound;

    // Audio Players
    public AudioSource musicSource;
    public AudioSource soundSource;
 
    private Mission _mission;
	
	private void Awake() {
		if (instance == null)
        {
            instance = this;
            //DontDestroyOnLoad(gameObject);
        }
        _mission = new Mission("Orion II", 0, 0, 0, 0, 10000, 4, 36, 600, 5f);
        mainMenuTheme = Resources.Load("Sounds/Music/MainMenuV2") as AudioClip;
        shopMenuTheme = Resources.Load("Sounds/Music/ShopThemeNormal") as AudioClip;
        missionTheme = Resources.Load("Sounds/Music/MissionTheme") as AudioClip;

        buttonPress = Resources.Load("Sounds/Game Sounds/Button_Press_1") as AudioClip;
        launchButtonPress = Resources.Load("Sounds/Game Sounds/Button_Press_Beep") as AudioClip;
        purchaseSound = Resources.Load("Sounds/Game Sounds/Ka_Ching_Eff") as AudioClip;

        musicSource = gameObject.GetComponents<AudioSource>()[0];
        soundSource = gameObject.GetComponents<AudioSource>()[1];
	}

	public Mission GetMission ()
	{
		return _mission;
	}
	
	// Update is called once per frame
	private void Update() {
        WeightVal.text = instance.GetMission().Weight.ToString();
        ReadinessVal.text = instance.GetMission().Readiness.ToString();
        FoodVal.text = instance.GetMission().Food.ToString();
        WaterVal.text = instance.GetMission().Water.ToString();

        if (GetMission().ModFood) FoodName.text = "Food x 2";
        else FoodName.text = "Food";

        if (GetMission().ModWater) WaterName.text = "Water x 2";
        else WaterName.text = "Water";
    }

	public void SwitchToMissionView()
	{

        soundSource.clip = buttonPress;
        soundSource.Play();

        RocketCanvas.sortingOrder = 0;
		ShopCanvas.sortingOrder = 1;
        MissionCanvas.sortingOrder = 2;

        if (MissionCanvas.sortingOrder == 1)
        {
            musicSource.Stop();
            musicSource.volume = (float)0.6;
            musicSource.clip = mainMenuTheme;
            musicSource.Play();
        }
    }

	public void SwitchToShopView()
    {
        soundSource.clip = buttonPress;
        soundSource.Play();

        RocketCanvas.sortingOrder = 0;
        MissionCanvas.sortingOrder = 1;
        ShopCanvas.sortingOrder = 2;

        musicSource.Stop();
        musicSource.volume = 1;
        musicSource.clip = shopMenuTheme;
        musicSource.Play();
    }

	public void SwitchToRocketView()
	{
        soundSource.clip = buttonPress;
        soundSource.Play();

        if(MissionCanvas.sortingOrder == 1)
        {
            musicSource.Stop();
            musicSource.volume = (float)0.6;
            musicSource.clip = mainMenuTheme;
            musicSource.Play();
        }
		MissionCanvas.sortingOrder = 0;
        ShopCanvas.sortingOrder = 1;
        RocketCanvas.sortingOrder = 2;
    }

    public void LaunchMission()
    {
        musicSource.Stop();
        musicSource.clip = missionTheme;
        musicSource.Play();
        soundSource.clip = launchButtonPress;
        soundSource.Play();
    }
	
	public void ResetGame()
	{
		_mission = new Mission("Orion II", 0, 0, 0, 0, 10000, 4, 36, 600, 5f);
		SceneManager.LoadScene("startmenu");
	}
}
