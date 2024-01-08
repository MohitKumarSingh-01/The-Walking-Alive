using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu (fileName ="inventory",menuName ="inventory/inventoryItems",order =2)]
public class InventorySO : ScriptableObject
{
    public List<Item> ItemsList;

}
