using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BendyLine : MonoBehaviour {

    public Vector2 POS { get { return transform.position; } set { transform.position = value; } }

    public float hangamount = 3f;
    public float movespeed = 1f;
    public float velocitylerp = 0.025f;
    public float drag = 0.025f;

    public Vector2 START { get { return start; } set { start = value; } }
    public Vector2 MID { get { return mid; } }
    public Vector2 END { get { return end; } set { end = value; } }

    Vector2 start;
    Vector2 end;
    Vector2 mid, midvel;

    public LineRenderer REN { get { return ren; } }
    LineRenderer ren;

    void Start ( ) {
        ren = GetComponent<LineRenderer> ( );
        ren.useWorldSpace = true;
        mid = transform.position;
    }

    public void UpdateLine (Vector2 start, Vector2 end) {

        this.start = start;
        this.end = end;

        Vector2 targetmid = Vector2.Lerp (start, end, .7f) + Vector2.down * hangamount;
        midvel = Vector2.Lerp (midvel, targetmid - mid, velocitylerp);

        mid += midvel * movespeed;
        midvel *= 1f - drag;

        Vector2 a = start;
        Vector2 b = mid;
        Vector2 c = end;

        float step = 1f / ((float) ren.positionCount - 1f);
        for (int i = 0; i < ren.positionCount; i++) {
            float f = step * i;
            Vector2 p = Vector2.Lerp (
                Vector2.Lerp (a, b, f),
                Vector2.Lerp (b, c, f),
                f);
            ren.SetPosition (i, p);
        }
    }
}