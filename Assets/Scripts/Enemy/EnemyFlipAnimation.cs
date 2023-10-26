using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;


public class EnemyFlipAnimation : MonoBehaviour
{
    public GameObject target;
    
    void Update() {
        Vector2 direction = target.transform.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(0, direction.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(Vector3.up * angle);
    }
}