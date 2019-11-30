
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
using Client.Resources._Interfaces;
using Client.Resources.Adapter.Adapter_1;
using Client.Resources.Bridge;
using Client.Resources.Builder;
using Client.Resources.Decorator;
using Client.Resources.Models;
using Client.Resources.Strategy;
using Client.Resources.Iterator;
using Client.Resources.Proxy;
using Client.Resources.State;

namespace Client.Models.Proxy
{
    public class ConnectionHandler : IConnectionHandler
    {
        private static readonly HttpClient client = new HttpClient(new HttpClientHandler { UseProxy = false });
        private string playersData = "https://localhost:44331/api/players/";

        private string bombsData = "https://localhost:44331/api/bombs/";
        //private string playersData = "https://localhost:5001/api/players/";
        private IPlayerCreator playerCreator;
        private IPlayerCreator enemyCreator;

        //public List<PictureBox> playerModels;
        public Player ClientPlayer { get; private set; }
        public PictureBox ClientPlayerBox { get; set; }
        //public List<Player> players;
        public List<Player> currentlyOnlinePlayers;
        public Dictionary<int, PictureBox> enemyPlayerModels;

        // Bombs
        public List<Bomb> PlayerPlacedBombs { get; private set; }
        public List<Bomb> enemyPlacedBombs;
        public Dictionary<int, PictureBox> PlayerPlacedBombModels { get; private set; }
        public Dictionary<int, PictureBox> enemyPlacedBombModels;


        // Walls
        private string wallsData = "https://localhost:44331/api/walls/";
        public List<Wall> roomWalls;


        public Dictionary<int, PictureBox> wallModels;

        // Crates
        private string cratesData = "https://localhost:44331/api/crates/";
        public List<Crate> crates = new List<Crate>();

        public bool ConnectionEstablished { get; private set; }
        public IConnectionState State { get; set; }

        //mapItems = new Wall(120, 210, new Blue(), mapAdapter, mapItems);

        //for (int i = 1; i <= 10; i++)
        //{
        //    mapItems = new Wall(i*10, 30, new Blue(), mapAdapter, mapItems);
        //}

        //PowerUpCrateBuildDirector director = new PowerUpCrateBuildDirector();
        //IPowerUpCrateBuilder builder = new QuantityCrateBuilder();
        //director.Construct(builder, 300, 300, mapAdapter, mapItems);
        //mapItems = builder.GetCrate();

        private async Task TryToCreateMap(Form form)
        {
            // MAP
            IMap mapAdapter = new MapAdapter();
            IMapItems mapItems = mapAdapter;

            // WALLS LOGIC
            mapItems = new Wall(0, 40, new Blue(), mapAdapter, mapItems);
            mapItems = new Wall(0, 542, new Blue(), mapAdapter, mapItems);
            mapItems = new Wall(0, 0, new Blue(), mapAdapter, mapItems);
            mapItems = new Wall(565, 0, new Blue(), mapAdapter, mapItems);
       

            PowerUpCrateBuildDirector director = new PowerUpCrateBuildDirector();
            PowerUpCrateBuilder builder = new QuantityCrateBuilder();
            PowerUpCrateBuilder builders = new SpeedCrateBuilder();

            director.Construct(builder, 60, 60, mapAdapter, mapItems);
            mapItems = builder.GetCrate();

            director.Construct(builder, 60, 450, mapAdapter, mapItems);
            mapItems = builder.GetCrate();

            director.Construct(builders, 450, 450, mapAdapter, mapItems);
            mapItems = builders.GetCrate();
            mapItems.AddMapItem();

            Iterator mapIterator = mapAdapter.GetMap().GetIterator();
            int wallIndex = 0;

            //mapItems.AddMapItem();
            for (IGameObject gameObject = (IGameObject)mapIterator.First(); !mapIterator.IsDone(); gameObject = (IGameObject)mapIterator.Next())
            {
                if (gameObject is Crate)
                {

                    //IColor c = (Crate)VARIABLE.
                    form.Controls.Add(new PictureBox { Name = "Crate", Location = new Point(gameObject.x, gameObject.y), Size = new Size(25, 25), BackColor = (gameObject as Crate).GetColor().GetColor() });
                    Crate c = (Crate)gameObject;
                    c.Type = c.powerUp.getPowerUpType();
                    HttpResponseMessage response = await client.PostAsJsonAsync(cratesData, c);
                }
                else if (gameObject is Wall)
                {
                    if (wallIndex < 2)
                        form.Controls.Add(new PictureBox { Name = "Wall", Location = new Point(gameObject.x, gameObject.y), Size = new Size(600, 20), BackColor = Color.DarkSlateBlue });
                    else
                        form.Controls.Add(new PictureBox { Name = "Wall", Location = new Point(gameObject.x, gameObject.y), Size = new Size(20, 600), BackColor = Color.DarkSlateBlue });
                    roomWalls.Add((Wall)gameObject);
                    HttpResponseMessage response = await client.PostAsJsonAsync(wallsData, gameObject);
                    wallIndex++;
                }
            }       
        }


