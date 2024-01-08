using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/ItemList")]
public class Item : ScriptableObject
{
    public int id;
    new public string name;
    public Sprite icon;
    public GameObject prefab;
    public int value;
    public Type type;
    public int count;
    public bool isDefaultItem = false;

}
public enum Type { Health, Hunger, Thirst, Ammo, Key, Fuel }