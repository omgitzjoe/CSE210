namespace FinalProject.Heroes;
using FinalProject;
public class Nephite:Character
{

    public Nephite(string name) : base(name)
    {
        ChangeStory("Born of goodly parents, adventure has called to you from a young age.\nYou" +
                 " believed you were at an age where the pursuit of adventure was most appropriate.\n" +
                 "You wished your family well and departed.");
        ChangeIntelligence(2);
        ChangeWisdom(2);
        ChangeCharisma(2);
        ChangeDexterity(2);
        ChangeConstitution(1);
        ChangeStrength(1);
        ChangeClass("Nephite");
    }
}
