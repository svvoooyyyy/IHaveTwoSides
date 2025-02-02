using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Transform _newPlayerPosition;
    [SerializeField] private GameObject _currentRoom;
    [SerializeField] private GameObject _nextRoom;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            collider.gameObject.transform.position = _newPlayerPosition.position;
            _currentRoom.SetActive(false);
            _nextRoom.SetActive(true);
        }
    }
}
