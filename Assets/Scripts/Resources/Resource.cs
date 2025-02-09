using UnityEngine;

public class Resource : MonoBehaviour
{
    [SerializeField] private ResourceType _resourceType;
    [SerializeField] private int _resourceAmount;
    [SerializeField] private ItemType _obtainItemType;
    [SerializeField] private int _harvestAmount;

    private int _harvestCounter = 0;

    public bool IsObtainable(ItemType itemType)
    {
        return _obtainItemType == itemType;
    }

    public void GetValues(out ResourceType resourceType, out int resourceAmount)
    {
        resourceType = _resourceType;
        resourceAmount = _resourceAmount;

        ++_harvestCounter;

        if (_harvestCounter >= _harvestAmount)
        {
            switch(_resourceType){
                case ResourceType.Wood:
                    GameManager.Instance.PlaySound(0);
                    break;
                case ResourceType.Mushroom:
                    GameManager.Instance.PlaySound(3);
                    break;
                case ResourceType.Grass:
                    GameManager.Instance.PlaySound(1);
                    break;
                case ResourceType.Meat:
                    GameManager.Instance.PlaySound(2);
                    break;
            }
            gameObject.SetActive(false);
        }
    }
}
