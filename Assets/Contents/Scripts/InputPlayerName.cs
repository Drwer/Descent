using UnityEngine;
using UnityEngine.UI;

public class InputPlayerName : MonoBehaviour
{
    public InputField mainInputField;
    public string playerName;

    private void Start()
    {
        mainInputField.characterLimit = 16;
    }
}
