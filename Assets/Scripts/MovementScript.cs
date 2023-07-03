using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    [SerializeField]
    private float moveSpeed = 5f;


    

    void Update()
    {
        moveTowardsPlayer();
        lookTowardsPlayer();
    }

    void moveTowardsPlayer()
    {
        Vector3 direction = player.transform.position - transform.position;
        direction.Normalize();

        transform.position += direction * moveSpeed * Time.deltaTime;
    }
    void lookTowardsPlayer()
    {
        transform.LookAt(player.transform);
    }
    
}
