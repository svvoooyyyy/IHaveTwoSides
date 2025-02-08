using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Task : MonoBehaviour
{
    [SerializeField] private List<int> _needResources;
    [SerializeField] private ItemType _needItem;
    [SerializeField] private TextMeshProUGUI _taskText;
    [SerializeField] private GameObject _defaultTexture;
    [SerializeField] private GameObject _completedTexture;

    private void Start()
    {
        _defaultTexture.SetActive(true);
        _completedTexture.SetActive(false);
    }

    private bool CanComplete()
    {
        for (int i = 0; i < _needResources.Count; ++i)
        {
            if (ResourcesManager.Instance.GetResourceAmount((ResourceType)i) < _needResources[i])
                return false;
        }

        return true;
    }

    public ItemType GetNeedItem()
    {
        return _needItem;
    }

    public void TryComplete()
    {
        if (!CanComplete())
            return;

        for (int i = 0; i < _needResources.Count; ++i)
            ResourcesManager.Instance.DecreaseResource((ResourceType)i, _needResources[i]);
        
        TasksManager.Instance.Complete();
        _taskText.fontStyle = FontStyles.Strikethrough;
        _defaultTexture.SetActive(false);
        _completedTexture.SetActive(true);
    }
}