using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DialogueText : MonoBehaviour
{
    public bool _beginAtSceneStarting = true;
    [SerializeField] private string _nextSceneName = "Level2";

    public string[] lines;
    public float speedText;
    public Text dialogueText;

    public int index;

    private void Start()
    {
        dialogueText.text = string.Empty;
        if (_beginAtSceneStarting) { StartDialogue(); }
    }

    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            dialogueText.text += c;
            yield return new WaitForSeconds(speedText);
        }
    }

    public void SkipTextClick()
    {
        if (dialogueText.text == lines[index])
        {
            NextLines();
        }
        else
        {
            StopAllCoroutines();
            dialogueText.text = lines[index];
        }
    }

    public void NextLines()
    {
        if (index < lines.Length - 1)
        {
            index++;
            StopAllCoroutines();
            dialogueText.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
            if (_nextSceneName != "")
            {
                SceneManager.LoadScene(_nextSceneName);
            }
        }
    }

}
