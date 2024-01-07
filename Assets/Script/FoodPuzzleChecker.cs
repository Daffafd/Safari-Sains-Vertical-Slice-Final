using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FoodPuzzle : MonoBehaviour
{
    public List<GameObject> puzzlePieces;
    public PuzzleManager1 puzzleManager1;
    /*    public TMP_Text info;*/

    public void CheckPuzzleStatus()
    {
        foreach (GameObject g in puzzlePieces)
        {
            if (!g.GetComponent<ObjectRotator>().kelar)
            {
                Debug.Log("Belum Selesai");
                return;
            }
        }
        Debug.Log("Selesai");
        puzzleManager1.PuzzleHide();
    }
}