        private async Task TryTogetMap(Form form)
        {
            HttpResponseMessage response = await client.GetAsync(cratesData);

#pragma warning disable CS0618 // Type or member is obsolete
            crates = await JsonConvert.DeserializeObjectAsync<List<Crate>>(await response.Content.ReadAsStringAsync());
#pragma warning restore CS0618 // Type or member is obsolete

            form.Controls.Add(new PictureBox { Name = "Wall", Location = new Point(roomWalls[0].x, roomWalls[0].y), Size = new Size(600, 20), BackColor = Color.DarkSlateBlue });
            form.Controls.Add(new PictureBox { Name = "Wall", Location = new Point(roomWalls[1].x, roomWalls[1].y), Size = new Size(600, 20), BackColor = Color.DarkSlateBlue });
            form.Controls.Add(new PictureBox { Name = "Wall", Location = new Point(roomWalls[2].x, roomWalls[2].y), Size = new Size(20, 600), BackColor = Color.DarkSlateBlue });
            form.Controls.Add(new PictureBox { Name = "Wall", Location = new Point(roomWalls[3].x, roomWalls[3].y), Size = new Size(20, 600), BackColor = Color.DarkSlateBlue });

            foreach (var crate in crates)
            {
                if(crate.Type == "Quantity")
                    form.Controls.Add(new PictureBox { Name = "Crate", Location = new Point(crate.x, crate.y), Size = new Size(25, 25), BackColor = Color.Brown });
                if (crate.Type == "Speed")
                    form.Controls.Add(new PictureBox { Name = "Crate", Location = new Point(crate.x, crate.y), Size = new Size(25, 25), BackColor = Color.Black });

            }

        }

        public ConnectionHandler()
        {
            ConnectionEstablished = false;
            //playerModels = new List<PictureBox>();
        }

