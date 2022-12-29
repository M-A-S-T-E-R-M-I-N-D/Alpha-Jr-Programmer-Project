using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

// Sets the script to be executed later than all default scripts
// This is helpful for UI, since other things may need to be initialized before setting the UI
[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    public ColorPicker ColorPicker;

    public void NewColorSelected(Color color)
    {
        // add code here to handle when a color is selected
        MainManager.I.teamColor = color;
    }

    public void StartNew() => SceneManager.LoadScene(1);

    public void Exit()
    {
        MainManager.I.SaveColor();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    public void SaveColorClicked() => MainManager.I.SaveColor();

    public void LoadColorClicked()
    {
        MainManager.I.LoadColor();
        ColorPicker.SelectColor(MainManager.I.teamColor);
    }

    private void Start()
    {
        ColorPicker.Init();
        //this will call the NewColorSelected function when the color picker have a color button clicked.
        ColorPicker.onColorChanged += NewColorSelected;
        ColorPicker.SelectColor(MainManager.I.teamColor);
    }
}
