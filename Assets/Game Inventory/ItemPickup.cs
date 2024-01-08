using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Progress;

public class ItemPickup : MonoBehaviour
{
    public Item currentItem;
    public InventorySO InventorySO; 
  
    [SerializeField]
    private inventoryManage inventory;
    public TMP_Text itemName;
    public GameObject hoverItems;

    public float radius = 3f;

    private void Update()
    {
        float distance = Vector3.Distance(transform.position, transform.position);

        if (distance <= radius)
        {
            if(Input.GetKeyDown(KeyCode.F)) 
            {
                Pickup();
            }
        }
        HoverItem();
    }
  
    public void Pickup()
    {
        RaycastHit hit;

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 5f))
        {
            if (hit.collider.GetComponent<pickableItem>())
            {
                Item item = hit.collider.GetComponent<pickableItem>().item;

                InventorySO.ItemsList.Add(item);
                inventory.updateInventory();
                Destroy(hit.collider.gameObject);

            }
        }
    }
    private void HoverItem()
    {
        RaycastHit hit;

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 5f))
        {
            if (hit.collider.GetComponent<pickableItem>())
            {
                Item hoverItem = hit.collider.GetComponent<pickableItem>().item;
                
                itemName.text = hoverItem.name;
                hoverItems.SetActive(true);
                if(MouseLook.instance.openPanel == true)
                {
                    hoverItems.SetActive(false);
                }
            }
            else
            {
                hoverItems.SetActive(false);
            }
        }
    }
}