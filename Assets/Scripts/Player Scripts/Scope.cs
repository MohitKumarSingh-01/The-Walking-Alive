using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scope : MonoBehaviour
{
    public Animator animator;
    public GameObject scopeOverlay;
    public Camera mainCamera;
    public float scopeFOV = 15f;
    private float prevFOV = 65f;
    [SerializeField]
    private LayerMask AimLayer;
    [SerializeField]
    private LayerMask NormalLayer;

    private bool isScoped = false;

   
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1) && WeaponManager.instance.SelectedWeapon().tag == "AsaultRifile")
        {
            isScoped = !isScoped;
            animator.SetBool("Scoped", isScoped);

            if (isScoped)
                StartCoroutine(OnScoped());
            else
                OnUnscoped();
        }
    }

    void OnUnscoped()
    {
        Camera.main.cullingMask = NormalLayer;
        scopeOverlay.SetActive(false);

        PlayerShoot.instance.range = 40;
        PlayerShoot.instance.damage = 5;

        mainCamera.fieldOfView = prevFOV;
    }

    IEnumerator OnScoped()
    {
        yield return new WaitForSeconds(0.25f);

        Camera.main.cullingMask = AimLayer;
        scopeOverlay.SetActive(true);

        PlayerShoot.instance.isReload = false;
        PlayerShoot.instance.range = 80;
        PlayerShoot.instance.damage = 10;

        mainCamera.fieldOfView = scopeFOV;
    }
}
