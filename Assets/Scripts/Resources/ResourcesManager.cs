using System;
using System.Collections.Generic;
using UnityEngine;

public class ResourcesManager : MonoBehaviour
{
    public static ResourcesManager Instance { get; private set; }

    private Dictionary<ResourceType, int> _resourcesAmount;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
    }   

    private void Start() {
        _resourcesAmount = new Dictionary<ResourceType, int>();

        foreach (ResourceType type in Enum.GetValues(typeof(ResourceType)))
            _resourcesAmount[type] = 0;
    }

    public void AddResourses(ResourceType resourceType, int add)
    {
        _resourcesAmount[resourceType] += add;
    }

    public void DecreaseResource(ResourceType resourceType, int decrease)
    {
        _resourcesAmount[resourceType] = Mathf.Max(_resourcesAmount[resourceType] - decrease, 0);
    }

    public int GetResourceAmount(ResourceType resourceType)
    {
        return _resourcesAmount.TryGetValue(resourceType, out int amount) ? amount : 0;
    }
}
