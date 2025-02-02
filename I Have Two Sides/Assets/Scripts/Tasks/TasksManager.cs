using UnityEngine;

public class TasksManager : MonoBehaviour
{
    public static TasksManager Instance { get; private set; }

    [SerializeField] private int _taskAmount;
    private int _taskCompleted = 0;

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

    public void CompleteTask()
    {
        ++_taskCompleted;
    }

    public bool isSuccess()
    {
        return _taskCompleted == _taskAmount;
    }
}
