using UnityEngine;
using System.Collections;

public class FallInChecker : MonoBehaviour {

    public Hole red;
    public Hole blue;
    public Hole green;

    void OnGUI()
    {
        string label = " ";
        GUI.Label(new Rect(0, 0, 100, 30), " ");
        GUI.Label(new Rect(0, 30, 100, 30), " ");
        GUI.Label(new Rect(0, 60, 100, 30), " ");
        GUI.Label(new Rect(0, 90, 100, 30), " ");

        if (red.IsFallIn())
        {
            GUI.Label(new Rect(0, 30, 100, 30), "RED  :TRUE");
        } else {
            GUI.Label(new Rect(0, 30, 100, 30), "RED  :FALSE");
        }

        if (blue.IsFallIn())
        {
            GUI.Label(new Rect(0, 60, 100, 30), "BLUE :TRUE");
        } else {
            GUI.Label(new Rect(0, 60, 100, 30), "BLUE :FALSE");
        }

        if (green.IsFallIn())
        {
            GUI.Label(new Rect(0, 90, 100, 30), "GREEN:TRUE");
        } else {
            GUI.Label(new Rect(0, 90, 100, 30), "GREEN:FALSE");
        }

        //すべてのボールが入ったらラベルを表示
        if (red.IsFallIn() && blue.IsFallIn() && green.IsFallIn())
        {
            label = "Fall in hole!";
        }
        GUI.Label (new Rect(0,0,100,30), label);
    }

}
