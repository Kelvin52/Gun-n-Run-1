using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFireMissile1 : MonoBehaviour {

    public GameObject enemyMissilePf;
    public float missileSpeed;
    private int timeCount = 0;

    void Update()
    {

        timeCount += 1;
        

        if (timeCount % 60 == 0)
        {

            // generate enemy's missile
            GameObject enemyMissile = Instantiate(enemyMissilePf, transform.position, Quaternion.identity) as GameObject;

            Rigidbody enemyMissileRb = enemyMissile.GetComponent<Rigidbody>();

            // decide the direction of missile."right" is point at the x axis.
            enemyMissileRb.AddForce(transform.right * missileSpeed);

            // eliminate the missile after 8 sec
            Destroy(enemyMissile, 8.0f);

        }
    }
}
