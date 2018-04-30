using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigornaScript : MonoBehaviour
{
	public float velocidade;
	// Use this for initialization
	void Start () {
		Destroy(gameObject, 1.5f);
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector2.right * velocidade * Time.deltaTime);
	}

}
