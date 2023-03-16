using UnityEngine;

public abstract class Gun_Info_Script : Items_Script
{
    public int damage;
    public float speed;
    public float distance;
    public float fireRate;
    public int magazineSize;
    public float reloadTome;
    public ParticleSystem GunEff;
    public Transform EffectPos;
    public Transform bulletSpawnPos;
    public GameObject Bullet_pre;

    public enum shootType
    {
        single,
        bust,
        auto,
    }
    public abstract override void Use();
    
}
