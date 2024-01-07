using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Transform gameTransform;
    [SerializeField] private Transform piecePrefab;

    private List<Transform> pieces;
    private int emptyLocation;
    private int boardSize;
    private bool shuffling = false;
    public bool OnPuzzleCompleted = false;
    public PuzzleManager puzzleManager;
    public PlayerMovement playerMovement;

    private void CreateGamePieces(float gapThickness)
    {
        float width = 1 / (float)boardSize;
        for (int row = 0; row < boardSize; row++)
        {
            for (int col = 0; col < boardSize; col++)
            {
                Transform piece = Instantiate(piecePrefab, gameTransform);
                pieces.Add(piece);

                Vector3 piecePosition = new Vector3(-1 + (2 * width * col) + width,
                                                  +1 - (2 * width * row) - width,
                                                  0);
                piece.localPosition = piecePosition;

                Vector3 pieceScale = ((2 * width) - gapThickness) * Vector3.one;
                piece.localScale = pieceScale;

                piece.name = $"{(row * boardSize) + col}";

                if ((row == boardSize - 1) && (col == boardSize - 1))
                {
                    emptyLocation = (boardSize * boardSize) - 1;
                    piece.gameObject.SetActive(false);
                }
                else
                {
                    SetPieceUVs(piece, width, gapThickness, row, col);
                }
            }
        }
    }

    private void SetPieceUVs(Transform piece, float width, float gapThickness, int row, int col)
    {
        float gap = gapThickness / 2;
        Mesh mesh = piece.GetComponent<MeshFilter>().mesh;
        Vector2[] uv = new Vector2[4];

        uv[0] = new Vector2((width * col) + gap, 1 - ((width * (row + 1)) - gap));
        uv[1] = new Vector2((width * (col + 1)) - gap, 1 - ((width * (row + 1)) - gap));
        uv[2] = new Vector2((width * col) + gap, 1 - ((width * row) + gap));
        uv[3] = new Vector2((width * (col + 1)) - gap, 1 - ((width * row) + gap));

        mesh.uv = uv;
    }

    void Start()
    {
        pieces = new List<Transform>();
        boardSize = 3;
        CreateGamePieces(0.01f);


        shuffling = true;
        StartCoroutine(WaitShuffle(0.5f));

        // Subscribe to the event
        puzzleManager.OnPuzzleCompleted += PuzzleCompleted;
    }

    void Update()
    {
        if (!shuffling && CheckCompletion())
        {
            if (!OnPuzzleCompleted)
            {
                OnPuzzleCompleted = true;
                Debug.Log("Congratulations! You completed the puzzle!");
                puzzleManager?.PuzzleCompleted();
                playerMovement.SetCanMove(true);
            }
        }
        else
        {
            OnPuzzleCompleted = false;

            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
                if (hit)
                {
                    HandlePieceClick(hit.transform);
                }
            }
        }
    }

    void HandlePieceClick(Transform clickedPiece)
    {
        for (int i = 0; i < pieces.Count; i++)
        {
            if (pieces[i] == clickedPiece)
            {
                if (SwapIfValid(i, -boardSize, boardSize) || SwapIfValid(i, +boardSize, boardSize) ||
                    SwapIfValid(i, -1, 0) || SwapIfValid(i, +1, boardSize - 1))
                {
                    break;
                }
            }
        }
    }

    private bool SwapIfValid(int i, int offset, int colCheck)
    {
        if (((i % boardSize) != colCheck) && ((i + offset) == emptyLocation))
        {
            SwapPieces(i, i + offset);
            emptyLocation = i;
            return true;
        }
        return false;
    }

    private void SwapPieces(int indexA, int indexB)
    {
        (pieces[indexA], pieces[indexB]) = (pieces[indexB], pieces[indexA]);
        (pieces[indexA].localPosition, pieces[indexB].localPosition) = (pieces[indexB].localPosition, pieces[indexA].localPosition);
    }

    private bool CheckCompletion()
    {
        for (int i = 0; i < pieces.Count; i++)
        {
            if (pieces[i].name != $"{i}")
            {
                return false;
            }
        }
        return true;
    }

    private IEnumerator WaitShuffle(float duration)
    {
        yield return new WaitForSeconds(duration);
        Shuffle();
        shuffling = false;
    }

    private void Shuffle()
    {
        int count = 0;
        int last = 0;
        while (count < (boardSize * boardSize * boardSize))
        {
            int rnd = Random.Range(0, boardSize * boardSize);
            if (rnd == last) { continue; }
            last = emptyLocation;

            if (SwapIfValid(rnd, -boardSize, boardSize) || SwapIfValid(rnd, +boardSize, boardSize) ||
                SwapIfValid(rnd, -1, 0) || SwapIfValid(rnd, +1, boardSize - 1))
            {
                count++;
            }
        }
    }

    // Event handler for the puzzle completion event
    void PuzzleCompleted()
    {
        Debug.Log("GameManager: Puzzle completed event received");
    }
}
