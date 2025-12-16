namespace FinalProject.Heroes;
using FinalProject;
public class AntiNephiLehite:Character
{
    public AntiNephiLehite(string name) : base(name)
    {
        ChangeStory("You have sworn off fighting and pursued other skills less violent.\nKnown as an excellent " +
                 "healer, you wish to provide your services to the rest of the world.");
        ChangeConstitution(6);
        ChangeIntelligence(2);
        ChangeWisdom(4);
        ChangeDexterity(4);
        ChangeMelee(-3);
        ChangeRanged(-3);
        ChangeClass(("Anti-Nephi-Lehite"));
    }
    public void HealAlly(Character ally)
    {
        ally.ChangeHealth(10);
    }
}
