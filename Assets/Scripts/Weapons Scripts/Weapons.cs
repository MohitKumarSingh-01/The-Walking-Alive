using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{
    private Animator anim;

    private void Awake() 
    {
        anim = GetComponent<Animator>();
    }

    public void ShootAnimation() 
    {
        anim.SetTrigger("Shoot");
    }
    public void ReloadAnimation()
    {
        anim.SetTrigger("Reload");
    }
    public void Anim()
    {
        PlayerShoot.instance.isReload = false;
    }
}
