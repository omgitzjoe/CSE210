namespace FinalProject.Heroes;
using FinalProject;
public class Israelite:Character
{
    public Israelite(string name) : base(name)
    {
        ChangeStory("You followed every law, did all the right things, but were always shorted in life.\n" +
                 "Now it's time to do unto the world what it has done unto you");
        ChangeDexterity(2);
        ChangeWisdom(2); 
        ChangeIntelligence(2);
        ChangeConstitution(-1);
        ChangeStrength(1);
        ChangeRanged(4);
        ChangeClass("Israelite");
    }
}
