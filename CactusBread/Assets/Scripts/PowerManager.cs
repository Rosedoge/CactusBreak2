using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerManager : MonoBehaviour {

    [SerializeField]
    GameObject healthPrefab, killPrefab;

    float healthTimer, killTimer;
    float healthCD = 10f, killCD = 25f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.time - killTimer >= killCD)
        {
            SpawnKillToken();
        }
        if (Time.time - healthTimer >= healthCD)
        {
            SpawnHealthToken();
        }
    }

    void SpawnHealthToken()
    {
        healthTimer = Time.time;
        float x = Random.Range(-1, 2) * 7;
        float y = Random.Range(-1, 2) * 4;
        GameObject temp = Instantiate(healthPrefab, new Vector2(x, y), transform.rotation);

    }
    void SpawnKillToken()
    {
        killTimer = Time.time;
        float x = Random.Range(-1, 2) * 7;
        float y = Random.Range(-1, 2) * 4;
        GameObject temp = Instantiate(killPrefab, new Vector2(x, y), transform.rotation);
    }
}
