using Photon.Pun;
using UnityEngine;
using System.IO;


public class Pistol : Gun_Info_Script
{
    [SerializeField] Camera cam;
    PhotonView PV;
    private int bulletCount=0;
    private void Start()
    {
        bulletCount = magazineSize;
    }
    public override void Use()
    {
        Shoot();
    }

    private void Shoot()
    {

        Ray ray = cam.ViewportPointToRay(new Vector2(0.5f, 0.5f));
        ray.origin = cam.transform.position;
        if(Physics.Raycast(ray, out RaycastHit hit))
        {
            hit.collider.gameObject.GetComponent<IDamageable>()?.TakeDamage(damage);
          //  PV.RPC("RPC_Shoot", RpcTarget.All, hit.point);
            GunEff.Play();

        }
       /* if (magazineSize !=0)
        {
           
        }*/
       
    }
    [PunRPC]
    void RPC_Shoot(Vector3 hitPosition)
    {
        Debug.Log(hitPosition);
    }

    private void BulletSpawn(GameObject bull,Transform pos)
    {
        GameObject bullet = Instantiate(bull,pos.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody>().AddForce(bullet.transform.forward * speed * 50f,ForceMode.Force);

    }
    public void Reload()
    {
        
    }

   
}
