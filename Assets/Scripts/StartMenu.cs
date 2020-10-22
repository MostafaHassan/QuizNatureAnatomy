using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour {

    public GameObject bone2DPrefab;

    public GameObject gameSettingsPanel;
    public GameObject gameSettingsBoneContent;
    public Color selectedBoneUIColor;
    public Color deselectedBoneUIColor;
    public Text sidePanelText;
    public Toggle playWithTime;
    public Toggle chooseAllBones;

    private void Start()
    {
        playWithTime.isOn = Globals.g_PlayWithTime;
        chooseAllBones.isOn = Globals.g_ChooseAllSkeletons;

    }
    public void ActivateGameSettings()
	{
		gameSettingsPanel.SetActive(true);
		sidePanelText.text = "Spelinställningar";

        // Remove old objects

        for (int i = 0; i < gameSettingsBoneContent.transform.childCount; i++)
        {
            Destroy(gameSettingsBoneContent.transform.GetChild(i).gameObject);
        }

        for (int i = 0; i < Globals.g_BodyStructure.Bodies.Count; i++)
        {
            Body currentBody = Globals.g_BodyStructure.Bodies[i];
            GameObject b = Instantiate(bone2DPrefab, gameSettingsBoneContent.transform);
            b.GetComponentInChildren<Text>().text = currentBody.BodyName;
            b.transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("BenUI/"+currentBody.BodyName);
            b.transform.GetChild(0).GetComponent<Button>().onClick.AddListener(() => ToggleUIBoneSelection(b));
        }

        gameSettingsPanel.transform.parent.GetComponent<Animator>().Play("ActivateSidePanelMenu");
    }

	public void DeActivateGameSettings()
	{
        gameSettingsPanel.transform.parent.GetComponent<Animator>().Play("DeactivateSidePanelMenu");
        //gameSettingsPanel.SetActive(false);
	}

    public void ToggleUIBoneSelection(GameObject boneUI)
    {
        Image btnImage = boneUI.transform.GetComponent<Image>();

        // Deselect
        if (btnImage.color == selectedBoneUIColor)
        {
            btnImage.color = deselectedBoneUIColor;
        }
        // Select
        else
        {
            btnImage.color = selectedBoneUIColor;
        }
    }

    public void GO()
    {
        Globals.g_PlayWithTime = playWithTime.isOn;
        Globals.g_ChooseAllSkeletons = chooseAllBones.isOn;

        Globals.g_BodiesSelected = new List<string>();
        // Get selected boneUIS
        for (int i = 0; i < gameSettingsBoneContent.transform.childCount; i++)
        {
            GameObject goWithImage = gameSettingsBoneContent.transform.GetChild(i).gameObject;
            Image btnImage = goWithImage.GetComponent<Image>();
            if (btnImage.color == selectedBoneUIColor)
            {   
                Globals.g_BodiesSelected.Add(goWithImage.GetComponentInChildren<Text>().text);
                //print("WORKED: " + Globals.g_BodiesSelected[0]);
            }
        }

        SceneManager.LoadScene("Game");
	}
	
	// Update is called once per frame
	void Update () {
	}
}
