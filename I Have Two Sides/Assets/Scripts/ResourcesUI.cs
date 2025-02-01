using TMPro;
using UnityEngine;

public class ResourcesUI : MonoBehaviour
{
    [SerializeField] private ResourceType _resourceType;
    [SerializeField] private TextMeshProUGUI _resourseCounterText;
    
    private void Update()
    {
<<<<<<< HEAD
        _resourseCounterText.text = ResourcesManager.Instance.GetResourceAmount(_resourceType).ToString();
=======
        _resourseCounterText.text = ResourcesManager.GetResourceAmount(_resourceType).ToString();
>>>>>>> svvoooyyyy
    }
}
