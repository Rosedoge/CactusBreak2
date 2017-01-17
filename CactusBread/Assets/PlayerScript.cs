using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour {

    float HealthPerc = 100;
    int Health = 8;
    [SerializeField]
    AudioClip[] clips;
    [SerializeField]
    Image healthCylinder;
    [SerializeField]
    GameObject bulletPrefab, casingPrefab;
    bool forward;
    public enum gunType {revolver, rifle };
    public gunType equippedGun = gunType.revolver;
    float ammoRevolverMax = 60, ammoRevolverCur = 60, ammoInRevolver = 6;
    float ammoRifleMax = 120, ammoRifleCur = 120, ammoInRifle = 15;
    [SerializeField]
    Text RifleAmmoCounter, RevolverAmmoCounter;
    public static PlayerScript instance = null;              //Static instance of GameManager which allows it to be accessed by any other script.
                               

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
    public float horizontalSpeed = 2.0F;
    public float verticalSpeed = 2.0F;
    void Update()
    {
        GetPlayerInput();
        //this is no good at all
        //transform.right = Input.mousePosition;
        ShowAmmo();
        healthCylinder.fillAmount = (float)Health / 8;
        //Debug.Log(Health / 8);
    }

    void ShowAmmo()
    {
        string revolver = "x/x";
        revolver = ammoInRevolver + "/" + ammoRevolverCur;
        RevolverAmmoCounter.text = revolver;
        string rifle = "x/x";
        rifle = ammoInRifle + "/" + ammoRifleCur;
        RifleAmmoCounter.text = rifle;
    }
    void GetPlayerInput()
    {
        Vector2 temp = transform.position;
        if (Input.GetKey(KeyCode.W))
        {
            temp.y+= 0.05f;
        }
        if (Input.GetKey(KeyCode.S))
        {
            temp.y -= 0.05f;
        }
        if (Input.GetKey(KeyCode.A))
        {
            temp.x -= 0.05f;
        }
        if (Input.GetKey(KeyCode.D))
        {
            temp.x += 0.05f;
        }
        transform.position = temp;
        if(Input.GetKeyDown(KeyCode.Mouse0)){
            Fire();
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            SwapGun();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            ReloadGun();
        }

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name.Contains("HealthPack"))
        {
            Health = 8;
            Destroy(col.gameObject);
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Enemy")
        {
            Destroy(col.gameObject);
            Health -= 1;
        }
    }
    void ReloadGun()
    {
        if (equippedGun == gunType.revolver)
        {
            if(ammoRevolverCur - 6 >= 0)
            {
                ammoRevolverCur -= 6 - ammoInRevolver;
                ammoInRevolver = 6;
            }
            else
            {
                ammoInRevolver = ammoRevolverCur;
                ammoRevolverCur = 0; 
            }
            for(int x = 0; x <= 5; x++)
            {
                GameObject go = Instantiate(casingPrefab, transform.position, Quaternion.identity) as GameObject;
            }
            GetComponent<AudioSource>().PlayOneShot(clips[1]);
            return;
        }
        else
        {
            if (ammoRifleCur - 15 >= 0)
            {
                ammoRifleCur -= 15 - ammoInRifle;
                ammoInRifle = 15;
            }
            else
            {
                ammoInRifle = ammoRifleCur;
                ammoRifleCur = 0;
            }
            for (int x = 0; x <= 14; x++)
            {
                GameObject go = Instantiate(casingPrefab, transform.position, Quaternion.identity) as GameObject;
            }
            GetComponent<AudioSource>().PlayOneShot(clips[1]);
            return;
        }
    }
    void SwapGun()
    {
        if (equippedGun == gunType.revolver)
        {
            equippedGun = gunType.rifle;
            return;
        }
        else
        {
            equippedGun = gunType.revolver;
            return;
        }
     }
    void Fire()
    {

        if(equippedGun == gunType.revolver)
        {
            if(ammoInRevolver <= 0)
            {
                return;
            }
            ammoInRevolver -= 1;
            Debug.Log(ammoInRevolver);
        }
        else
        {
            if (ammoInRifle <= 0)
            {
                return;
            }
            ammoInRifle -= 1;
        }
        GetComponent<AudioSource>().PlayOneShot(clips[0]);
        Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
        position = Camera.main.ScreenToWorldPoint(position);
        GameObject go = Instantiate(bulletPrefab, transform.position, Quaternion.identity) as GameObject;
        go.transform.LookAt(position);
        if (equippedGun == gunType.revolver)
            go.GetComponent<Rigidbody2D>().AddForce((position - go.transform.position).normalized * 1000f);
        else
            go.GetComponent<Rigidbody2D>().AddForce((position - go.transform.position).normalized * 500);
    }
}
