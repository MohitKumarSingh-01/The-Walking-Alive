using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimations : MonoBehaviour
{
    public static EnemyAnimations Instance;
    private Animator anim;

    void Awake()
    {
        Instance = this;
        anim = GetComponent<Animator>();
    }

    public void Walk(bool walk) {
        anim.SetBool("Walk", walk);
    }

    public void Attack(bool attack) {
        anim.SetBool("Attack", attack);
    }
}
