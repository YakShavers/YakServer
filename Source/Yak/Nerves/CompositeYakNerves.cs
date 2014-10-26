using System.Collections.Generic;

namespace Yak.Nerves
{
    internal class CompositeYakNerves : IYakNerves
    {
        private List<IYakNerves> nervesList;

        public CompositeYakNerves(ICollection<IYakNerves> nervesList)
        {
            this.nervesList = new List<IYakNerves>(nervesList);
        }

        public void SetPin(Pin pin, bool high)
        {
            foreach (var nerves in this.nervesList)
            {
                nerves.SetPin(pin, high);
            }
        }

        public void Initialize()
        {
            foreach (var nerves in this.nervesList)
            {
                nerves.Initialize();
            }
        }

        public void TearDown()
        {
            // tear down in inverse order from intialization
            var reversed = new List<IYakNerves>(this.nervesList);
            reversed.Reverse();
            foreach (var nerves in reversed)
            {
                nerves.TearDown();
            }
        }
    }
}