using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AR_Gun : Gun_Info_Script
{
    [SerializeField] Camera cam;
    private int bulletCount = 0;

    public override void Use()
    {
        Shoot();
    }

    private void Shoot()
    {
        Ray ray = cam.ViewportPointToRay(new Vector2(0.5f,0.5f));
        ray.origin = cam.transform.position;
        if (magazineSize != 0)
        {
            GunEff.Play();

           
        }
        
    }
    private void BulletSpawn(GameObject bull, Transform pos)
    {
        GameObject bullet = Instantiate(bull, pos.position, pos.rotation);
        bullet.GetComponent<Rigidbody>().AddForce(bullet.transform.forward * speed);


    }
    public void Reload()
    {
        int currenMagCount = magazineSize;
        int neededBull = bulletCount - currenMagCount;
        magazineSize = currenMagCount + neededBull;
        Debug.Log(magazineSize);
    }
}
