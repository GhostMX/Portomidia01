using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turrent : MonoBehaviour {
    public Transform BulletPrefab;
    public float timeBetweenShoot;
    private float countdown;
    public Transform SpawnPoint;
 
    private void Update()
    {
        if (countdown <= 0)
        {
            StartCoroutine(SpawnBullet());
            countdown = timeBetweenShoot;
        }
        countdown -= Time.deltaTime;
    }
    IEnumerator SpawnBullet()
    {
   
        
            SpawnBulletVoid();
            yield return new WaitForSeconds(timeBetweenShoot);
        


    }
    void SpawnBulletVoid()
    {
        Instantiate(BulletPrefab, SpawnPoint.position, SpawnPoint.rotation);

    }
}