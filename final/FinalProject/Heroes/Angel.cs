namespace FinalProject.Heroes;
using FinalProject;
public class Angel : Character
{
    public Angel(string name) : base(name)
    {
        ChangeConstitution(-2);
        ChangeWisdom(10);
        ChangeIntelligence(10);
        ChangeStrength(-2);
        ChangeDexterity(-2);
        ChangeRanged(-2);
        ChangeMelee(-2);
        ChangeClass("Angel");
    }
    
    public void HealAlly(Character ally)
    {
        ally.ChangeHealth(20);
    }
}
