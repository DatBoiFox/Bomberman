using Client.Models;
using Client.Models.Proxy;
using Client.Resources.Proxy;
using Client.Resources.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.Resources.Proxy.Singleton
{
    class ProxyConnectionHandler : IConnectionHandler
    {
        private ConnectionHandler connectionHandler = null;
        private static ProxyConnectionHandler instance = null;
        private static object _lock = new object();

        public bool ConnectionEstablished 
        {
            get
            {
                if (connectionHandler == null)
                    connectionHandler = new ConnectionHandler();
                return connectionHandler.ConnectionEstablished;
            }
        }
        public Player ClientPlayer
        {
            get
            {
                if (connectionHandler == null)
                    connectionHandler = new ConnectionHandler();
                return connectionHandler.ClientPlayer;
            }
        }
        public PictureBox ClientPlayerBox
        {
            get
            {
                if (connectionHandler == null)
                    connectionHandler = new ConnectionHandler();
                return connectionHandler.ClientPlayerBox;
            }
        }
        public List<Bomb> PlayerPlacedBombs
        {
            get
            {
                if (connectionHandler == null)
                    connectionHandler = new ConnectionHandler();
                return connectionHandler.PlayerPlacedBombs;
            }
        }
        public Dictionary<int, PictureBox> PlayerPlacedBombModels
        {
            get
            {
                if (connectionHandler == null)
                    connectionHandler = new ConnectionHandler();
                return connectionHandler.PlayerPlacedBombModels;
            }
        }
        public IConnectionState State
        {
            get
            {
                if (connectionHandler == null)
                    connectionHandler = new ConnectionHandler();
                return connectionHandler.State;
            }
            set
            {
                if (connectionHandler == null)
                    connectionHandler = new ConnectionHandler();
                connectionHandler.State = value;
            }
        }

        public static ProxyConnectionHandler GetInstance()
        {

            lock (_lock)
            {
                if (instance == null)
                {
                    instance = new ProxyConnectionHandler();
                }
            }

            return instance;

        }

        public async Task UpdateBombs(Form form, Label lab)
        {
            if (connectionHandler == null)
                connectionHandler = new ConnectionHandler();
            await connectionHandler.UpdateBombs(form, lab);
        }

        public async Task Update(Form form, Label lab)
        {
            if (connectionHandler == null)
                connectionHandler = new ConnectionHandler();
            await connectionHandler.Update(form, lab);
        }

        public async Task UpdatePlayer()
        {
            if (connectionHandler == null)
                connectionHandler = new ConnectionHandler();
            await connectionHandler.UpdatePlayer();
        }

        public async Task PostBomb(Bomb b, string bombType)
        {
            if (connectionHandler == null)
                connectionHandler = new ConnectionHandler();
            await connectionHandler.PostBomb(b, bombType);
        }
        //private ConnectionHandler connectionHandlerTest = new ConnectionHandler();
        public async Task Connect(Form form)
        {
            if (connectionHandler == null)
                connectionHandler = new ConnectionHandler();
            if(await connectionHandler.GetConnectedPlayersCount() >= 2)
            {
                connectionHandler.State = new RoomFullState();
            }
            else
            {
                await connectionHandler.Connect(form);
            }

            
        }

        public async Task Disconnect(Form form)
        {
            if (connectionHandler == null)
                connectionHandler = new ConnectionHandler();
            await connectionHandler.Disconnect(form);
        }
    }
}
