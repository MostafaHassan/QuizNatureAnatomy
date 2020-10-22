using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Bone  {
	[SerializeField] public string BoneName = "None";
	[SerializeField] public string BoneDescription = "None";

	public Bone(string BoneName, string BoneDescription)
	{
		this.BoneName = BoneName;
		this.BoneDescription = BoneDescription;
	}

    public string PrintInfo()
    {
        return "BoneName: " + this.BoneName +
            "BoneDescription: " + this.BoneDescription + "\n";
    }
}
