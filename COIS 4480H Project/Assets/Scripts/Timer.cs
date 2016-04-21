using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour
{
    private const float MAX_TIME = 60f;
    public static float timer;
    public static bool timeStarted;
    private int maxAI;
    private GameObject[] aiList;
    private GameObject player;
    private bool linedUp;
    private bool winner;
    private bool selected;
    private bool reset = true;

    // Use this for initialization
    void Start()
    {
        timer = MAX_TIME;
        maxAI = 0;
        aiList = new GameObject[maxAI];

        player = Instantiate(Resources.Load("Player", typeof(GameObject))) as GameObject;

        for (int i = 0; i < maxAI; i++)
            aiList[i] = Instantiate(Resources.Load("AI", typeof(GameObject))) as GameObject;

        Reset();
    }

    // Update is called once per frame
    void Update()
    {
        if (timeStarted == true)
        {
            timer -= Time.deltaTime;
        }
        else if (linedUp && Input.GetMouseButtonDown(0))
        {
            Ray ray = gameObject.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit) && hit.transform.gameObject == player.gameObject)
                winner = true;
            selected = true;
        }
    }

    void OnGUI()
    {
        GUIStyle myStyle = new GUIStyle();
        myStyle.fontSize = 50;

        if (!linedUp)
        {
            int minutes = Mathf.FloorToInt(timer / 60F);
            int seconds = Mathf.FloorToInt(timer - minutes * 60);
            string niceTime = string.Format("{0:0}:{1:00}", minutes, seconds);

            if (timer > 11)
                myStyle.normal.textColor = Color.yellow;
            else if (timer <= 0)
            {
                GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 50, 200, 100), "Time's up!", myStyle);
                if (timeStarted)
                {
                    timeStarted = false;
                    Invoke("LineupCharacters", 1);
                }
            }
            else
                myStyle.normal.textColor = Color.red;

            if (timeStarted)
            {
                GUI.Label(new Rect(Screen.width / 2 - 50, 10, 100, 100), niceTime, myStyle);
            }
        }
        else if (selected)
        {
            if (winner)
            {
                myStyle.normal.textColor = Color.green;
                GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 50, 200, 100), "You won!", myStyle);
            }
            else
            {
                myStyle.normal.textColor = Color.red;
                GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 50, 200, 100), "You lost!", myStyle);
            }
            if (reset)
            {
                reset = false;
                Invoke("Reset", 2);
            }
        }
    }

    void LineupCharacters()
    {
        int currAI = 0;
        int playerPos = (int)(Random.value * (maxAI + 1));
        float currZ = -2f;
        linedUp = true;

        for (int i = 0; i < 3; i++)
        {
            float currX = -2.625f;
            for (int j = 0; j < 8; j++)
            {
                if (i * 8 + j == playerPos)
                {
                    player.transform.position = new Vector3(currX, 0.3047705f, currZ);
                    player.transform.rotation = Quaternion.identity;
                }
                else
                {
                    aiList[currAI].gameObject.GetComponent<NavMeshAgent>().enabled = false;
                    aiList[currAI].gameObject.transform.rotation = Quaternion.identity;
                    aiList[currAI].transform.position = new Vector3(currX, 0.3047705f, currZ);
                    currAI++;
                }
                currX += 0.75f;
            }
            currZ += 2f;
        }

    }

    void Reset()
    {
        linedUp = false;
        winner = false;
        timer = MAX_TIME;
        selected = false;
        reset = true;

        Color[] colors = { Color.blue, Color.cyan, Color.gray, Color.green, Color.magenta, Color.red, Color.white, Color.yellow };
        Color currColor;
        Renderer[] renderers;

        player.gameObject.transform.position = new Vector3(Random.value * 8f - 4f, 0.5161383f, Random.value * 8f - 4f);
        renderers = player.gameObject.GetComponentsInChildren<Renderer>();

        for (int i = 0; i < renderers.Length; i++)
        {
            currColor = colors[(int)(Random.value * colors.Length)];
            renderers[i].material.color = currColor;
        }

        for (int i = 0; i < aiList.Length; i++)
        {
            NavMeshHit hit;
            NavMesh.SamplePosition(new Vector3(Random.value * 8f - 4f, 0f, Random.value * 8f - 4f), out hit, 1.0f, NavMesh.AllAreas);
            aiList[i].gameObject.transform.position = hit.position;
            renderers = aiList[i].gameObject.GetComponentsInChildren<Renderer>();
            aiList[i].gameObject.GetComponent<NavMeshAgent>().enabled = true;

            for (int j = 0; j < renderers.Length; j++)
            {
                currColor = colors[(int)(Random.value * colors.Length)];
                renderers[j].material.color = currColor;
            }
        }

        timeStarted = true;
    }
}