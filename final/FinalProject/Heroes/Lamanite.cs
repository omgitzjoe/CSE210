namespace Characters;

public class Lamanite:Character
{
    public Lamanite(string name) : base(name)
    {
        _story = "A strong member of your tribe, you sought to do the right thing, \nthough " +
                 "it wasn't always easy given your family's traditions.\nOne day you set out and " +
                 "never looked back";
        ChangeStrength(6);
        ChangeConstitution(2);
        ChangeMelee(4);
        ChangeIntelligence(-1);
        ChangeWisdom(-1);
        ChangeClass("Lamanite");
    }
}
