using System.Collections;
using System.Collections.Generic;
using UnityEngine;





//Reference: WHICH IS OUT OF DATE: I Don't have new data so this will do
//https://wow.gamepedia.com/Base_attributes 

[ExecuteInEditMode]

public class CharacterStats : Character {
  
    public RoleType Role;
    private RoleType PreviousRole; //Used for only validation
   
    [Range(0,15)] public int BaseStamina = 10;     //Base Modifier for final Health
    [Range(0, 17)] public int BaseStrength = 10;   //Modifier for final Physical attack
    [Range(0, 15)] public int BaseAgility = 10;    //Modifier for final physical attack
    [Range(0, 15)] public int BaseIntellect = 10;  //Modifer for final Spell damage and mana


    //Scrapped for now
    public int Armor;           //Based Stats that will provide a percentage reduction if physical
    public int Dodge;           //Percentage miss
    public int Crit;            //Percentage to crit  
    public int Mastery;         //Modifer for range
    public int Haste;           //Attack speed
    public int Speed;           //Move speed


    //Anything that changes the Component will be shown here
    private void OnValidate()
    {
        //Change Role stats auto fill
        if (PreviousRole != Role)
        {
            PreviousRole = Role;
            //Role Presets, Thsese are based on Warrior, DK , Hunter, Resto Druid
            switch (Role)
            {
                case RoleType.Tank:
                    {

                        BaseStamina = 11;
                        BaseStrength = 14;
                        BaseAgility = 10;
                        BaseIntellect = 8;
                        AttackRange = 1;
                        break;
                    }
                case RoleType.DPSMelee:
                    {
                        BaseStamina = 7;
                        BaseStrength = 17;
                        BaseAgility = 13;
                        BaseIntellect = 7;
                        AttackRange = 1;
                        break;
                    }
                case RoleType.DPSRanged:
                    {
                        BaseStamina = 6;
                        BaseStrength = 10;
                        BaseAgility = 15;
                        BaseIntellect = 10;
                        AttackRange = 5;
                        break;
                    }
                case RoleType.Healer:
                    {
                        BaseStamina = 7;
                        BaseStrength = 8;
                        BaseAgility = 10;
                        BaseIntellect = 12;
                        AttackRange = 4; 
                        break;
                    }
            }
        }

    }


    void Start () {

    }
    public void Update()
    {

    }

    
    public void RecalculateStats()
    {
        //Calculate Stamina: Affects HP 
        Stamina = 0;
  
    }
}
