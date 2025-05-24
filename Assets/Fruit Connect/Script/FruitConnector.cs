/*using System;
using System.Collections.Generic;
using UnityEngine;

public class FruitConnector : MonoBehaviour {
    public static FruitConnector Instance { get; private set; }


    public int winCount;
    public LineRenderer linePrefab;
    private LineRenderer currentLine;
    private List<Vector3> currentPoints = new List<Vector3>();

    private List<Vector2[]> drawnLines = new List<Vector2[]>(); // For checking line crossing

    public FruitController selectedFruit = null;
    public FruitController hoverFruit = null;
    public FruitController endFruit;
    public bool isJoint = false;

    public LineRenderercollision LineRenderercollision;

    private void Awake() {
        Instance = this;
    }

    *//*void Update() {
        if (Input.GetMouseButtonDown(0)) {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D hit = Physics2D.OverlapPoint(mousePos);

            if (hit && hit.GetComponent<FruitController>()) {
                UIManager.Instance.isWin = false;
                selectedFruit = hit.GetComponent<FruitController>();
                currentLine = Instantiate(linePrefab).GetComponent<LineRenderer>();
                UIManager.Instance.GeneratedLineRendere.Add(currentLine);
                currentPoints.Clear();

                Vector3 startPos = selectedFruit.transform.position;
                currentPoints.Add(startPos);
                currentLine.positionCount = 1;
                currentLine.SetPosition(0, startPos);
                isJoint = false;
            }
        }

        if (Input.GetMouseButton(0) && selectedFruit != null && currentLine != null) {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0f;

            // Add point if distance is significant
            if (Vector3.Distance(currentPoints[currentPoints.Count - 1], mousePos) > 0.1f) {
                currentPoints.Add(mousePos);
                currentLine.positionCount = currentPoints.Count;
                currentLine.SetPosition(currentPoints.Count - 1, mousePos);
            }

            // Check for potential hover over matching fruit
            Collider2D hit = Physics2D.OverlapPoint(mousePos);
            if (hit && hit.GetComponent<FruitController>()) {
                FruitController hovered = hit.GetComponent<FruitController>();
                if (hovered != selectedFruit && hovered.fruitType == selectedFruit.fruitType) {
                    hoverFruit = hovered;
                    selectedFruit.GetComponent<Collider2D>().enabled = false;
                    hoverFruit.GetComponent<Collider2D>().enabled = false;
                    Debug.Log("From Here ----");
                    UIManager.Instance.OnJointFruit();
                    Debug.Log("HOver fruit in Darg  --- " + hoverFruit);
                    isJoint = true;
                    UIManager.Instance.isWin = true;
                }
            }
        }

        if (Input.GetMouseButtonUp(0) && selectedFruit != null && currentLine != null && !isJoint) {
            Debug.Log("HOver fruit in up --- " + hoverFruit);
            if (hoverFruit != null) {
                Vector2 start = selectedFruit.transform.position;
                Vector2 end = hoverFruit.transform.position;

                if (!IsLineCrossing(start, end)) {
                    currentPoints.Add(end);
                    currentLine.positionCount = currentPoints.Count;
                    currentLine.SetPosition(currentPoints.Count - 1, end);

                    drawnLines.Add(new Vector2[] { start, end });


                }
                else {
                    Debug.Log("Here1");
                    UIManager.Instance.GeneratedLineRendere.Remove(currentLine);
                    Destroy(currentLine.gameObject);
                }
            }
            else {
                if (!UIManager.Instance.isWin) {
                    Debug.Log("Here2");
                    UIManager.Instance.GeneratedLineRendere.Remove(currentLine);
                    Destroy(currentLine.gameObject); // fallback if not hovering valid end
                }
            }

            // Reset all
            selectedFruit = null;
            hoverFruit = null;
            currentLine = null;
        }
    }*//*

    void Update() {

        if (selectedFruit != null) {
            if (LineRenderercollision.loss) {
                Debug.Log("Crossing Detected during Drag - Destroying Line");
                UIManager.Instance.GeneratedLineRendere.Remove(currentLine);
                Destroy(currentLine.gameObject);
                selectedFruit = null;
                hoverFruit = null;
                currentLine = null;
            }
        }

        if (Input.GetMouseButtonDown(0)) {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D hit = Physics2D.OverlapPoint(mousePos);

            if (hit && hit.GetComponent<FruitController>()) {
                UIManager.Instance.isWin = false;
                selectedFruit = hit.GetComponent<FruitController>();
                currentLine = Instantiate(linePrefab).GetComponent<LineRenderer>();
                UIManager.Instance.GeneratedLineRendere.Add(currentLine);
                currentPoints.Clear();

                Vector3 startPos = selectedFruit.transform.position;
                currentPoints.Add(startPos);
                currentLine.positionCount = 1;
                currentLine.SetPosition(0, startPos);
                isJoint = false;
            }
        }

        *//*if (Input.GetMouseButton(0) && selectedFruit != null && currentLine != null) {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0f;

            // Add point if distance is significant
            if (Vector3.Distance(currentPoints[currentPoints.Count - 1], mousePos) > 0.1f) {
                currentPoints.Add(mousePos);
                currentLine.positionCount = currentPoints.Count;
                currentLine.SetPosition(currentPoints.Count - 1, mousePos);
            }

            // Check for potential hover over matching fruit
            Collider2D hit = Physics2D.OverlapPoint(mousePos);
            if (hit && hit.GetComponent<FruitController>()) {
                FruitController hovered = hit.GetComponent<FruitController>();
                if (hovered != selectedFruit && hovered.fruitType == selectedFruit.fruitType) {
                    hoverFruit = hovered;
                    selectedFruit.GetComponent<Collider2D>().enabled = false;
                    hoverFruit.GetComponent<Collider2D>().enabled = false;
                    Debug.Log("From Here ----");
                    UIManager.Instance.OnJointFruit();
                    Debug.Log("HOver fruit in Darg  --- " + hoverFruit);
                    isJoint = true;
                    UIManager.Instance.isWin = true;
                }
            }
        }*//*

        if (Input.GetMouseButton(0) && selectedFruit != null && currentLine != null) {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0f;

            // Add point if distance is significant
            if (Vector3.Distance(currentPoints[currentPoints.Count - 1], mousePos) > 0.1f) {
                currentPoints.Add(mousePos);
                currentLine.positionCount = currentPoints.Count;
                currentLine.SetPosition(currentPoints.Count - 1, mousePos);
            }

            // Check for potential hover over matching fruit
            Collider2D hit = Physics2D.OverlapPoint(mousePos);
            if (hit && hit.GetComponent<FruitController>()) {
                FruitController hovered = hit.GetComponent<FruitController>();

                // Only proceed if type matches and not same fruit
                if (hovered != selectedFruit && hovered.fruitType == selectedFruit.fruitType) {
                    Vector2 start = selectedFruit.transform.position;
                    Vector2 end = hovered.transform.position;

                    // Check if the proposed new line crosses existing lines
                    if (!IsLineCrossing(start, end)) {
                        hoverFruit = hovered;
                        selectedFruit.GetComponent<Collider2D>().enabled = false;
                        hoverFruit.GetComponent<Collider2D>().enabled = false;
                        Debug.Log("From Here ----");
                        UIManager.Instance.OnJointFruit();
                        Debug.Log("Hover fruit in Drag  --- " + hoverFruit);
                        isJoint = true;
                        UIManager.Instance.isWin = true;
                    }
                    else {
                        // Line would cross — so destroy current line immediately
                        Debug.Log("Crossing Detected during Drag - Destroying Line");
                        UIManager.Instance.GeneratedLineRendere.Remove(currentLine);
                        Destroy(currentLine.gameObject);
                        selectedFruit = null;
                        hoverFruit = null;
                        currentLine = null;
                    }
                }
            }
        }

        if (Input.GetMouseButtonUp(0) && selectedFruit != null && currentLine != null && !isJoint) {
            Debug.Log("HOver fruit in up --- " + hoverFruit);
            if (hoverFruit != null) {
                Vector2 start = selectedFruit.transform.position;
                Vector2 end = hoverFruit.transform.position;

                if (!IsLineCrossing(start, end)) {
                    currentPoints.Add(end);
                    currentLine.positionCount = currentPoints.Count;
                    currentLine.SetPosition(currentPoints.Count - 1, end);

                    drawnLines.Add(new Vector2[] { start, end });
                }
                else {
                    Debug.Log("Here1");
                    UIManager.Instance.GeneratedLineRendere.Remove(currentLine);
                    Destroy(currentLine.gameObject);
                }
            }
            else {
                if (!UIManager.Instance.isWin) {
                    Debug.Log("Here2");
                    UIManager.Instance.GeneratedLineRendere.Remove(currentLine);
                    Destroy(currentLine.gameObject); // fallback if not hovering valid end
                }
            }

            // Reset all
            Destroy(currentLine.gameObject);
            selectedFruit = null;
            hoverFruit = null;
            currentLine = null;

        }
    }


    // Check if new line crosses any existing line
    private bool IsLineCrossing(Vector2 A, Vector2 B) {
        foreach (Vector2[] line in drawnLines) {
            if (DoLinesIntersect(A, B, line[0], line[1]))
                return true;
        }
        return false;
    }

    // Check if two line segments intersect
    *//*private bool DoLinesIntersect(Vector2 p1, Vector2 p2, Vector2 p3, Vector2 p4) {
        float d = (p4.y - p3.y) * (p2.x - p1.x) - (p4.x - p3.x) * (p2.y - p1.y);
        if (Mathf.Approximately(d, 0)) return false;

        float u = ((p4.x - p3.x) * (p1.y - p3.y) - (p4.y - p3.y) * (p1.x - p3.x)) / d;
        float v = ((p2.x - p1.x) * (p1.y - p3.y) - (p2.y - p1.y) * (p1.x - p3.x)) / d;

        return (u >= 0 && u <= 1) && (v >= 0 && v <= 1);
    }*//*

    bool DoLinesIntersect(Vector2 p1, Vector2 p2, Vector2 q1, Vector2 q2) {
        return (CCW(p1, q1, q2) != CCW(p2, q1, q2)) && (CCW(p1, p2, q1) != CCW(p1, p2, q2));
    }

    bool CCW(Vector2 a, Vector2 b, Vector2 c) {
        return (c.y - a.y) * (b.x - a.x) > (b.y - a.y) * (c.x - a.x);
    }

}
*/




