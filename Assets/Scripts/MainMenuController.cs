
using UnityEngine;
using UnityEngine.SceneManagement;
using Button = UnityEngine.UI.Button;

public class MainMenuController : MonoBehaviour
{

	[SerializeField] private Button _startButton;
    public AudioSource buttonSound;

	// Use this for initialization
	void Start ()
	{
        buttonSound = this.gameObject.GetComponents<AudioSource>()[1];
		_startButton.onClick.AddListener(() => { buttonSound.Play(); SceneManager.LoadScene("main"); });
	}
}
