using System.Collections;
namespace Pract2;

public class Magazine : Edition
{
    private string nameMagazine;
    private Frequence infoDate;
    private DateTime date;
    private Edition edition;
    private List<Person> moderators;
    private List<Article> articles;



    public Magazine(string nameEdition, DateTime release, int tier, string nameMagazine, Frequence infoDate, DateTime date, Edition edition, List<Person> moderators, List<Article> articles) : base(nameEdition, release, tier)
    {
        this.nameMagazine = nameMagazine;
        this.infoDate = infoDate;
        this.date = date;
        this.edition = edition;
        this.moderators = moderators;
        this.articles = articles;
    }

    public List<Person> Moderators
    {
        get => moderators;
        set => moderators = value;
    }

    public Magazine()
    {
        this.nameMagazine = "none";
        this.infoDate = Frequence.Monthly;
        this.date = new DateTime(0001, 01, 01);
    }

    public string NameMagazine
    {
        get { return nameMagazine; }
        set { this.nameMagazine = value; }
    }
    public Frequence InfoDate
    {
        get { return this.infoDate; }
        set { this.infoDate = value; }
    }
    public DateTime Date
    {
        get { return date; }
        set { this.date = value; }
    }

    public Edition Edition
    {
        get { return this.edition; }
        set { this.edition = value; }
    }

    public List<Article> Articles
    {
        get { return this.articles; }
        set { this.articles = value; }
    }
    public double AverageRating
    {
        get
        {
            double sum = 0;
            if (articles != null)
            {
                for (int i = 0; i < articles.Count; i++)
                {
                    sum += articles[i].rating;
                }
                return sum / articles.Count;

            }
            return 0;
        }
    }

    public bool this[Frequence n]
    {
        get
        {
            if (infoDate == n)
                return true;
            return false;
        }
    }

    public IEnumerable IteratorRating(double x)
    {
        if (articles != null)
        {
            for (int i = 0; i < articles.Count; i++)
            {
                if (articles[i].rating > x)
                    yield return articles[i];
            }
        }
    }

    public IEnumerable IteratorString(string x)
    {
        if (articles != null)
        {
            foreach (var VARIABLE in articles)
            {
                if (VARIABLE.nameArticle.Contains(x))
                {
                    yield return VARIABLE;
                }
            }
        }
    }

    public void AddArticles(params Article[] art)
    {
        articles.AddRange(art);
    }

    public void AddEditors(params Person[] editors)
    {
        moderators.AddRange(editors);
    }

    public object DeepCopy() => new Magazine(this.nameEdition, this.release, this.tier, this.nameMagazine, this.infoDate, this.date, this.edition, this.moderators, this.articles);

    public override string ToString() =>
        $"Название магазина: {nameMagazine}\nПреодичность выхода: {infoDate}\nДата выхода: {date.ToShortDateString()}\nВыпуск: {edition}\nСписок статей:\n {string.Join<Article>("\n", articles)}\n Список редакторов: {string.Join<Person>("\n", moderators)}";
    public virtual string ToShortString() =>
       $"Название магазина: {nameMagazine}\nПреодичность выхода: {infoDate}\nДата выхода: {date.ToShortDateString()}\nВыпуск: {edition}\n{AverageRating}";

}
