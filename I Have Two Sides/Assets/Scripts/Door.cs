using UnityEngine;
using UnityEngine.AI;

public class Door : MonoBehaviour
{
    [SerializeField] private GameObject _currentRoom;
    [SerializeField] private GameObject _nextRoom;
    [SerializeField] private Transform _newPlayerPosition;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            collider.gameObject.transform.position = _newPlayerPosition.position;
            _currentRoom.SetActive(false);
            _nextRoom.SetActive(true);
        }

        if (collider.gameObject.CompareTag("Werewolf"))
        {
            // changing werewolf target
            collider.gameObject.GetComponent<WerewolfAI>().ChangeTargetToSecond();
            _currentRoom.SetActive(false);
            _nextRoom.SetActive(true);
            collider.gameObject.GetComponent<WerewolfAI>().Warp(_newPlayerPosition.position);
            

            
        }
    }
}
