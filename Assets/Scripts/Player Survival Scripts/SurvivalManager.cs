using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SurvivalManager : MonoBehaviour
{
    #region Singleton
    public static SurvivalManager instance;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("More then one instance found!");
            return;
        }

        instance = this;
    }
    #endregion

    public GameObject gameOver;
    public GameObject damageEffect;
    private AudioSource gameplayAudio;
    public AudioSource enemyAttackSound;
    private bool isPlay;

    [Header("Health")]
    public float currentHealth;
    [SerializeField] private float maxHealth = 100;
    public float HealthPercent => currentHealth / maxHealth;


    [Header("Hunger")]
    public float currentHunger;
    [SerializeField] private float maxHunger = 100;
    [SerializeField] private float hungerDepletionRate = 1f;
    public float HungerPercent => currentHunger / maxHunger;


    [Header("Thirst")]
    public float currentThirst;
    [SerializeField] private float maxThirst = 100;
    [SerializeField] private float thirstDepletionRate = 1f;
    public float ThirstPercent => currentThirst / maxThirst;


    private void Start()
    {
        gameplayAudio = GetComponent<AudioSource>();
        gameplayAudio.Play();
        currentHealth = maxHealth;
        currentHunger = maxHunger;
        currentThirst = maxThirst;
        isPlay = true;
    }

    private void Update()
    {
        currentHunger -= hungerDepletionRate * Time.deltaTime;
        currentThirst -= thirstDepletionRate * Time.deltaTime;

        if(currentHunger <= 0)
        {
            TakeDamage(0.3f);
            currentHunger = 0;
        }
        if (currentThirst <= 0)
        {
            TakeDamage(0.2f);
            currentThirst = 0;
        }
        if (currentHealth <= 0)
        {
            Die();
            currentHealth = 0;
        }

        if(isPlay == true || MouseLook.instance.openPanel == true)
        {
            damageEffect.SetActive(false);
        }
    }
    public void UpdateHealth(float healthAmount)
    {
        currentHealth += healthAmount;
    }
    public void UpdateHunger(float hungerAmount)
    {
        currentHunger += hungerAmount;
        if (currentHunger > maxHunger) currentHunger = maxHunger;
    }
    public void UpdateThirst(float thirstAmount)
    {
        currentThirst += thirstAmount;
        if (currentThirst > maxThirst) currentThirst = maxThirst;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage * Time.deltaTime;

        if(Enemy.isAttacking == true)
        {
            damageEffect.SetActive(true);
            StartCoroutine(DamageEffect());
            isPlay = false;
            if (!enemyAttackSound.isPlaying)
            {
                enemyAttackSound.Play();
            }
        }
    }
    IEnumerator DamageEffect()
    {
        yield return new WaitForSeconds(1f);
        isPlay = true;
    }
    public void Die()
    {
        gameplayAudio.Stop();
        enemyAttackSound.Stop();
        damageEffect.SetActive(false);

        MouseLook.instance.openPanel = true;
        gameOver.SetActive(true);
        Time.timeScale = 0.0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
