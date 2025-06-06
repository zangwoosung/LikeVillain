using UnityEngine;
using UnityEngine.Splines;

public class SplineEditor : MonoBehaviour
{

    public SplineContainer splineContainer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    Spline spline;
    void Start()
    {

        spline = splineContainer.Spline;

        //if (spline.Count ==0)
        //{
        //    var newPosition = new Vector3(5f, 0f, 5f);

        //    var knot = spline[0]; // index 1
        //    knot.Position = newPosition;

        //    // Optionally, adjust tangent if needed
        //    // knot.TangentIn = ...;
        //    // knot.TangentOut = ...;

        //    spline.SetKnot(0, knot);
        //}
    }
    void AddNodes()
    {
        for (int i = 0; i < 3; i++)
        {
            var newPosition = new Vector3(i, 0f, 0f);

            var knot = spline[i]; // index 1
            knot.Position = newPosition;
            knot.TangentIn = Vector3.zero;
            knot.TangentOut = Vector3.zero;

            // Apply linear tangent mode
            spline.SetTangentMode(i, TangentMode.Linear);
            spline.Add(knot);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            AddNodes();
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            var newPosition = new Vector3(5f, 2f, 2f);

            var knot = spline[1]; // index 1
            knot.Position = newPosition;

            // Optionally, adjust tangent if needed
            // knot.TangentIn = ...;
            // knot.TangentOut = ...;

            spline.SetKnot(2, knot);

        }
    }
}
