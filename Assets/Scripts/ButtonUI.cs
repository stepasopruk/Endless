using UnityEngine;
using UnityEngine.UI;

public class ButtonUI : MonoBehaviour
{
    [SerializeField] Score score;
    [SerializeField] GameObject[] button;

    [SerializeField] MeshRenderer player;
    [SerializeField] MeshCollider meshColliderPlayer;

    [SerializeField] Mesh meshHexagon;
    [SerializeField] Mesh meshParallelogram;
    [SerializeField] Mesh meshRhombus;
    [SerializeField] Mesh meshSquare;
    [SerializeField] Mesh meshTrapezoid;
    [SerializeField] Mesh meshTriangle;


    float valueScore;
    float range = 300f;
    int index = 0;
    private void FixedUpdate()
    {
        valueScore = (int)score._score / 2;

        if (valueScore >= range && index < 6)
        {
            button[index].GetComponent<Button>().enabled = true;
            button[index].GetComponent<Image>().color = new Color(255, 255, 255, 255);
            index++;
            range += 300f;
        }

    }

    public void HexagonButton()
    {
        player.GetComponent<MeshFilter>().mesh = meshHexagon;
        meshColliderPlayer.sharedMesh = meshHexagon;
    }
    public void ParallelogramButton()
    {
        player.GetComponent<MeshFilter>().mesh = meshParallelogram;
        meshColliderPlayer.sharedMesh = meshParallelogram;
    }
    public void RhombusButton()
    {
        player.GetComponent<MeshFilter>().mesh = meshRhombus;
        meshColliderPlayer.sharedMesh = meshRhombus;
    }
    public void SquareButton()
    {
        player.GetComponent<MeshFilter>().mesh = meshSquare;
        meshColliderPlayer.sharedMesh = meshSquare;
    }
    public void TrapezoidButton()
    {
        player.GetComponent<MeshFilter>().mesh = meshTrapezoid;
        meshColliderPlayer.sharedMesh = meshTrapezoid;
    }
    public void TriangleButton()
    {
        player.GetComponent<MeshFilter>().mesh = meshTriangle;
        meshColliderPlayer.sharedMesh = meshTriangle;
    }
}
