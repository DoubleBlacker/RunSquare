using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryEnemy : MonoBehaviour {

	void OnCollision2DExit(Collision2D other)
	{
		if (other.gameObject.layer == LayerMask.NameToLayer ("enemy")) {
			SpawnController.GetInstance ().RecycleEnemy (other.gameObject);
		}
	}
}
