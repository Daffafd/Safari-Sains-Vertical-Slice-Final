using UnityEngine;
using System;

public class PuzzleManager2 : MonoBehaviour
{
    public GameObject puzzleCanvas;
    public InteractableObject2 interacble2;
    public GameObject Singa;
    void Start()
    {
        puzzleCanvas.SetActive(false);
    }
    public void ShowPuzzle()
    {
        puzzleCanvas.SetActive(true);
    }
    public void LionHide()
    {

        Singa.SetActive(false);

    }
    public void PuzzleHide()
    {
        puzzleCanvas.SetActive(false);
        interacble2.PlayerFinishInteract();
        

    }
    public void HidePuzzle()
    {
        puzzleCanvas.SetActive(false);
    }
}