using System.Collections.Generic;
using UnityEngine;

public class FruitConnector : MonoBehaviour
{
    public static FruitConnector Instance { get; private set; }

    public int winCount;
    public LineRenderer linePrefab;
    private LineRenderer currentLine;
    private List<Vector3> currentPoints = new List<Vector3>();
    private List<Vector2[]> drawnLines = new List<Vector2[]>(); // Stores all drawn lines

    public FruitController selectedFruit = null;
    public FruitController hoverFruit = null;
    public bool isJoint = false;

    public LineRendererCollision lineRenderercollision; // Make sure this script/class exists

    private void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        // Cancel current drag if crossing is detected
        if (selectedFruit != null && lineRenderercollision != null)
        {
            Debug.Log("Crossing Detected during Drag - Destroying Line");
            DestroyLine();
            return;
        }

        // On mouse down - select starting fruit
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            FruitController fc = Physics2D.OverlapPoint(mousePos)?.GetComponent<FruitController>();
            if (fc != null)
            {
                UIManager.Instance.isWin = false;
                selectedFruit = fc;
                currentLine = Instantiate(linePrefab);
                UIManager.Instance.GeneratedLineRendere.Add(currentLine);
                currentPoints.Clear();

                Vector3 startPos = selectedFruit.transform.position;
                currentPoints.Add(startPos);
                currentLine.positionCount = 1;
                currentLine.SetPosition(0, startPos);
                isJoint = false;
            }
        }

        // While dragging
        if (Input.GetMouseButton(0) && selectedFruit != null && currentLine != null)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0f;

            // Check if mousePos would cause a crossing
            Vector2 lastPoint = currentPoints[currentPoints.Count - 1];
            Vector2 newPoint = mousePos;

            if (Vector3.Distance(lastPoint, newPoint) > 0.1f)
            {
                if (!IsLineCrossing(lastPoint, newPoint))
                {
                    currentPoints.Add(mousePos);
                    currentLine.positionCount = currentPoints.Count;
                    currentLine.SetPosition(currentPoints.Count - 1, mousePos);
                }
                else
                {
                    // Line would cross existing one — do not extend further
                    Debug.Log("Crossing Detected - Stop Extending Line");
                    return;
                }
            }

            FruitController fc = Physics2D.OverlapPoint(mousePos)?.GetComponent<FruitController>();
            if (fc != null && fc != selectedFruit && fc.fruitType == selectedFruit.fruitType)
            {
                Vector2 start = selectedFruit.transform.position;
                Vector2 end = fc.transform.position;

                if (!IsLineCrossing(start, end))
                {
                    hoverFruit = fc;
                    selectedFruit.GetComponent<Collider2D>().enabled = false;
                    hoverFruit.GetComponent<Collider2D>().enabled = false;

                    currentPoints.Add(end);
                    currentLine.positionCount = currentPoints.Count;
                    currentLine.SetPosition(currentPoints.Count - 1, end);

                    drawnLines.Add(new Vector2[] { start, end });

                    Debug.Log("Connected: " + selectedFruit.name + " -> " + hoverFruit.name);
                    UIManager.Instance.OnJointFruit();
                    isJoint = true;
                    UIManager.Instance.isWin = true;
                }
                else
                {
                    Debug.Log("Connection would cross another line - Ignored");
                }
            }
        }


        // On mouse release
        if (Input.GetMouseButtonUp(0) && selectedFruit != null && currentLine != null)
        {
            if (!isJoint)
            {
                Debug.Log("Invalid Connection - Line Removed");
                DestroyLine();
            }
            ResetState();
        }
    }

    // Destroy current line and remove from list
    private void DestroyLine()
    {
        if (currentLine != null)
        {
            UIManager.Instance.GeneratedLineRendere.Remove(currentLine);
            Destroy(currentLine.gameObject);
        }
        ResetState();
    }

    // Reset fruit & line state
    private void ResetState()
    {
        selectedFruit = null;
        hoverFruit = null;
        currentLine = null;
    }

    // Check if new line intersects any existing line
    private bool IsLineCrossing(Vector2 A, Vector2 B)
    {
        foreach (Vector2[] line in drawnLines)
        {
            if (DoLinesIntersect(A, B, line[0], line[1]))
                return true;
        }
        return false;
    }

    private bool DoLinesIntersect(Vector2 p1, Vector2 p2, Vector2 q1, Vector2 q2)
    {
        return (CCW(p1, q1, q2) != CCW(p2, q1, q2)) &&
               (CCW(p1, p2, q1) != CCW(p1, p2, q2));
    }

    private bool CCW(Vector2 a, Vector2 b, Vector2 c)
    {
        return (c.y - a.y) * (b.x - a.x) > (b.y - a.y) * (c.x - a.x);
    }
}
