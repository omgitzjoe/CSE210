namespace Characters;

public class Reformed_Robber : Character
{ 

    public Reformed_Robber(string name) : base(name)
    {
		_story=("A former Gadianton Robber, you have renounced those "+
		        "old ways in favor of a simple pleasant life. \nFinding a lack "+ 
                "of clarity, you set out to find purpose and adventure.");
        ChangeDexterity(8);
        ChangeCharisma(-2);
        ChangeRanged(4);
        ChangeConstitution(-1);
        ChangeWisdom(-2);
        ChangeIntelligence(2);
        ChangeStrength(-1);
        ChangeMelee(2);
        ChangeClass("Robber");
    }

}
