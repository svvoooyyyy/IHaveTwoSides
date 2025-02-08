using UnityEngine;
using UnityEngine.SceneManagement;

public class TasksManager : MonoBehaviour
{
    public static TasksManager Instance { get; private set; }

    [SerializeField] private int _tasksAmount;
    [SerializeField] private string _successSceneName;


    private int _tasksCompleted = 0;

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


    public void Complete()
    {
        ++_tasksCompleted;
        if (IsSuccess())
        {
            PlayerPrefs.SetString("EndingScene", _successSceneName);
            SceneManager.LoadScene("TransformationAnimation");
        }
    }

    public bool IsSuccess()
    {
        return _tasksCompleted >= _tasksAmount;
    }
}