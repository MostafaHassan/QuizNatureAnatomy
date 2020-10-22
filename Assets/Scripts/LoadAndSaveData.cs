using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LoadAndSaveData : MonoBehaviour {

    private string path;
    private string filePath;
    private string fileName = "Skelett.json";
	// Use this for initialization
	void Start () {
        path = Application.streamingAssetsPath;//Application.persistentDataPath;
        filePath = Path.Combine(path, fileName);
        
        Globals.g_BodyStructure = LoadBodyStructureFromFile(filePath);
        if (Globals.g_BodyStructure == null)
            print("Failed to load data from file");
        print(Globals.g_BodyStructure.Bodies.Count);

        Debug.Log(Globals.g_BodyStructure.PrintInfo());
        
        
        /*
        // Example create body
        Globals.g_BodyStructure = new BodyStructure();
        Body body = new Body("Knäled", "Detta skelett är blablabla");
        body.BodyBones.Add(new Bone("Inre menisk", "Detta ben är blablabla"));
        body.BodyBones.Add(new Bone("knäled", "Detta ben är blablabla"));
        body.BodyBones.Add(new Bone("Knäskål", "Detta ben är blablabla"));
        body.BodyBones.Add(new Bone("Knäskålsband", "Detta ben är blablabla"));
        body.BodyBones.Add(new Bone("Korsband", "Detta ben är blablabla"));
        body.BodyBones.Add(new Bone("Lårben", "Detta ben är blablabla"));
        body.BodyBones.Add(new Bone("Quadricepssena", "Detta ben är blablabla"));
        body.BodyBones.Add(new Bone("Skenben", "Detta ben är blablabla"));
        body.BodyBones.Add(new Bone("Vadben", "Detta ben är blablabla"));
        body.BodyBones.Add(new Bone("Yttre ledband", "Detta ben är blablabla"));
        body.BodyBones.Add(new Bone("Yttre menisk", "Detta ben är blablabla"));
        Globals.g_BodyStructure.Bodies.Add(body);

        
        Body body2 = new Body("Disk 1", "Detta skelett är blablabla");
        body2.BodyBones.Add(new Bone("Disk 1", "Detta ben är blablabla"));
        Globals.g_BodyStructure.Bodies.Add(body2);

        Body body3 = new Body("Kota 1", "Detta skelett är blablabla");
        body3.BodyBones.Add(new Bone("Kota 1", "Detta ben är blablabla"));
        Globals.g_BodyStructure.Bodies.Add(body3);

        Body body4 = new Body("Kota 2", "Detta skelett är blablabla");
        body4.BodyBones.Add(new Bone("Kota 2", "Detta ben är blablabla"));
        Globals.g_BodyStructure.Bodies.Add(body4);

        Body body5 = new Body("Nerv", "Detta skelett är blablabla");
        body5.BodyBones.Add(new Bone("Nerv", "Detta ben är blablabla"));
        Globals.g_BodyStructure.Bodies.Add(body5);
        Save_g_BodyStructureToFile();
        */
        
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void Save_g_BodyStructureToFile()
    {
        string json_bodyStructure = JsonUtility.ToJson(Globals.g_BodyStructure, true);
        StreamWriter streamWriter = new StreamWriter(filePath);
        streamWriter.Write(json_bodyStructure);
        streamWriter.Close();
    }

    public BodyStructure LoadBodyStructureFromFile(string _path)
    {
        StreamReader streamReader = new StreamReader(filePath);
        string json_bodyStructure = streamReader.ReadToEnd();
        streamReader.Close();

        return JsonUtility.FromJson<BodyStructure>(json_bodyStructure);
    }
}
