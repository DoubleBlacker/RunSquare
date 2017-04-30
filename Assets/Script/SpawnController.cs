using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{

	private int hasEnemyCount;
	private Stack spawnPool = new Stack ();

	private bool hasCreate;
	private float countTimer;

	private static SpawnController _instance;

	public static SpawnController GetInstance ()
	{
		if (_instance == null) {
			_instance = FindObjectOfType<SpawnController> ();
		}
		return _instance;
	}

	void Update ()
	{
		countTimer += Time.deltaTime;
		if (!hasCreate && countTimer > GameManager.instance.randomCreateEnemyTime && !GameController.GetInstance ().hasGameOver) {
			hasCreate = true;
			CreateEnemy (GameManager.instance.GetRandomEnemyPos, GameManager.instance.GetRandomScale);
		}
	}


	void CreateEnemy (Vector3 pos, Vector3 scale)
	{
		if (hasEnemyCount > GameManager.instance.enemyCount) {
			return;
		}
		CreateObject (pos, scale);
		hasEnemyCount++;
	}

	GameObject CreateObject (Vector3 pos, Vector3 scale)
	{
		GameObject enemy = null;
		if (spawnPool.Count > 0) {
			enemy = spawnPool.Pop ()as GameObject;
			enemy.SetActive (true);
		} else {
			enemy = Instantiate (GameManager.instance.EnemyPrefab);
			enemy.transform.SetParent (transform);
			enemy.name = GameManager.instance.EnemyPrefab.name;
		}
		enemy.transform.position = pos;
		enemy.transform.localScale = scale;
		enemy.AddComponent<EnemyConfig> ();
		hasCreate = false;
		countTimer = 0;
		GameController.GetInstance ().enemyCount++;
		return enemy;
	}

	public void RecycleEnemy (GameObject recycleEnemy)
	{
		recycleEnemy.SetActive (false);
		spawnPool.Push (recycleEnemy);
		hasEnemyCount--;
	}
}
