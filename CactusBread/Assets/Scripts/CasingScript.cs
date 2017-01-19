using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CasingScript : MonoBehaviour {


    Vector3 torque;
    // Use this for initialization
    void Start () {
        torque.x = Random.Range(-100, 100);
        torque.y = Random.Range(-100, 100);
        torque.z = Random.Range(-0, 0);
        gameObject.GetComponent<Rigidbody2D>().AddForce(torque, ForceMode2D.Force);
        Destroy(gameObject, 2f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
