using Client.Models;
using Client.Resources.Decorator;
using System;
using Client.Resources.Adapter.Adapter_2;

namespace Client.Resources.Models
{
    public class Crate : MapItemDecorator
    {
        public new int id { get; private set; }
        public new int x { get; private set; }
        public new int y { get; private set; }

<<<<<<< HEAD
        public string powerUp { get; set; }

=======
        //public string powerUp { get; set; }
        public IPowerUp powerUp { get; set; }

        public Crate()
        {
        }
>>>>>>> 905b933486b08bfad4e9a3feaf268b2e90c1c022
        public Crate(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public Crate(int x, int y, IPowerUp powerUp)
        {
            this.x = x;
            this.y = y;
            this.powerUp = powerUp;
        }
        public void ShowCrate()
        {
            throw new Exception("Crate with : " + powerUp);
        }

        public void Destroy()
        {

        }
    }
}
