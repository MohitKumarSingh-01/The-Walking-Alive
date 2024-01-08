using System;
using TMPro;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public static PlayerShoot instance;

    public ParticleSystem muzzelFlash;

    public Camera mainCam;

    public AudioClip knife;
    public AudioClip reload;

    public AudioSource weaponAudio;
    public AudioSource weaponFire;

    private float fireRate = 10;
    private float nextTimeToFire;
    public int damage = 4;
    public int range = 40;

    public TMP_Text ammoText;
    public TMP_Text maxAmmoText;

    public int ammo;
    public int maxAmmo;
    public int magSize;
    public bool isFire = false;
    public bool isReload = false;


    private void Awake()
    {
        instance = this;
        ammo = magSize;
    }
    private void Update()
    {
        WeaponShoot();
        ammoText.text = ammo.ToString();
        maxAmmoText.text = maxAmmo.ToString();
        WeaponReload();
    }

    private void WeaponShoot()
    {
        if (WeaponManager.instance.SelectedWeapon().tag == "AsaultRifile" && MouseLook.instance.openPanel == false && !isReload)
        {
            if (Input.GetMouseButton(0) && Time.time > nextTimeToFire && ammo > 0)
            {
                isFire = true;
                nextTimeToFire = Time.time + 1f / fireRate;

                ammo--;
                BulletFired();
                muzzelFlash.Play();
                weaponFire.Play();
                WeaponManager.instance.SelectedWeapon().ShootAnimation();
            }
        }
        else if (Input.GetMouseButtonDown(0) && WeaponManager.instance.SelectedWeapon().tag == "Knife" && MouseLook.instance.openPanel == false)
        {
            isReload = false;
            WeaponManager.instance.SelectedWeapon().ShootAnimation();
            BulletFired();
            weaponAudio.PlayOneShot(knife);
        }
    }

    private void BulletFired()
    {
        RaycastHit hit;

        if (Physics.Raycast(mainCam.transform.position, mainCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.collider.transform.name);

            if (hit.transform.CompareTag("Enemy"))
            {
                //Instantiate(blood, hit.point, Quaternion.identity);
                Enemy enemy = hit.collider.GetComponent<Enemy>();
                enemy.EnemyDead(damage);
            }
        }
       
    }
    private void WeaponReload()
    {
        if (Input.GetKeyDown(KeyCode.R) && ammo < magSize && maxAmmo > 0 )
        {
            weaponAudio.PlayOneShot(reload);
            isReload = true;
            GunReload();
            WeaponManager.instance.SelectedWeapon().ReloadAnimation();
        }
    }
    private void GunReload()
    {
        int bulletsNeeded = magSize - ammo;
        int bulletsToReload = Math.Min(bulletsNeeded, maxAmmo);

        ammo += bulletsToReload;
        maxAmmo -= bulletsToReload;

    }
    public void UpdateAmmo(int ammoAmount)
    {
        maxAmmo += ammoAmount;
    }
}