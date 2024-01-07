using UnityEngine;
using UnityEngine.EventSystems;
public class ObjectRotator : MonoBehaviour
{
    public float rotationSpeed = 5f; // Adjust this to set the rotation speed
    public float rotateAmount = 90f;

    public bool kelar;
    public FoodPuzzle puzzleChecker;
    void Update()
    {
        checkStatusPuzzle();
        if (Mathf.RoundToInt(transform.GetComponent<RectTransform>().eulerAngles.z) == 0)
        {
            kelar = true;
        }

        if (Input.GetMouseButtonDown(0))
        {
            // Raycast to check if the mouse is over the object
            //Vector2 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(Input.mousePosition, Vector2.zero);

            if (hit.collider != null && hit.collider.CompareTag("PuzzlePiece"))
            {
                // Rotate the object by a certain degree around the Z-axis
                hit.transform.eulerAngles += new Vector3(0, 0, 90);

            }



        }
    }
    public void checkStatusPuzzle()
    {
        puzzleChecker.CheckPuzzleStatus();
    }
}