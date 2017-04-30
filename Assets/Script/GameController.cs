using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	private static GameController _instance;
	public float gameTime{ set; get;}
	public int enemyCount{ set; get;}
	public bool hasGameOver;
	public static GameController GetInstance()
	{
		if (_instance == null) {
			_instance = FindObjectOfType<GameController> ();
		}
		return _instance;
	}

	void Start () {

	}
	

	void Update () {
		if (!hasGameOver) {
			gameTime += Time.deltaTime;
		}
		if (!hasGameOver && enemyCount == GameManager.instance.enemyCount) {
			enemyCount = 0;
			GameManager.instance.enemyCount += Random.Range (5, 11);
			if (GameManager.instance.randomCreateEnemyTime > 1.0f) {
				GameManager.instance.randomCreateEnemyTime -= 0.5f;
			} else {
				GameManager.instance.randomCreateEnemyTime = 1.0f;
			}

		}
	}
		

	public void GameOver()
	{
		hasGameOver = true;
		if (Mathf.RoundToInt (gameTime) > GameManager.instance.GetBestScore ()) {
			GameManager.instance.UpdateBestScore (Mathf.RoundToInt (gameTime));
			GameManager.instance.isNewScore = true;
		}
		Panel.Open ("GameOverPanel");
	}
	public void Restart()
	{
		GameManager.instance.LoadScene ("game");
	}
	public void Back()
	{
		GameManager.instance.LoadScene ("home");
	}
}
