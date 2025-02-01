using TMPro;
using UnityEngine;

public class ResourcesUI : MonoBehaviour
{
    [SerializeField] private ResourceType _resourceType;
    [SerializeField] private TextMeshProUGUI _resourseCounterText;
    
    private void Update()
    {
        _resourseCounterText.text = ResourcesManager.GetResourceAmount(_resourceType).ToString();
    }
}
