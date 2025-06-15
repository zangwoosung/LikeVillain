using UnityEngine;

public class MineManager : MonoBehaviour
{
    [SerializeField] GameObject[] _mines;
    [SerializeField] Transform[] _positions;
    [SerializeField] Transform _parent;
    [SerializeField] Transform _3DTiles;
    [SerializeField] GameObject[] _collectable;
    [SerializeField] Transform startPoint;
    [SerializeField] Transform endPoint;


    void Start()
    {
        _3DTiles.transform.Clear();
        _parent.transform.Clear();      
        SetupTile();
    }

    private void SetupTile()
    {
        Vector3 pos = startPoint.position;
        Debug.Log("A " + startPoint.position.x);
        Debug.Log("B" + endPoint.position.x);
        int count = 0;

        while (count < 20)
        {
            GameObject clone = Instantiate(_mines[Random.Range(0, _mines.Length)]);
            pos.x += clone.GetComponent<Renderer>().bounds.size.x;
            Debug.Log("siez x" + clone.GetComponent<Renderer>().bounds.size.x);

            clone.transform.position = pos;
           // count++;
            if (pos.x > endPoint.position.x) break;

        }
    }


    public void CreateMines(int max = 10)
    {
        max = _positions.Length;
        for (int i = 0; i < max; i++)
        {
            GameObject clone = Instantiate(_mines[Random.Range(0, _mines.Length)], _positions[i].position, Quaternion.identity);

            clone.transform.parent = _parent;
        }
    }
    public void CreateCollectable(int max = 10)
    {
        for (int i = 0; i < max; i++)
        {
            GameObject clone = Instantiate(_collectable[Random.Range(0, _collectable.Length)], _positions[i].position, Quaternion.identity);

            clone.transform.parent = _parent;
        }
    }

   
    public void RemoveMines()
    {
        _parent.transform.Clear();
    }
}

