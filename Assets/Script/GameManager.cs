using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public static GameManager instance;
	private AudioSource audiosource;

	public GameObject EnemyPrefab;
	public int enemyCount = 20;
	public string defaultName = "王二蛋";

	public float minEnemyMoveSpeed = 0.1f;
	public float maxEnemyMoveSpeed = 5.0f;

	public float speed_K=1.0f;

	public float leftEnemyPos = -8.0f;
	public float rightEnemyPos = 8.0f;

	public float minScaleX=0.5f;
	public float maxScaleX=5.0f;
	public float minScaleY=3.0f;
	public float maxScaleY=15.0f;

	public float randomCreateEnemyTime=3.0f;

	public bool isNewScore;

	private Dictionary<string,AudioClip> audioDir = new Dictionary<string, AudioClip> ();
	public Dictionary<string,GameObject> prefabs = new Dictionary<string, GameObject> ();

	#region playerData
	private const string PlayerName="PLAYNAME";
	private const string BestScore="BESTSCORE";
	private const string Coins="COINS";
	#endregion

	public Color[] enemyColor;
	public Color GetRandomEnemyColor{
		get{
			return enemyColor [Random.Range (0, enemyColor.Length)];
		}
	}

	public Vector3 GetRandomEnemyPos{
		get{
			return new Vector3 (Random.Range (leftEnemyPos, rightEnemyPos), 7.0f, 0);
		}
	}

	public Vector3 GetRandomScale{
		get{
			return new Vector3 (Random.Range (minScaleX, maxScaleX), Random.Range (minScaleY, maxScaleY), 1.0f);
		}
	}

	public int Coin {
		get { 
			return GetCoins ();
		}
	}

	void Awake()
	{
		instance = this;
	}

	void Start () {
		DontDestroyOnLoad (gameObject);
		audiosource = GetComponent<AudioSource> ();

		LoadPrefabs ();
		LoadAudioClips ();
	}
		
	void LoadAudioClips()
	{
		AudioClip[] audios = Resources.LoadAll<AudioClip> ("Audios");
		foreach (var temp in audios) {
			audioDir.Add (temp.name, temp);
		}
	}
	public void PlayeSound(string soundName,float volume=1.0f)
	{
		if (audioDir.ContainsKey (soundName)) {
			audiosource.clip = audioDir [soundName];
		}
		audiosource.volume = volume;
	}
	public void StopPlaySound()
	{
		if (audiosource.isPlaying) {
			audiosource.Stop ();
		}
	}
	void LoadPrefabs()
	{
		GameObject[] objs = Resources.LoadAll<GameObject> ("Prefabs");
		foreach (var temp in objs) {
			prefabs.Add (temp.name, temp);
		}
	}
	public void LoadScene(string sceneName){
		SceneManager.LoadScene (sceneName);
	}
	public void SetPlayerName(string name)
	{
		PlayerPrefs.SetString (PlayerName, name);
	}
	public string GetPlayerName()
	{
		return PlayerPrefs.GetString (PlayerName, defaultName);
	}
	public void UpdateBestScore(int score)
	{
		PlayerPrefs.SetInt (BestScore, score);
    }
	public int GetBestScore()
	{
		return PlayerPrefs.GetInt (BestScore, 0);
	}
	public void GainCoins(int count)
	{
		int coinsCount = GetCoins ();
		coinsCount += count;
		PlayerPrefs.SetInt (Coins, coinsCount);
	}
	private int GetCoins()
	{
		return PlayerPrefs.GetInt (Coins, 0);
	}
}
