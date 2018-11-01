using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DamageType{
    player,
    enemy
}


public class Damage : MonoBehaviour {

    public DamageType type = DamageType.enemy;
    public float damage = 10.0f;

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Health>()!= null){
            if(other.GetComponent<Health>().type != type){
                //El tipo de daño que hacemos es diferente
                //de a quien se lo hemos hecho
                float currentDamage = damage;

                if(other.GetComponent<Weapons>()!=null){
                    //El otro collider lleva armas y escudos
                    if(other.GetComponent<Weapons>().shieldActive){
                        //El otro collider tiene el escudo activado
                        currentDamage /= 5;
                    }
                }

                other.GetComponent<Health>().HealthPoints -= currentDamage;
            }
        }
    }
}
