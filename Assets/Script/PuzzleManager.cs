using UnityEngine;
using System;

public class PuzzleManager : MonoBehaviour
{
    public GameObject puzzleCanvas;
    public event Action OnPuzzleCompleted;
  

    void Start()
    {
        puzzleCanvas.SetActive(false);
    }

    public void ShowPuzzle()
    {
        puzzleCanvas.SetActive(true);
        Debug.Log("Puzzle shown");
    }

    public void HidePuzzle()
    {
        puzzleCanvas.SetActive(false);
        Debug.Log("Puzzle hidden");
        

        // Optionally, you can trigger the completion event here
        OnPuzzleCompleted?.Invoke();
    }

    // Call this method when the puzzle is completed
    public void PuzzleCompleted()
    {
        // Optionally, you can trigger the completion event here as well
        OnPuzzleCompleted?.Invoke();
    }
}

