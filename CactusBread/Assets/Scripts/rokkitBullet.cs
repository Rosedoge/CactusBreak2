using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rokkitBullet : MonoBehaviour {
    [SerializeField]    
    GameObject explosionPrefab;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Enemy")
        {
            Debug.Log("Explode!");
            Destroy(gameObject, 1f);
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            GetComponent<CircleCollider2D>().enabled = true;
            EZCameraShake.CameraShaker.Instance.ShakeOnce(1f, 5f, 0.1f, 0.8f);
            GameObject temp = Instantiate(explosionPrefab, this.transform.position,transform.rotation);
            Destroy(temp, 1f);
        }
    }
}
