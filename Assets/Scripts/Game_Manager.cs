using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum GameMode
{
	Time,
	NoTime
}

public class Game_Manager : MonoBehaviour {
    public Text timeText;
	public GameMode gameMode;
	public bool allSkeletons;

	public int round;
    float timer = 10;
	
	// Use this for initialization
	void Start () {
        gameMode = Globals.g_PlayWithTime == true ? GameMode.Time : GameMode.NoTime;
        allSkeletons = Globals.g_ChooseAllSkeletons;
        
        if (Globals.g_BodiesSelected.Count > 0)
        {
            GameObject obj = Instantiate(Resources.Load<GameObject>("Skeletons/" + Globals.g_BodiesSelected[0]));
            Camera.main.transform.GetComponent<OrbitCamera>().target = obj;
        }
        else
            Debug.Log("Selected skeletons is 0");
    }
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Escape))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
        }

        timer -= Time.deltaTime;

        if (Globals.g_PlayWithTime)
            timeText.text = "Tid kvar: " + ((int)timer).ToString();
        else
            timeText.text = "";
    }
}
