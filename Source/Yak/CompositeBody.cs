using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yak
{
    public class CompositeBody: IBody
    {
        private readonly List<IBody> bodies;

        public CompositeBody(params IBody[] bodies)
        {
            this.bodies = new List<IBody>(bodies);
        }

        public void Eyes(Nerves.LedColor eyeColor)
        {
            foreach(var body in bodies)
            {
                body.Eyes(eyeColor);
            }
        }

        public void Initialize()
        {
            foreach(var body in bodies)
            {
                body.Initialize();
            }
        }

        public void Rifle(Nerves.LedColor rifleColor)
        {
            foreach (var body in bodies)
            {
                body.Rifle(rifleColor);
            }
        }

        public void TearDown()
        {
            foreach (var body in bodies)
            {
                body.TearDown();
            }
        }

        public void Wait(int waitTime)
        {
            foreach (var body in bodies)
            {
                body.Wait(waitTime);
            }
        }
    }
}
