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



    private void FixedUpdate()
    {
        if(((int)score._score / 2) == 300f)
        {
            button[1].GetComponent<Button>().enabled = true;
            button[1].GetComponent<Image>().color = new Color(255,255,255,255);
        }
        if (((int)score._score / 2) == 600f)
        {
            button[2].GetComponent<Button>().enabled = true;
            button[2].GetComponent<Image>().color = new Color(255, 255, 255, 255);
        }
        if (((int)score._score / 2) == 900f)
        {
            button[3].GetComponent<Button>().enabled = true;
            button[3].GetComponent<Image>().color = new Color(255, 255, 255, 255);
        }
        if (((int)score._score / 2) == 1200f)
        {
            button[4].GetComponent<Button>().enabled = true;
            button[4].GetComponent<Image>().color = new Color(255, 255, 255, 255);
        }
        if (((int)score._score / 2) == 1500f)
        {
            button[5].GetComponent<Button>().enabled = true;
            button[5].GetComponent<Image>().color = new Color(255, 255, 255, 255);
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
