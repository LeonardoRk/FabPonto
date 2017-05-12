namespace FabPonto.Models
{
    public interface IIterator
    {

        Workday First();

        Workday Next();

        bool HasNext();

        Workday CurrentItem();
    }
}