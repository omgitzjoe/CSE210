namespace FinalProject;

public class Checks
{
    private static readonly Random Die = new Random();

    private static int RollDie(int sides)
    {
        return Die.Next(1, sides + 1);
    }
    
    //check attributes
    //strength
    public static bool StrengthCheck(Character character)
    {
        if (!(character.GetStrength() + RollDie(20) > 20))
        {
            return false;
        }
        
        return true;
    }
    
    //wisdom
    public static bool WisdomCheck(Character character)
    {
        if (!(character.GetWisdom() + RollDie(20) > 20))
        {
            return false;
        }
        
        return true;
    }
    
    //intelligence
    public static bool IntelligenceCheck(Character character)
    {
        if (!(character.GetIntelligence() + RollDie(20) > 20))
        {
            return false;
        }
        
        return true;
    }
    
    //constitution
    public static bool ConstitutionCheck(Character character)
    {
        if (!(character.GetConstitution() + RollDie(20) > 20))
        {
            return false;
        }
        
        return true;
    }
    
    //charisma
    public static bool CharismaCheck(Character character)
    {
        if (!(character.GetCharisma() + RollDie(20) > 20))
        {
            return false;
        }
        
        return true;
    }
}