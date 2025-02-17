using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public GameObject handPosition; 
    private GameObject heldItem;
    public GameObject throwButton; 

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                
                if (hit.transform.CompareTag("Pickupable")) 
                {
                    PickupItem(hit.transform.gameObject);
                }
            }
        }
    }

    void PickupItem(GameObject item)
  {
    if (heldItem == null)
    {
        Debug.Log("Предмет поднят: " + item.name);

        // Устанавливаем heldItem как текущий предмет, который поднимаем
        heldItem = item;

      
        heldItem.transform.SetParent(handPosition.transform); 

        
        heldItem.transform.localPosition = Vector3.zero;

        
        Collider collider = heldItem.GetComponent<Collider>();
        if (collider != null)
        {
            collider.enabled = false;
        }

        
        Rigidbody rb = heldItem.GetComponent<Rigidbody>();
        if (rb != null)
        {
            Destroy(rb);
        }

       
        throwButton.SetActive(true);
        
       
        item.SetActive(false); 

       
        heldItem.SetActive(true);
    }
    else
    {
        Debug.Log("Уже удерживается предмет: " + heldItem.name);
    }
}
    public void ThrowItem()
    {
        if (heldItem != null)
        {
            Debug.Log("Предмет выброшен: " + heldItem.name);

            
            heldItem.transform.SetParent(null);

            
            Collider collider = heldItem.GetComponent<Collider>();
            if (collider != null)
            {
                collider.enabled = true;
            }

            
            Rigidbody rb = heldItem.GetComponent<Rigidbody>();
            if (rb == null)
            {
                rb = heldItem.AddComponent<Rigidbody>();
            }

           
            rb.AddForce(Camera.main.transform.forward * 500); 

           
            heldItem = null;

           
            throwButton.SetActive(false);
        }
    }

    public void OnThrowButtonPressed()
    {
        ThrowItem();
    }
}
