namespace DudeDemo
{
    using System.Collections.Generic;

    public class Thing
    {
        private List<int[]> theList;

        public Thing()
        {
            this.theList = new List<int[]>(16);
        }

        public List<int[]> GetItems()
        {
            var x = new List<int[]>();
            foreach (var item in this.theList)
            {
                if (item[2] == 1)
                {
                    x.Add(item);
                }
            }

            return x;
        }
    }
}