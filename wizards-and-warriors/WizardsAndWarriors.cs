using System;

abstract class Character
{
    string characterType;
    protected Character(string characterType)
    {
        this.characterType=characterType;
    }

    public abstract int DamagePoints(Character target);

    public virtual bool Vulnerable()
    {
        return false;
    }

    public override string ToString()
    {
        return $"Character is a {characterType}";
    }
}

class Warrior : Character
{
    public Warrior() : base("Warrior")
    {
    }

    public override int DamagePoints(Character target)
    {
        if(target.Vulnerable())
            return 10;
        else
            return 6;
    }

    public static void Main(){
        Warrior warrior=new Warrior();
        Wizard wizard=new Wizard();
        Console.WriteLine($"vuln: {wizard.Vulnerable()}");
        Console.WriteLine($"dam: {warrior.DamagePoints(wizard)}");

    }
}

class Wizard : Character
{
    bool spellPrepared=false;
    public Wizard() : base("Wizard")
    {
    }

    public override int DamagePoints(Character target)
    {
        if(spellPrepared)
            return 12;
        else 
            return 3;
    }

    public void PrepareSpell()
    {
        spellPrepared=true;
    }

    public override bool Vulnerable()
    {
        return !spellPrepared;
    }

}
