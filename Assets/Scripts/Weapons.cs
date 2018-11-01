using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour {


    public GameObject rightHand, leftHand;
    Vector3 lastPositionRight, lastPositionLeft;

    public GameObject rightWeapon, leftWeapon, rightWeaponAlt, magicLaunchPoint;
    public GameObject fireMagic;
    GameObject currentMagic;

    public float weaponCooldown, magicCooldown = 0.0f;
    public const float WEAPON_COOLDOWN_TIME = 0.5f;
    public const float MAGIC_COOLDOWN_TIME = 2.0f;

    public bool shieldActive = false;

    public AudioClip fireClip;

	// Use this for initialization
	void Start () {
        rightWeaponAlt.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        weaponCooldown += Time.deltaTime;
        magicCooldown += Time.deltaTime;

        if(Input.GetAxis("HTC_VIU_LeftTrigger")>0.1 &&
           leftWeapon.activeInHierarchy){
            shieldActive = true;
        }else{
            shieldActive = false;
        }

        if(Input.GetAxis("HTC_VIU_RightTrigger")>0.1 &&
           magicCooldown>MAGIC_COOLDOWN_TIME){
        
            if(currentMagic != null){
                magicCooldown = 0;

                Vector3 force = 20.0f*(rightHand.transform.position -
                                       lastPositionRight) / Time.deltaTime;
                currentMagic.transform.parent = null;
                currentMagic.GetComponent<Rigidbody>().constraints = 
                    RigidbodyConstraints.None;
                currentMagic.GetComponent<Rigidbody>().
                            AddForce(force, ForceMode.Impulse);

                currentMagic.GetComponent<AudioSource>().PlayOneShot(fireClip);

                Invoke("LoadMagic", MAGIC_COOLDOWN_TIME);
            }
        
        }

        if(Input.GetAxis("HTC_VIU_LeftGrip")>0.1 && 
           weaponCooldown > WEAPON_COOLDOWN_TIME){
            weaponCooldown = 0;
            leftWeapon.SetActive(!leftWeapon.activeInHierarchy);
        }

        if(Input.GetAxis("HTC_VIU_RightGrip")>0.1 &&
           weaponCooldown > WEAPON_COOLDOWN_TIME){
            weaponCooldown = 0;
            rightWeapon.SetActive(!rightWeapon.activeInHierarchy);
            rightWeaponAlt.SetActive(!rightWeaponAlt.activeInHierarchy);

            if(rightWeaponAlt.activeInHierarchy){
                LoadMagic();
            } else {
                Destroy(currentMagic);
            }
        }


        lastPositionRight = rightHand.transform.position;
        lastPositionLeft = leftHand.transform.position;
	}

    void LoadMagic(){
        if(currentMagic!= null){
            Destroy(currentMagic);
        }

        currentMagic = Instantiate(fireMagic, magicLaunchPoint.transform);
    }

}
