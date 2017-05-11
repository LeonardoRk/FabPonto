using FabPonto.DAL;

namespace FabPonto.Models
{
    public class ConcreteListIterator : AbstractListIterator
    {
        private const int INDEX_FIRST_ITEM = 0;
        private FabInitializer fab = new FabInitializer();


        public override object First()
        {

        }

        public override object Next()
        {
            throw new System.NotImplementedException();
        }

        public override bool IsDone()
        {
            throw new System.NotImplementedException();
        }

        public override object CurrentItem()
        {
            throw new System.NotImplementedException();
        }
    }
}