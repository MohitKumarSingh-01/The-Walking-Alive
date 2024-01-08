using UnityEngine;
using System.Collections;

public class HelicopterFly : MonoBehaviour
{
    public GameObject helicopter;
    public AudioSource helicopterSound;
    private Animator animator;

    [SerializeField]
    private Transform playerHeliPos;
    [SerializeField]
    private GameObject readyToFly;
    [SerializeField]
    private GameObject fuelPanel;
    bool isClicked;
    public static bool isGasCollected = false;
    private void Start()
    {
        animator = helicopter.GetComponent<Animator>();
        //playerHeliPos = helicopter.transform.Find("playerSpawnPos").transform.localPosition;
        isClicked = false;
    }
    private void Update()
    {
        if ( isGasCollected && Vector3.Distance(transform.position,helicopter.transform.position)<10 )
        {
            fuelPanel.SetActive(false);

            if(!isClicked)
                readyToFly.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Return)) {
                isClicked = true;
                helicopterSound.Play();
                transform.SetParent(playerHeliPos, true);
                animator.SetTrigger("Fly");
                GetComponent<CharacterController>().enabled = false;
                transform.localPosition = Vector3.zero;
            }
  
        }
        else if( Vector3.Distance(transform.position, helicopter.transform.position) < 10)
        {
            fuelPanel.SetActive(true);
            readyToFly.SetActive(false);
        }
        else
        {
            fuelPanel.SetActive(false);
            readyToFly.SetActive(false);
        }
        if (isClicked)
            readyToFly.SetActive(false);

    }
}
