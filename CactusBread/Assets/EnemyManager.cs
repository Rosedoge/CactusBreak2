using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {


    [SerializeField]
    float basicEnemySpawnTime = 1f, toasterEnemySpawnTime = 5;
    float basicEnemySpawn, toasterEnemySpawn;
    [SerializeField]
    GameObject basicEnemyPrefab, toasterEnemyPrefab;
    public static EnemyManager instance = null;              //Static instance of GameManager which allows it to be accessed by any other script.


    //Awake is always called before any Start functions
    void Awake()
    {
        //Check if instance already exists
        if (instance == null)

            //if not, set instance to this
            instance = this;

        //If instance already exists and it's not this:
        else if (instance != this)

            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);

        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);

    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	    if(Time.time - basicEnemySpawn >= basicEnemySpawnTime)
        {
            SpawnBasicEnemy();
        }
        if (Time.time - toasterEnemySpawn >= toasterEnemySpawnTime)
        {
            SpawnToasterEnemy();
        }
    }

    void SpawnToasterEnemy()
    {
        toasterEnemySpawn = Time.time;
        float x = Random.Range(-1, 1) * 8;
        float y = Random.Range(-1, 1) * 5;
        GameObject temp = Instantiate(toasterEnemyPrefab, new Vector2(x, y), transform.rotation);
        int tempint = Random.Range(1, 5);
        Debug.Log("Random Int " + tempint);
        switch (tempint)
        {
            case 1:
                temp.GetComponent<ToasterEnemy>().localPos = ToasterEnemy.Position.down;
                break;
            case 2:
                temp.GetComponent<ToasterEnemy>().localPos = ToasterEnemy.Position.up;
                break;
            case 3:
                temp.GetComponent<ToasterEnemy>().localPos = ToasterEnemy.Position.left;
                break;
            case 4:
                temp.GetComponent<ToasterEnemy>().localPos = ToasterEnemy.Position.right;
                break;
        }
    }
    void SpawnBasicEnemy()
    {
        basicEnemySpawn = Time.time;
        //-8 to 8, 5 to -5
        float x = Random.Range(-1, 2) * 7;
        float y = Random.Range(-1, 2) * 4;
        GameObject temp = Instantiate(basicEnemyPrefab, new Vector2(x, y), transform.rotation);
    }
}
