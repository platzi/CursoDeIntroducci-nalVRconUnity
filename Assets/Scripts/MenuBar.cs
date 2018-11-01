using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum BarType {
    health,
    mana
}
public class MenuBar : MonoBehaviour {

    Slider slider;
    public GameObject target;
    public BarType barType;

	// Use this for initialization
	void Start () {
        slider = GetComponent<Slider>();

        switch(barType){
            case BarType.health:
                slider.maxValue = target.GetComponent<Health>().HealthPoints;
                break;

            case BarType.mana:
                slider.maxValue = Weapons.MAGIC_COOLDOWN_TIME;
                break;
        }
	}
	
	// Update is called once per frame
	void Update () {
        switch(barType){
            case BarType.health:
                slider.value = target.GetComponent<Health>().HealthPoints;
                break;

            case BarType.mana:
                slider.value = target.GetComponent<Weapons>().magicCooldown;
                break;
        }
	}
}
