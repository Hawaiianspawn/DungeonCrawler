using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartySystem : MonoBehaviour {
    public List<CharacterStats> PartyMembers;
    public List<CharacterStats> Tanks;
    public List<CharacterStats> DPS;
    public List<CharacterStats> Ranged;
    public List<CharacterStats> Healers;
    public List<Enemy> PriorityList;



    //Get all party members and their roles. 
    void Start () {
        foreach (Transform Child in this.transform.parent.transform)
        {
            CharacterStats Character = Child.GetComponent<CharacterStats>();
            if (Character)
            {
                PartyMembers.Add(Child.GetComponent<CharacterStats>());
               //
            }
        }
     //   Debug.Log(PartyMembers);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
