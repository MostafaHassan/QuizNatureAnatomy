using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Body structure has list of bodies
 *  and each body has a list of bones
 */

[System.Serializable]
public class BodyStructure  {
	[SerializeField] public List<Body> Bodies;
	public BodyStructure()
	{
		Bodies = new List<Body>();
        
	}

    public string PrintInfo()
    {
        string output = "";
        for(int i = 0; i < Bodies.Count; i++)
        {
            output += Bodies[i].PrintInfo();
        }

        return output;
    }
}

[System.Serializable]
public class Body  {
	[SerializeField] public string BodyName;
	[SerializeField] public string BodyDescription;
	[SerializeField] public List<Bone> BodyBones;

	public Body(string BodyName, string BodyDescription)
	{
		this.BodyName = BodyName;
		this.BodyDescription = BodyDescription;
		this.BodyBones = new List<Bone>();
	}

    public string PrintInfo()
    {
        string output = "BodyName: " + this.BodyName +
            "BodyDescription: " + this.BodyDescription + "\n";
        for (int i = 0; i < BodyBones.Count; i++)
        {
            output += "\tBodyBones: " + this.BodyBones[i].PrintInfo() + "\n";
        }

        return output;
    }
}
