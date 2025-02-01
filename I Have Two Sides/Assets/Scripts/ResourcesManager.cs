using System;
using System.Collections.Generic;
using UnityEngine;

public static class ResourcesManager
{
    private static Dictionary<ResourceType, int> _resoursesAmount;

    public static void Initialize() {
        _resoursesAmount = new Dictionary<ResourceType, int>();

        foreach (ResourceType type in Enum.GetValues(typeof(ResourceType)))
            _resoursesAmount[type] = 0;
    }

    public static void AddResourses(ResourceType resourceType, int add)
    {
        _resoursesAmount[resourceType] += add;
    }

    public static void DecreaseResource(ResourceType resourceType, int decrease)
    {
        _resoursesAmount[resourceType] = Mathf.Max(_resoursesAmount[resourceType] - decrease, 0);
    }

    public static int GetResourceAmount(ResourceType resourceType)
    {
        return _resoursesAmount[resourceType];
    }
}
