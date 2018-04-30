using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmaScript : MonoBehaviour
{
	public GameObject projectilPrefab;
	public GameObject sensorRotacao;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetAxisRaw("Horizontal") > 0.0f)
		{
			sensorRotacao.transform.eulerAngles = new Vector3(0.0f,0.0f,0.0f);
		} else if (Input.GetAxisRaw("Horizontal") < 0.0f)
		{
			sensorRotacao.transform.eulerAngles = new Vector3(0.0f,180.0f,0.0f);
		}

		if (Input.GetButtonDown("Fire1"))
		{
			Instantiate(projectilPrefab, transform.position, transform.rotation);
		}
	}
}
