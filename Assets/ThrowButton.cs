using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

[DebuggerDisplay("{" + nameof(GetDebuggerDisplay) + "(),nq}")]
public class ThrowButton : MonoBehaviour
{
    public Item currentItem;

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(ThrowItem);
    }

    public void ThrowItem()
    {
        if (currentItem != null)
        {
            currentItem.isHeld = false;
            currentItem.transform.SetParent(null);
            Rigidbody rb = currentItem.gameObject.AddComponent<Rigidbody>();
            rb.AddForce(Camera.main.transform.forward * 500);
            currentItem = null; 
        }
    }

    public void SetCurrentItem(Item item)
    {
        currentItem = item;
    }

    private string GetDebuggerDisplay()
    {
        return ToString();
    }
}
