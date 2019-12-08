using System.Windows.Forms;
using Client.Resources.Abstract_Factory.Bomb_Factory;
using Client.Resources.Abstract_Factory.Player_Factory;
using Client.Resources.Strategy;

namespace Client.Resources.Abstract_Factory
{
    public class PlayerFactory : AbstractGameObjectsFactory
    {
        private Form1 form;
        //public PlayerFactory(Form1 form)
        //{
        //    this.form = form;
        //}

        public override IBombCreator CreateBomb(string strategy)
        {
            if (form != null)
            {
                form.notify(0, "Create player bomb");
            }
            return BombCreatorHandler.GetBombCreator(strategy, "player");
        }

        public override IPlayerCreator CreatePlayer()
        {
            return PlayerCreatorHandler.GetPlayerCreator();
        }

        public void setForm(Form1 form)
        {
            this.form = form;
        }
    }
}
