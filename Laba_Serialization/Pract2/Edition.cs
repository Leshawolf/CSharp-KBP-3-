namespace Pract2;
[Serializable]
public class Edition
{

    protected string nameEdition;
    protected DateTime release;
    protected int tier;

    public Edition()
    {
    }
    
    public Edition(string nameEdition, DateTime release, int tier)
    {
        this.nameEdition = nameEdition;
        this.release = release;
        this.tier = tier;
    }


    public string NameEdition
    {
        get => nameEdition;
        set => nameEdition = value;
    }

    public DateTime Release
    {
        get => release;
        set => release = value;
    }

    public int Tier
    {
        get => tier;
        set => tier = (value >= 0) ? value : throw new ArgumentException($"Invalid argument: {value}\nArgument must be positive");
    }
    public override bool Equals(object? obj)
    {
        if (obj.GetType() != this.GetType()) return false;
        Edition ed = (Edition)obj;
        return (nameEdition == ed.nameEdition && release == ed.release && tier == ed.tier);
    }
    static public bool operator ==(Edition p1, Edition p2) =>(p1.nameEdition == p2.nameEdition && p1.release == p2.release && p1.tier == p2.tier) ? true : false;

    static public bool operator !=(Edition p1, Edition p2) =>(p1.nameEdition != p2.nameEdition && p1.release != p2.release && p1.tier != p2.tier) ? true : false;
    public override int GetHashCode() => HashCode.Combine(nameEdition, release, tier);
    public override string ToString() =>$"Название: {nameEdition}\nДата выхода: {release}\nТираж: {tier}";

}