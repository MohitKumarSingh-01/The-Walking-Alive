using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsInfo : MonoBehaviour
{
    public Item item;
    private inventoryManage inventoryManage;
    private void Start()
    {
        inventoryManage=GameObject.FindGameObjectWithTag("canvas").GetComponent<inventoryManage>();
    }
   public void SelectItem()
    {
        inventoryManage.currentItem = this.gameObject;
    }

}
