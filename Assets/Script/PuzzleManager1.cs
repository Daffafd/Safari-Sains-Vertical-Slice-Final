using UnityEngine;
using System;

public class PuzzleManager1 : MonoBehaviour
{
    public GameObject puzzleCanvas;
    public InteractableObject1 interacble;
    public GameObject GakAdaAset;
    void Start()
    {
        puzzleCanvas.SetActive(false);
    }
    public void ShowPuzzle()
    {
        puzzleCanvas.SetActive(true);
    }
    public void PuzzleHide()
    {
        puzzleCanvas.SetActive(false);
        interacble.PlayerFinishInteract();
        GakAdaAset.SetActive(false);

    }
    public void HidePuzzle()
    {
        puzzleCanvas.SetActive(false);
    }
}
