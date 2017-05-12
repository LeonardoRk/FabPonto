using System;
using System.Linq;

namespace FabPonto.Models
{
    public class ConcreteIterator : IIterator
    {
        private IUser user = null;
        private const int FIRST_INDEX = 0;
        private int _index = 0;

        public void set_index(int index)
        {
            this._index = index;
        }

        public ConcreteIterator(IUser user)
        {
            this.user = user;
        }

        public Workday First()
        {
            Workday firstObject = this.user.Workdays.ElementAt(FIRST_INDEX);
            return firstObject;
        }

        public Workday Next()
        {
            Workday workday = null;

            if (_index < this.user.Workdays.Count - 1)
            {
                workday = this.user.Workdays.ElementAt(++_index);
            }
            return workday;
        }

        public bool HasNext()
        {
            return _index >= this.user.Workdays.Count;

        }

        public Workday CurrentItem()
        {
            Workday currentItem = this.user.Workdays.ElementAt(_index);
            return currentItem;
        }
    }
}