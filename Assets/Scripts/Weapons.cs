using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour {


    public GameObject rightHand, leftHand;
    Vector3 lastPositionRight, lastPositionLeft;

    public GameObject rightWeapon, leftWeapon, rightWeaponAlt, magicLaunchPoint;
    public GameObject fireMagic;

    public float weaponCooldown, magicCooldown = 0.0f;
    public const float WEAPON_COOLDOWN_TIME = 0.5f;
    public const float MAGIC_COOLDOWN_TIME = 2.0f;

    public bool shieldActive = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
