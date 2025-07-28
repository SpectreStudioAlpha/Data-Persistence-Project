// StartMenuUI.cs
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartMenuUI : MonoBehaviour
{
    public InputField nameInput;

    public void StartGame()
    {
        DataManager.Instance.PlayerName = nameInput.text;
        SceneManager.LoadScene("main"); // or whatever your scene name is
    }
}
