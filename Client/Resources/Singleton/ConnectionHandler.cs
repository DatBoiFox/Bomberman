
using Client.Resources.Abstract_Factory;
using Client.Resources.Abstract_Factory.Player_Factory;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Client.Models.Singleton
{
    public class ConnectionHandler
    {
        private static readonly HttpClient client = new HttpClient(new HttpClientHandler { UseProxy = false });
        private string playersData = "https://localhost:44331/api/players/";
        //private string playersData = "https://localhost:5001/api/players/";
        private IPlayerCreator playerCreator;
        private IPlayerCreator enemyCreator;
        private static object _lock = new object();
        private static ConnectionHandler instance = null;

        //public List<PictureBox> playerModels;
        public Player clientPlayer;
        public PictureBox clientPlayerBox;
        //public List<Player> players;
        public List<Player> currentlyOnlinePlayers;
        public Dictionary<int, PictureBox> enemyPlayerModels;

        public bool connectionEstablished = false;

        public static ConnectionHandler GetInstance()
        {

            lock (_lock)
            {
                if (instance == null)
                {
                    instance = new ConnectionHandler();
                }
            }

            return instance;

        }

        public ConnectionHandler()
        {
            //playerModels = new List<PictureBox>();
        }

        public async Task Connect(Form form)
        {
            if (clientPlayer == null)
            {
                clientPlayer = new Player();
                HttpResponseMessage response = await client.PostAsJsonAsync(playersData, clientPlayer);
                playerCreator = new PlayerFactory().CreatePlayer();//PlayerCreatorHandler.GetPlayerCreator();
                enemyCreator = new EnemyFactory().CreatePlayer();//PlayerCreatorHandler.GetEnemyCreator();
                currentlyOnlinePlayers = new List<Player>();
                enemyPlayerModels = new Dictionary<int, PictureBox>();
                if (response.IsSuccessStatusCode)
                {
#pragma warning disable CS0618 // Type or member is obsolete
                    clientPlayer = await JsonConvert.DeserializeObjectAsync<Player>(await response.Content.ReadAsStringAsync());
#pragma warning restore CS0618 // Type or member is obsolete
                    connectionEstablished = true;

                    clientPlayerBox = playerCreator.CreatePlayerModel(clientPlayer);
                    form.Controls.Add(clientPlayerBox);
                }
            }

        }
        public async Task Disconnect(Form form)
        {
            connectionEstablished = false;
            if (clientPlayer != null)
            {
                HttpResponseMessage response = await client.DeleteAsync(playersData + clientPlayer.id);
                if (response.IsSuccessStatusCode)
                {
                    clientPlayer = null;
                    playerCreator = null;
                    enemyCreator = null;
                    form.Controls.Remove(clientPlayerBox);

                    //foreach(Player p in currentlyOnlinePlayers)
                    //{
                    //    form.Controls.Remove(enemyPlayerModels[p.id]);
                    //}

                    foreach (KeyValuePair<int, PictureBox> p in enemyPlayerModels)
                    {
                        form.Controls.Remove(p.Value);
                    }

                    currentlyOnlinePlayers = null;
                    currentlyOnlinePlayers = null;
                    enemyPlayerModels = null;


                    //form.Controls.Remove()
                }
            }
        }

        public async Task UpdatePlayer()
        {
            if (!connectionEstablished)
                return;


            HttpResponseMessage response = await client.PutAsJsonAsync(playersData + clientPlayer.id, clientPlayer);

            if (response.IsSuccessStatusCode)
            {

            }
            else
                throw new Exception(playersData + clientPlayer.id);

        }

        public async Task<List<Player>> GetAllPlayers()
        {
            if (connectionEstablished)
            {
                HttpResponseMessage response = await client.GetAsync(playersData);
                if (response.IsSuccessStatusCode)
                {
                    List<Player> players = await response.Content.ReadAsAsync<List<Player>>();
                    return players;
                }
            }
            return null;
        }

        public async Task Update(Form form, Label lab)
        {
            if (!connectionEstablished)
                return;

            currentlyOnlinePlayers = await GetAllPlayers();
            currentlyOnlinePlayers = currentlyOnlinePlayers.Where(p => p.id != clientPlayer.id).ToList();

            foreach (KeyValuePair<int, PictureBox> p in enemyPlayerModels)
            {
                form.Controls.Remove(p.Value);
            }
            enemyPlayerModels = new Dictionary<int, PictureBox>();

            foreach (Player p in currentlyOnlinePlayers)
            {
                if (!enemyPlayerModels.ContainsKey(p.id))
                {
                    PictureBox enemy = enemyCreator.CreatePlayerModel(p);
                    enemyPlayerModels.Add(p.id, enemy);
                    form.Controls.Add(enemy);
                }
                else
                {
                    enemyPlayerModels[p.id].Location = new Point(p.x, p.y);
                }

            }


        }

    }
}

//players = await GetAllPlayers();
//Console.WriteLine(players.Count);

//List<Player> curretPlayersWithoutClient = players.Where(p => p.id != clientPlayer.id).ToList();
//if (curretPlayersWithoutClient == null)
//    return;

//foreach (Player p in curretPlayersWithoutClient)
//{
//    if (curretPlayersWithoutClient.Contains(p) && !onlinePlayers.Contains(p))
//    {
//        PictureBox otherPlayer = playerCreator.CreatePlayerModel(p);
//        form.Controls.Add(otherPlayer);
//        onlinePlayers.Add(p);
//        playerModels.Add(otherPlayer);
//    }
//}
//for(int i = 0; i < onlinePlayers.Count; i++)
//{
//    playerModels[i].Location = new Point(onlinePlayers[i].x, onlinePlayers[i].y);
//}

////PictureBox playerBox = playerCreator.CreatePlayerModel(clientPlayer);
////form.Controls.Add(playerBox);
