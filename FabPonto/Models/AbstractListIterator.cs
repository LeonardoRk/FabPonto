namespace FabPonto.Models
{
    public abstract class AbstractListIterator
    {
        public abstract object First();

        public abstract object Next();

        public abstract bool IsDone();

        public abstract object CurrentItem();
    }
}