using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyConfig : MonoBehaviour
{


	void Start ()
	{
		GetComponent<SpriteRenderer> ().color = GameManager.instance.GetRandomEnemyColor;
	}
	
	// Update is called once per frame
	void Update ()
	{
		transform.Translate (Vector3.down * Random.Range (GameManager.instance.minEnemyMoveSpeed,
			GameManager.instance.maxEnemyMoveSpeed) * Time.deltaTime * GameManager.instance.speed_K);

		if (transform.position.y < -9.0f) {
			GameManager.instance.GainCoins (1);
			SpawnController.GetInstance ().RecycleEnemy (gameObject);
		}
	}
}
