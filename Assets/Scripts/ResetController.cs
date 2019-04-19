using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ResetController : MonoBehaviour
{
    public Button resetButton;

    private void Start()
    {
        resetButton.onClick.AddListener(TaskOnClick);
    }

    private void TaskOnClick()
    {
        SceneManager.LoadScene("GameArea");
    }
}