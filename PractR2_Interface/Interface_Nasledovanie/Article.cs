namespace Interface_Nasledovanie;

public enum Frequence
{
    Weekly,
    Monthly,
    Yearly
}

public class Article : IRateAndCopy
{
    private Person author { get; set; }
    public string nameArticle { get; set; }
    public double rating { get; set; }

    public Article(Person author, string nameArticle, double rating)
    {
        this.author = author;
        this.nameArticle = nameArticle;
        this.rating = rating;
    }
    public Article()
    {
        author = new Person();
        nameArticle = "none";
        rating = 0;
    }

    public override string ToString() =>$"Автор: {author.ToString()}\nСтатья: {nameArticle} Рейтинг: {rating}";
    public virtual object DeepCopy() => new Article(this.author, this.nameArticle, this.rating);


}