        public async Task Connect(Form form)
        {
            if (ClientPlayer == null)
            {
                ClientPlayer = new Player();
                HttpResponseMessage response = await client.PostAsJsonAsync(playersData, ClientPlayer);
                playerCreator = new PlayerFactory().CreatePlayer();//PlayerCreatorHandler.GetPlayerCreator();
                enemyCreator = new EnemyFactory().CreatePlayer();//PlayerCreatorHandler.GetEnemyCreator();
                currentlyOnlinePlayers = new List<Player>();

                PlayerPlacedBombs = new List<Bomb>();
                enemyPlacedBombs = new List<Bomb>();

                enemyPlayerModels = new Dictionary<int, PictureBox>();
                PlayerPlacedBombModels = new Dictionary<int, PictureBox>();
                enemyPlacedBombModels = new Dictionary<int, PictureBox>();
                if (response.IsSuccessStatusCode)
                {
#pragma warning disable CS0618 // Type or member is obsolete
                    ClientPlayer = await JsonConvert.DeserializeObjectAsync<Player>(await response.Content.ReadAsStringAsync());
#pragma warning restore CS0618 // Type or member is obsolete
                    ConnectionEstablished = true;

                    ClientPlayerBox = playerCreator.CreatePlayerModel(ClientPlayer);
                    form.Controls.Add(ClientPlayerBox);
                    roomWalls = new List<Wall>();

                    
                    //response = await client.GetAsync(wallsData);

                    HttpResponseMessage wallsResponse = await client.GetAsync(wallsData);


                    if (wallsResponse.IsSuccessStatusCode)
                    {
#pragma warning disable CS0618 // Type or member is obsolete
                        roomWalls = await JsonConvert.DeserializeObjectAsync<List<Wall>>(await wallsResponse.Content.ReadAsStringAsync());
#pragma warning restore CS0618 // Type or member is obsolete
                        if (roomWalls.Count > 0)
                        {
                            await TryTogetMap(form);
                        }
                        else
                        {
                            await TryToCreateMap(form);

                        }

                    }

                }
            }

        }
        public async Task Disconnect(Form form)
        {
            ConnectionEstablished = false;
            if (ClientPlayer != null)
            {
                HttpResponseMessage response = await client.DeleteAsync(playersData + ClientPlayer.id);
                if (response.IsSuccessStatusCode)
                {
                    ClientPlayer = null;
                    playerCreator = null;
                    enemyCreator = null;
                    form.Controls.Remove(ClientPlayerBox);

                    //foreach(Player p in currentlyOnlinePlayers)
                    //{
                    //    form.Controls.Remove(enemyPlayerModels[p.id]);
                    //}

                    foreach (KeyValuePair<int, PictureBox> p in enemyPlayerModels)
                    {
                        form.Controls.Remove(p.Value);
                    }
                    foreach (KeyValuePair<int, PictureBox> p in PlayerPlacedBombModels)
                    {
                        form.Controls.Remove(p.Value);
                    }
                    foreach (KeyValuePair<int, PictureBox> p in enemyPlacedBombModels)
                    {
                        form.Controls.Remove(p.Value);
                    }

                    currentlyOnlinePlayers = null;
                    PlayerPlacedBombs = null;
                    enemyPlacedBombs = null;
                    enemyPlayerModels = null;
                    PlayerPlacedBombModels = null;
                    enemyPlacedBombModels = null;

                    //form.Controls.Remove()
                }
            }
        }

        public async Task UpdatePlayer()
        {
            if (!ConnectionEstablished)
                return;


            HttpResponseMessage response = await client.PutAsJsonAsync(playersData + ClientPlayer.id, ClientPlayer);

            if (response.IsSuccessStatusCode)
            {

            }
            else
                throw new Exception(playersData + ClientPlayer.id);

        }

        public async Task<List<Player>> GetAllPlayers()
        {
            if (ConnectionEstablished)
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

        public async Task<List<Bomb>> GetAllBombs()
        {
            if (ConnectionEstablished)
            {
                HttpResponseMessage response = await client.GetAsync(bombsData);
                if (response.IsSuccessStatusCode)
                {
                    List<Bomb> bombs = await response.Content.ReadAsAsync<List<Bomb>>();
                    return bombs;
                }
            }
            return null;
        }

        public async Task PostBomb(Bomb b, string bombType)
        {
            b.Type = bombType;
            HttpResponseMessage response = await client.PostAsJsonAsync(bombsData, b);
        }


        public async Task Update(Form form, Label lab)
        {
            if (!ConnectionEstablished)
                return;

            // PLAYERS LOGIC

            currentlyOnlinePlayers = await GetAllPlayers();
            currentlyOnlinePlayers = currentlyOnlinePlayers.Where(p => p.id != ClientPlayer.id).ToList();

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

        public async Task UpdateBombs(Form form, Label lab)
        {
            if (!ConnectionEstablished)
                return;

            // BOMBS LOGICS
            enemyPlacedBombs = await GetAllBombs();
            PlayerFactory fac = new PlayerFactory();
            foreach (Bomb p in enemyPlacedBombs)
            {
                if (!enemyPlacedBombModels.ContainsKey(p.id))
                {
                    if (p.Type.Equals("Vertical"))
                    {
                        PictureBox bomb = fac.CreateBomb("vertical").CreateBombModel(p);
                        //enemyPlayerModels.Add(p.id, enemy);
                        enemyPlacedBombModels.Add(p.id, bomb);
                        form.Controls.Add(bomb);
                    }
                    if (p.Type.Equals("Horizontal"))
                    {
                        PictureBox bomb = fac.CreateBomb("horizontal").CreateBombModel(p);
                        //enemyPlayerModels.Add(p.id, enemy);
                        enemyPlacedBombModels.Add(p.id, bomb);
                        form.Controls.Add(bomb);
                    }

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
