using UnityEngine;

public class MineManager : MonoBehaviour
{
    [SerializeField] GameObject[] _mines;
    [SerializeField] Transform[] _positions;
    [SerializeField] Transform _parent;
    [SerializeField] GameObject[] _collectable; 

    void Start()
    {
        CreateMines();
    }

    public void CreateMines(int max=10)
    {
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

