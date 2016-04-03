using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {

    public static float timer;
    public static bool timeStarted = false;

    // Use this for initialization
    void Start () {
        timer = 120;
        timeStarted = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (timeStarted == true)
        {
            timer -= Time.deltaTime;
        }
    }

    void OnGUI()
    {
        int minutes = Mathf.FloorToInt(timer / 60F);
        int seconds = Mathf.FloorToInt(timer - minutes * 60);
        string niceTime = string.Format("{0:0}:{1:00}", minutes, seconds);

        GUIStyle myStyle = new GUIStyle();
        myStyle.fontSize = 50;
        if(seconds > 10)
            myStyle.normal.textColor = Color.yellow;
        else
            myStyle.normal.textColor = Color.red;
        GUI.Label(new Rect(Screen.width/2 - 50, 10, 100, 100), niceTime, myStyle);
    }
}
