using System;
using System.Linq;

namespace FabPonto.Models
{
    public class ConcreteIterator : IIterator
    {
        private IUser user = null;
        private const int FIRST_INDEX = 0;
        private int index = 0;

        public ConcreteIterator(IUser user)
        {
            this.user = user;
        }

        public object First()
        {
            object firstObject = this.user.Workdays.ElementAt(FIRST_INDEX);
            return firstObject;
        }

        public object Next()
        {
            int nextIndex = index++;

            object nextOBject = this.user.Workdays.ElementAt(nextIndex);
            return nextOBject;
        }

        public bool HasNext()
        {
            Boolean hasNext = false;

            if (index <= this.user.Workdays.Count)
            {
                hasNext = true;
            }
            else
            {
                //nothing to do
            }

            return hasNext;
        }

        public object CurrentItem()
        {
            object currentItem = this.user.Workdays.ElementAt(index);
            return currentItem;
        }
    }
}