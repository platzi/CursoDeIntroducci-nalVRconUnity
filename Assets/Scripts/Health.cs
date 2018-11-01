using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    public DamageType type = DamageType.enemy;

	// Use this for initialization
	void Start () {
		
	}
	
    public float HealthPoints{

        get{
            return healthPoints;
        }

        set{
            healthPoints = value;

            if(healthPoints <= 0){
                //TODO: gestionar la muerte del personaje / enemigo
            }
        }
    }

    [SerializeField]
    private float healthPoints = 100.0f;




}
