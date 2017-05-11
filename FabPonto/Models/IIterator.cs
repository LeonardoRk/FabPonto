namespace FabPonto.Models
{
    public interface IIterator
    {

        object First();

        object Next();

        bool HasNext();

        object CurrentItem();
    }
}