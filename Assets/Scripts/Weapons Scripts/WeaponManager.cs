using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    #region Singleton
    public static WeaponManager instance;
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

    [SerializeField] private Weapons[] weapons;
    private int current_Weapon_Index;

    private void Start() 
    {
        current_Weapon_Index = 0;
        weapons[current_Weapon_Index].gameObject.SetActive(true);
    }
    private void Update() 
    {
        if(Input.GetKeyDown(KeyCode.Alpha1)) 
        {
            TurnOnSelectedWeapon(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2)) 
        {
            TurnOnSelectedWeapon(1);
        }
    }

    void TurnOnSelectedWeapon(int weaponIndex) 
    {
        if(current_Weapon_Index == weaponIndex)
            return;

        //Turn Off the current weapon
        weapons[current_Weapon_Index].gameObject.SetActive(false);

        //Turn On the current weapon
        weapons[weaponIndex].gameObject.SetActive(true);

        //Store the current selected weapon index
        current_Weapon_Index = weaponIndex;
    }
    public Weapons SelectedWeapon() 
    {
        return weapons[current_Weapon_Index];
    }

}