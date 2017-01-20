using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToasterEnemy : MonoBehaviour {
    public enum Position { up, down, left, right,none };
    public Position localPos = Position.up;

    int health = 2;
    bool firing = false;
    bool InLocation = false;
    public GameObject bulletPrefab;
    float strayFactor = 40f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        //Debug.Log("local pos " + localPos);
        if (!InLocation)
        {
            if (localPos == Position.up)
            {
                if (Vector2.Distance(transform.position, new Vector2(-1, 4)) <= 1)
                {
                    InLocation = true; //yay
                }
                else
                {
                    transform.position = Vector3.MoveTowards(transform.position, new Vector2(-1, 4), 0.02f);
                }
            }
            if (localPos == Position.down)
            {
                //Debug.Log(Vector2.Distance(transform.position, new Vector2(0, -4)));
                if (Vector2.Distance(transform.position, new Vector2(0, -4f)) <= 1)
                {
                    InLocation = true; //yay
                }
                else
                {
                    //Debug.Log("Move To: " + Vector3.MoveTowards(transform.position, new Vector2(0, -4f), 0.05f));
                    transform.position = Vector3.MoveTowards(transform.position, new Vector2(0, -4f), 0.02f);
                }
            }
            if (localPos == Position.right)
            {
                if (Vector2.Distance(transform.position, new Vector2(6, 0)) <= 1)
                {
                    InLocation = true; //yay
                }
                else
                {
                    transform.position = Vector3.MoveTowards(transform.position, new Vector2(6, 0), 0.02f);
                }
            }
            if (localPos == Position.left)
            {
                if (Vector2.Distance(transform.position, new Vector2(-6, 0)) <= 1)
                {
                    InLocation = true; //yay
                }
                else
                {
                    transform.position = Vector3.MoveTowards(transform.position, new Vector2(-6, 0), 0.02f);
                }
            }

        }
        else    
        { //Ready to T O A S T
            if (!firing)
            {
                Debug.Log("Firing");
                InvokeRepeating("Fire", 1.5f, 0.75f);
                firing = true;
            }
        }
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Bullet")
        {
            health--;
            if(health<= 0)
                Destroy(gameObject);
        }
    }
    void Fire()
    {
        if (localPos == Position.up)
        {
            float randomNumberX = Random.Range(-strayFactor, strayFactor);
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
           // bullet.transform.Rotate(0, 0, randomNumberX);
            bullet.GetComponent<Rigidbody2D>().AddForce(-bullet.transform.up * 100);
        }
        if (localPos == Position.down)
        {
            float randomNumberX = Random.Range(-strayFactor, strayFactor);
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            bullet.transform.Rotate(0, 0, randomNumberX);
            bullet.GetComponent<Rigidbody2D>().AddForce(bullet.transform.up * 100);
        }
        if (localPos == Position.right)
        {
            float randomNumberX = Random.Range(-strayFactor, strayFactor);
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            bullet.transform.Rotate(0, 0, randomNumberX);
            bullet.GetComponent<Rigidbody2D>().AddForce(-bullet.transform.right * 100);
        }
        if (localPos == Position.left)
        {
            float randomNumberX = Random.Range(-strayFactor, strayFactor);
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            bullet.transform.Rotate(0, 0, randomNumberX);
            bullet.GetComponent<Rigidbody2D>().AddForce(bullet.transform.right * 100);
        }
        //   float randomNumberY = Random.Range(-strayFactor, strayFactor);
        //   float randomNumberZ = Random.Range(-strayFactor, strayFactor);
        //   GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);

    }
}
