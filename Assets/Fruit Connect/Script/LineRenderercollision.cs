using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EdgeCollider2D))]
public class LineRenderercollision : MonoBehaviour {
    EdgeCollider2D edgeCollider;
    LineRenderer myLine;

    public bool loss;

    // Start is called before the first frame update
    void Start() {
        edgeCollider = this.GetComponent<EdgeCollider2D>();
        myLine = this.GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update() {
        SetEdgeCollider(myLine);
    }

    void SetEdgeCollider(LineRenderer lineRenderer) {
        List<Vector2> edges = new List<Vector2>();

        for (int point = 0; point < lineRenderer.positionCount; point++) {
            Vector3 lineRendererPoint = lineRenderer.GetPosition(point);
            edges.Add(new Vector2(lineRendererPoint.x, lineRendererPoint.y));
        }

        edgeCollider.SetPoints(edges);
    }


    private void OnTriggerStay2D(Collider2D collision) {
        Debug.Log("S1");
        if (collision.gameObject.CompareTag("Player")) {
        Debug.Log("S2");
            loss = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        Debug.Log("Enter1");
        if (collision.gameObject.CompareTag("Player")) {
        Debug.Log("Enter2");
            loss = true;
        }

    }
    private void OnTriggerExit2D(Collider2D collision) {
        Debug.Log("CExit1");
        if (collision.gameObject.CompareTag("Player")) {
        Debug.Log("CExit2");
            loss = true;
        }

    }
}
