using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public PuzzleManager puzzleManager;
    public PlayerMovement playerMovement;
    public float interactionDistance = 2f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (IsPlayerNearby())
            {
                Interact();
            }
        }
    }

    bool IsPlayerNearby()
    {
        Vector3 playerPosition = playerMovement.transform.position;
        Vector3 objectPosition = transform.position;
        float distance = Vector3.Distance(playerPosition, objectPosition);
        return distance <= interactionDistance;
    }

    void Interact()
    {
        puzzleManager.ShowPuzzle();
        playerMovement.SetCanMove(false);

        // Subscribe to the puzzle completion event
        puzzleManager.OnPuzzleCompleted += HandlePuzzleCompleted;
    }

    void HandlePuzzleCompleted()
    {
        puzzleManager.HidePuzzle();
        playerMovement.SetCanMove(true);
        // Unsubscribe from the event to avoid memory leaks
        puzzleManager.OnPuzzleCompleted -= HandlePuzzleCompleted;

        // Ensure that the player can move again
       
    }
}


