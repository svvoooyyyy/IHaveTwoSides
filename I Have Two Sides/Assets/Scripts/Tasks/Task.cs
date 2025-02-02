using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Task : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _taskText;
    [SerializeField] private List<int> _neededResources;
    [SerializeField] private Sprite _completedSprite;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _neededResources = new List<int>();

        foreach (ResourceType type in Enum.GetValues(typeof(ResourceType)))
            _neededResources[(int)type] = 0;
    }

    private bool CanComplete()
    {
        for (int i = 0; i < _neededResources.Count; ++i)
        {
            if (ResourcesManager.Instance.GetResourceAmount((ResourceType)i) < _neededResources[i])
                return false;
        }

        return true;
    }

    public void TryComplete()
    {
        if (!CanComplete())
            return;

        TasksManager.Instance.CompleteTask();
        _taskText.fontStyle = FontStyles.Strikethrough;
        _spriteRenderer.sprite = _completedSprite;

        for (int i = 0; i < _neededResources.Count; ++i)
            ResourcesManager.Instance.DecreaseResource((ResourceType)i, _neededResources[i]);
    }
}
