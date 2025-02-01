using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : MonoBehaviour
{
    [SerializeField] private ResourceType _resourceType;
    [SerializeField] private int _resourceAmount;
    [SerializeField] private ItemType _obtainItemType;

    public bool IsObtainable(ItemType itemType)
    {
        return _obtainItemType == itemType;
    }

    public void GetValues(out ResourceType resourceType, out int resourceAmount)
    {
        resourceType = _resourceType;
        resourceAmount = _resourceAmount;
    }
}
