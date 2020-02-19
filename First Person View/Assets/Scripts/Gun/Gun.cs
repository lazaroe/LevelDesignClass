using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [Header("Gun Values")]
    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 15f;
    public float impactForce = 30f;

    [Header("Ammo & Reload")]
    public int maxAmmo = 30;
    public int bulletsPerMag = 10;
    private int currentAmmo;
    public float reloadTime = 1f;
    private bool IsReloading = false;

    [Header("Effects")]
    public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    public GameObject ImpactEffect;

    private float nextTimeToFire = 0f;
    public bool OnAim = false;

    public Animator animator;
    public New_Weapon_Recoil_Script recoil;
    

    void Start()
    {
        currentAmmo = bulletsPerMag;
    }

    void OnEnable()
    {
        IsReloading = false;
        animator.SetBool("Reloading", false);
    }

    void Update()
    {
        Aim();
        if (IsReloading)
            return;
        if (currentAmmo <= 0)
        {
            StartCoroutine(Reload());
            return;
        }
        
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            recoil.Fire(); //Recoil
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }
    }

    IEnumerator Reload ()
    {
        IsReloading = true;
        Debug.Log("Reloading");
        animator.SetBool("Reloading", true);
        yield return new WaitForSeconds(reloadTime - 0.25f);
        animator.SetBool("Reloading", false);
        yield return new WaitForSeconds(0.25f);
        
        int bulletsToLoad = bulletsPerMag - currentAmmo;
        int bulletsToDecuct = (maxAmmo >= bulletsToLoad) ? bulletsToLoad : maxAmmo;
        maxAmmo -= bulletsToDecuct;
        currentAmmo += bulletsToDecuct;
        IsReloading = false;
    }

    void Aim()
    {
        if (Input.GetMouseButtonDown(2))
        {
            if (OnAim == false)
            {
                animator.SetBool("Aiming", true);
                print("Aimin");
                OnAim = true;
            }
        }
    }


    void Shoot()
    {
        muzzleFlash.Play();

        currentAmmo--;
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }

            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal *impactForce);
            }

            GameObject impactGO = Instantiate(ImpactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, 2f);
        }
    }

    void BulletHole()
    {
       
    }

}
