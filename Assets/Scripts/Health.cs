using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    public DamageType type = DamageType.enemy;

    private Animator animator;

	// Use this for initialization
	void Start () {
        if(GetComponent<Animator>()!=null){
            animator = GetComponent<Animator>();
            animator.SetFloat("health", HealthPoints);
        }
	}
	
    public float HealthPoints{

        get{
            return healthPoints;
        }

        set{
            healthPoints = value;

            if(animator!=null){
                animator.SetFloat("health", healthPoints);
            }

            if(healthPoints <= 0){

                if(type == DamageType.enemy){
                    Destroy(gameObject, 2.0f);
                }

            }
        }
    }

    [SerializeField]
    private float healthPoints = 100.0f;




}
