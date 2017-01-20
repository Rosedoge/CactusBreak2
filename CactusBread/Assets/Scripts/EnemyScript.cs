using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

    [SerializeField]
    GameObject bloodSplatter;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector3.MoveTowards(transform.position, PlayerScript.instance.transform.position, 0.02f);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Bullet")
        {
            GameObject temp = Instantiate(bloodSplatter, transform.position, transform.rotation);
            Destroy(temp, 5f);
            float randomNumberX = Random.Range(0, 360);
          
            temp.transform.Rotate(0, 0, randomNumberX);
            Destroy(gameObject);
        }
    }
}
