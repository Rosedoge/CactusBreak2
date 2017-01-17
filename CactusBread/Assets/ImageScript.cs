using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageScript : MonoBehaviour {

    [SerializeField]
    Sprite[] guns;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(PlayerScript.instance.equippedGun == PlayerScript.gunType.revolver)
        {
            gameObject.GetComponent<Image>().sprite = guns[0];
        }
        else
        {
            gameObject.GetComponent<Image>().sprite = guns[1];
        }
	}
}
