using Client.Resources.Abstract_Factory.Bomb_Factory;
using Client.Resources.Abstract_Factory.Player_Factory;
using Client.Resources.Strategy;

namespace Client.Resources.Abstract_Factory
{
    public class EnemyFactory : AbstractGameObjectsFactory
    {
        private Form1 form;

        public override IBombCreator CreateBomb(string strategy)
        {
            if (form != null)
            {
                form.notify(0, "Create enemy bomb");
            }
            return BombCreatorHandler.GetBombCreator(strategy, "enemy");
        }

        public override IPlayerCreator CreatePlayer()
        {
            return PlayerCreatorHandler.GetEnemyCreator();
        }

        public void setForm(Form1 form)
        {
            this.form = form;
        }
    }
}
