namespace Interface_Nasledovanie;

public class Person
{
    private string name;
    private string surName;
    private DateTime birthday = new DateTime(2004, 01, 26);

    public Person(string name, string surName, DateTime birthday)
    {
        this.name = name;
        this.surName = surName;
        this.birthday = birthday;
    }

    public Person()
    {
        name = "none";
        surName = "none";
        birthday = new DateTime(0001, 01, 01);
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }
    public string SurName
    {
        get { return surName; }
        set { surName = value; }
    }
    public DateTime Birthday
    {
        get { return birthday; }
        set { birthday = value; }
    }
    public int Year
    {
        get { return birthday.Year; }
        set
        {
            int month = birthday.Month;
            int day = birthday.Day;
            birthday = new DateTime(value, month, day);
        }
    }

    public override string ToString() => $"Имя: {this.name} Фамилия: {this.surName} День Рождения: {birthday.ToShortDateString()}";
    public virtual string ToShortString() => $"Имя: {this.name} Фамилия: {this.surName}";
    public override bool Equals(object? obj)
    {
        if (obj.GetType() != this.GetType()) return false;
        Person per = (Person)obj;
        return (name == per.name && surName == per.surName && birthday == per.birthday) ? true : false;
    }

    static public bool operator ==(Person p1, Person p2) =>(p1.name == p2.name && p1.surName == p2.surName && p1.birthday == p2.birthday) ? true : false;

    static public bool operator !=(Person p1, Person p2) =>(p1.name != p2.name && p1.surName != p2.surName && p1.birthday != p2.birthday) ? true : false;
    public override int GetHashCode() => HashCode.Combine(name, surName, birthday);
    public virtual object DeepCopy() => new Person(this.name, this.surName, this.birthday);
}