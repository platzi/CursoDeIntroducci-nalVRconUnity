using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowDestination : MonoBehaviour {

    GameObject[] destinations;
    Transform destination;
    public float speed = 5.0f;
    GameObject player;

	// Use this for initialization
	void Start () {
        destinations = GameObject.FindGameObjectsWithTag("Waypoint");
        player = GameObject.FindWithTag("Player");

        destination = destinations[Random.Range(0, destinations.Length)].transform;
	}
	
	// Update is called once per frame
	void Update () {

        //TRANSLACIÓN
        float space = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position,
                                                 destination.position, space);
        //ROTACIÓN

        Vector3 targetDirection = destination.position - transform.position;
        Vector3 newDirection = Vector3.RotateTowards(transform.forward,
                                                     targetDirection,
                                                     space, 0);

        Debug.DrawRay(transform.position, newDirection, Color.red);
        transform.rotation = Quaternion.LookRotation(newDirection);


	}
}
