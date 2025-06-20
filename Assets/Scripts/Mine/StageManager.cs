using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StageManager: MonoBehaviour
{
    [SerializeField] GameObject[] _mines;
    [SerializeField] Transform[] _positions;
    [SerializeField] Transform _parent;
    [SerializeField] Transform _3DTiles;
    [SerializeField] GameObject[] _collectable;
    [SerializeField] Transform startPoint;
    [SerializeField] Transform endPoint;
    [SerializeField] GameObject _blockPrefab;
    [SerializeField] StageLevelSO currentLevel;

    void Start()
    {
      //DTiles.transform.Clear();
        _parent.transform.Clear();
        HidePosition();
        //SetupTile();
        CreateStateLevel(currentLevel);


    }

    private void HidePosition()
    {
        for (int i = 0; i < _positions.Length; i++)
        {
            _positions[i].gameObject.SetActive(false);
         
        }
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

    void CreateStateLevel(StageLevelSO currentStage)
    {
        List<GameObject> items = new();
        for (int i = 0; i < currentStage.TrapAmount; i++)
        {
            GameObject clone = Instantiate(_mines[Random.Range(0, _mines.Length)] );
            items.Add(clone);
        }
        for (int i = 0; i < currentStage.CollectibleAmount; i++)
        {
            GameObject clone = Instantiate(_collectable[Random.Range(0, _collectable.Length)]);
            clone.GetComponent<Collectible>().JumpForce = currentStage.JumpForce;
            items.Add(clone);
        }
        for (int i = items.Count; i < _positions.Length; i++)
        {
            GameObject clone = Instantiate(_blockPrefab);            
            items.Add(clone);
        }

        for (int i = 0; i < items.Count; i++)
        {
            Debug.Log(items[i].name);
        }

        UTILS.Shuffle(items);
        //UTILS.Shuffle(_positions.ToList());

        for (int i = 0; i < items.Count; i++)
        {
            Debug.Log(items[i].name);
            items[i].transform.position = _positions[i].position;
            items[i].transform.parent = _parent;
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

