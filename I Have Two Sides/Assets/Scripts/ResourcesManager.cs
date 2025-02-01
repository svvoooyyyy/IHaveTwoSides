using System;
using System.Collections.Generic;
using UnityEngine;

<<<<<<< HEAD
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
=======
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
>>>>>>> svvoooyyyy
    }
}
