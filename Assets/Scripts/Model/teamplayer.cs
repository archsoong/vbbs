using System.Collections;
using UnityEngine;


public class teamplayer : MonoBehaviour {

    const float Y1_RATIO = 1191.0f / 1920.0f;
    const float Y2_RATIO = 1761.0f / 1920.0f;

    public ModelController model;
    public MainController controller;

    public GameObject line;
    public GameObject drawLine = null;
    public ArrayList positions = new ArrayList();

    void Update()
    {
        if (controller.getState() != 3)
            return;

        if (Input.GetButtonDown("Fire1"))
        {
            Vector3 click = Input.mousePosition;

            /*
            Debug.Log("SW " + Screen.width);
            Debug.Log("SH " + Screen.height);
            Debug.Log("Y1 " + Y1_RATIO);
            Debug.Log("Y2 " + Y2_RATIO);
            Debug.Log("SH Y1 " + Screen.height * Y1_RATIO);
            Debug.Log("SH Y2 " + Screen.height * Y2_RATIO);
            Debug.Log("Click x" + click.x);
            Debug.Log("Click y" + click.y);
            */

            if (click.x > 0 && click.x < Screen.width && click.y > Screen.height * Y1_RATIO && click.y < Screen.height * Y2_RATIO)
            {
                
            }
            else { return;  }

            Vector3 point = Camera.main.ScreenToWorldPoint(click);

            Debug.Log(click.x + " " + click.y);
            Debug.Log(point.x + " " + point.y);

            if (positions.Count == 0 && drawLine == null)
            {
                drawLine = Instantiate(line, new Vector3(0, 0, 0), Quaternion.identity);
                LineRenderer ll = drawLine.GetComponent<LineRenderer>();
                Vector3 p = new Vector3(point.x, point.y, -1);
                ll.SetPosition(positions.Count, p);
                ll.SetPosition(positions.Count + 1, p);
                positions.Add(point);

                model.start_X = point.x;
                model.start_Y = point.y;

                if (point.x < 0)
                {
                    model.attacker = 1;
                }
                else
                {
                    model.attacker = 2;
                }
            }
            else if (positions.Count == 1 && drawLine != null)
            {
                LineRenderer ll = drawLine.GetComponent<LineRenderer>();
                Vector3 p = new Vector3(point.x, point.y, -1);
                model.end_X = point.x;
                model.end_Y = point.y;
                ll.SetPosition(positions.Count, p);
                positions.Add(point);
            }
            else if (positions.Count == 2 && drawLine != null)
            {
                clearDrawLine();
                drawLine = Instantiate(line, new Vector3(0, 0, 0), Quaternion.identity);
                LineRenderer ll = drawLine.GetComponent<LineRenderer>();
                Vector3 p = new Vector3(point.x, point.y, -1);
                ll.SetPosition(positions.Count, p);
                ll.SetPosition(positions.Count + 1, p);
                positions.Add(point);

                model.start_X = point.x;
                model.start_Y = point.y;

                if (point.x < 0)
                {
                    model.attacker = 1;
                }
                else
                {
                    model.attacker = 2;
                }
            }
        }
    }

    public void clearDrawLine()
    {
        Destroy(drawLine);
        drawLine = null;
        positions.Clear();
        model.start_X = 0.0f;
        model.start_Y = 0.0f;
        model.end_X = 0.0f;
        model.end_Y = 0.0f;
    }
}

