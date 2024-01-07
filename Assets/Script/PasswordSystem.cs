using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PasswordSystem : MonoBehaviour
{
    private TMP_InputField inputTextField;
    public TMP_Text text;
    public PuzzleManager2 puzzleManager2;

    private void Start()
    {
        inputTextField = GetComponent<TMP_InputField>();
    }

    public void CheckPass()
    {
        switch (inputTextField.text)
        {
            case "Lion":
                text.text = "this is true, this is a lion";
                puzzleManager2.LionHide(); 
                StartCoroutine(HidePuzzleAfterDelay(2f));
                break;
            case "Richard Medan":
                text.text = "HAIL RICHARD MEDAN";
                break;
            default:
                text.text = "WRONG";
                break;
        }
    }

    private IEnumerator HidePuzzleAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        puzzleManager2.PuzzleHide();
    }
}
