using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class inventoryManage : MonoBehaviour
{
    #region Singleton
    public static inventoryManage instance;
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

    public GameObject inventoryUI;
    public GameObject currentItem;
    [SerializeField]
    private InventorySO inventory;
    [SerializeField]
    private GameObject inventorySlot;
    [SerializeField]
    private GameObject itemParent;

    [SerializeField]
    private GameObject useBtn;

    private Transform player;
    public bool isOpen = false;

    private void Start()
    {
       
        player = GameObject.FindGameObjectWithTag("Player").transform;

        updateInventory();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I) && isOpen == false && MouseLook.instance.openPanel == false)
        {
            isOpen = true;
            MouseLook.instance.openPanel = true;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            inventoryUI.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.I) && isOpen == true)
        {
            isOpen = false;
            MouseLook.instance.openPanel = false;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            inventoryUI.SetActive(false);

        }
        if(currentItem == null) 
        { 
            useBtn.SetActive(false);
        }
        else
        {
            useBtn.SetActive(true);
        }
    }
    public void updateInventory()
    {
        for(int i=0;i<itemParent.transform.childCount;i++)

        Destroy(itemParent.transform.GetChild(i).gameObject);

        foreach(var item in inventory.ItemsList)
        {
            GameObject temp = inventorySlot;
            temp.name = item.name;
            temp.GetComponent<ItemsInfo>().item = item;
            temp.transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = item.icon;
            Instantiate(inventorySlot, transform.position, transform.rotation, itemParent.transform);
        }
    }
   
    public void UseItem()
    {
        Item currentItemInfo = currentItem.GetComponent<ItemsInfo>().item;

        if (SurvivalManager.instance.currentHealth < 100 && currentItemInfo.type == Type.Health)
        {
            SurvivalManager.instance.UpdateHealth(currentItemInfo.value);
            inventory.ItemsList.Remove(currentItemInfo);
            Destroy(currentItem);

        }
        else if (SurvivalManager.instance.currentHunger < 100 && currentItemInfo.type == Type.Hunger)
        {
            SurvivalManager.instance.UpdateHunger(currentItemInfo.value);
            inventory.ItemsList.Remove(currentItemInfo);
            Destroy(currentItem);

        }
        else if (SurvivalManager.instance.currentThirst < 100 && currentItemInfo.type == Type.Thirst)
        {
            SurvivalManager.instance.UpdateThirst(currentItemInfo.value);
            inventory.ItemsList.Remove(currentItemInfo);
            Destroy(currentItem);

        }
        else if (PlayerShoot.instance.maxAmmo < 60 && currentItemInfo.type == Type.Ammo)
        {
            PlayerShoot.instance.UpdateAmmo(currentItemInfo.value);
            inventory.ItemsList.Remove(currentItemInfo);
            Destroy(currentItem);

        }
        else if (currentItemInfo.type == Type.Key)
        {
            DoorController.isKeyCollected = true;
            inventory.ItemsList.Remove(currentItemInfo);
            Destroy(currentItem);

        }
        else if (currentItemInfo.type == Type.Fuel)
        {
            HelicopterFly.isGasCollected = true;
            inventory.ItemsList.Remove(currentItemInfo);
            Destroy(currentItem);

        }

        updateInventory();
    }

    public void RemoveItem()
    {
        Item currentItemInfo = currentItem.GetComponent<ItemsInfo>().item;

        Vector3 offset = new Vector3(0, 1, 3);

        Instantiate(currentItemInfo.prefab, player.position+offset, player.rotation);
        Destroy(currentItem);
       
        inventory.ItemsList.Remove(currentItemInfo);
        updateInventory();
    }
}
