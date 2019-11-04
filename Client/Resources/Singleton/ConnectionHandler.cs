
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

namespace Client.Models.Singleton
{
    public class ConnectionHandler
    {
        private static readonly HttpClient client = new HttpClient(new HttpClientHandler { UseProxy = false });
        private string playersData = "https://localhost:44331/api/players/";

        private string bombsData = "https://localhost:44331/api/bombs/";
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

        // Bombs
        public List<Bomb> playerPlacedBombs;
        public List<Bomb> enemyPlacedBombs;
        public Dictionary<int, PictureBox> playerPlacedBombModels;
        public Dictionary<int, PictureBox> enemyPlacedBombModels;


        // Walls
        private string wallsData = "https://localhost:44331/api/walls/";
        public List<Wall> roomWalls;


        public Dictionary<int, PictureBox> wallModels;

        // Crates
        private string cratesData = "https://localhost:44331/api/crates/";
        public List<Crate> crates = new List<Crate>();




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

            
            //if (mapAdapter.getMap()[0] is Wall)
            //    form.Controls.Add(new PictureBox { Name = "Wall", Location = new Point(mapAdapter.getMap()[0].x, mapAdapter.getMap()[0].y), Size = new Size(600, 20), BackColor = Color.DarkSlateBlue });
            //if (mapAdapter.getMap()[1] is Wall)
            //    form.Controls.Add(new PictureBox { Name = "Wall", Location = new Point(mapAdapter.getMap()[1].x, mapAdapter.getMap()[1].y), Size = new Size(600, 20), BackColor = Color.DarkSlateBlue });
            //if (mapAdapter.getMap()[2] is Wall)
            //    form.Controls.Add(new PictureBox { Name = "Wall", Location = new Point(mapAdapter.getMap()[2].x, mapAdapter.getMap()[2].y), Size = new Size(20, 600), BackColor = Color.DarkSlateBlue });
            //if (mapAdapter.getMap()[3] is Wall)
            //    form.Controls.Add(new PictureBox { Name = "Wall", Location = new Point(mapAdapter.getMap()[3].x, mapAdapter.getMap()[3].y), Size = new Size(20, 600), BackColor = Color.DarkSlateBlue });
            //List<IGameObject> serverWalls = new List<IGameObject>();
            //foreach (var v in mapAdapter.getMap())
            //{
            //    if (v is Wall)
            //    {
            //        roomWalls.Add((Wall)v);
            //        serverWalls.Add(v);
            //        HttpResponseMessage response = await client.PostAsJsonAsync(wallsData, v);
            //    }
            //}

            // CRATE LOGIC

            PowerUpCrateBuildDirector director = new PowerUpCrateBuildDirector();
            IPowerUpCrateBuilder builder = new QuantityCrateBuilder();
            IPowerUpCrateBuilder builders = new SpeedCrateBuilder();

            director.Construct(builder, 60, 60, mapAdapter, mapItems);
            mapItems = builder.GetCrate();

            director.Construct(builder, 60, 450, mapAdapter, mapItems);
            mapItems = builder.GetCrate();

            director.Construct(builders, 450, 450, mapAdapter, mapItems);
            mapItems = builders.GetCrate();
            mapItems.AddMapItem();

            //mapItems.AddMapItem();
            foreach (var VARIABLE in mapAdapter.getMap())
            {
                if (VARIABLE is Crate)
                {

                    //IColor c = (Crate)VARIABLE.
                    form.Controls.Add(new PictureBox { Name = "Crate", Location = new Point(VARIABLE.x, VARIABLE.y), Size = new Size(25, 25), BackColor = (VARIABLE as Crate).GetColor().GetColor() });
                    Crate c = new Crate(VARIABLE.x, VARIABLE.y, null, null, null);
                    c.Type = (VARIABLE as Crate).powerUp.getPowerUpType();
                    HttpResponseMessage response = await client.PostAsJsonAsync(cratesData, c);
                }
            }

            if (mapAdapter.getMap()[0] is Wall)
                form.Controls.Add(new PictureBox { Name = "Wall", Location = new Point(mapAdapter.getMap()[0].x, mapAdapter.getMap()[0].y), Size = new Size(600, 20), BackColor = Color.DarkSlateBlue });
            if (mapAdapter.getMap()[1] is Wall)
                form.Controls.Add(new PictureBox { Name = "Wall", Location = new Point(mapAdapter.getMap()[1].x, mapAdapter.getMap()[1].y), Size = new Size(600, 20), BackColor = Color.DarkSlateBlue });
            if (mapAdapter.getMap()[2] is Wall)
                form.Controls.Add(new PictureBox { Name = "Wall", Location = new Point(mapAdapter.getMap()[2].x, mapAdapter.getMap()[2].y), Size = new Size(20, 600), BackColor = Color.DarkSlateBlue });
            if (mapAdapter.getMap()[3] is Wall)
                form.Controls.Add(new PictureBox { Name = "Wall", Location = new Point(mapAdapter.getMap()[3].x, mapAdapter.getMap()[3].y), Size = new Size(20, 600), BackColor = Color.DarkSlateBlue });
            List<IGameObject> serverWalls = new List<IGameObject>();
            foreach (var v in mapAdapter.getMap())
            {
                if (v is Wall)
                {
                    roomWalls.Add((Wall)v);
                    serverWalls.Add(v);
                    HttpResponseMessage response = await client.PostAsJsonAsync(wallsData, v);
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

                playerPlacedBombs = new List<Bomb>();
                enemyPlacedBombs = new List<Bomb>();

                enemyPlayerModels = new Dictionary<int, PictureBox>();
                playerPlacedBombModels = new Dictionary<int, PictureBox>();
                enemyPlacedBombModels = new Dictionary<int, PictureBox>();
                if (response.IsSuccessStatusCode)
                {
#pragma warning disable CS0618 // Type or member is obsolete
                    clientPlayer = await JsonConvert.DeserializeObjectAsync<Player>(await response.Content.ReadAsStringAsync());
#pragma warning restore CS0618 // Type or member is obsolete
                    connectionEstablished = true;

                    clientPlayerBox = playerCreator.CreatePlayerModel(clientPlayer);
                    form.Controls.Add(clientPlayerBox);
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
                    foreach (KeyValuePair<int, PictureBox> p in playerPlacedBombModels)
                    {
                        form.Controls.Remove(p.Value);
                    }
                    foreach (KeyValuePair<int, PictureBox> p in enemyPlacedBombModels)
                    {
                        form.Controls.Remove(p.Value);
                    }

                    currentlyOnlinePlayers = null;
                    playerPlacedBombs = null;
                    enemyPlacedBombs = null;
                    enemyPlayerModels = null;
                    playerPlacedBombModels = null;
                    enemyPlacedBombModels = null;

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

        public async Task<List<Bomb>> GetAllBombs()
        {
            if (connectionEstablished)
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
            if (!connectionEstablished)
                return;

            // PLAYERS LOGIC

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

        public async Task UpdateBombs(Form form, Label lab)
        {
            if (!connectionEstablished)
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
                        PictureBox bomb = fac.CreateBomb(new VerticalExplosion()).CreateBombModel(p);
                        //enemyPlayerModels.Add(p.id, enemy);
                        enemyPlacedBombModels.Add(p.id, bomb);
                        form.Controls.Add(bomb);
                    }
                    if (p.Type.Equals("Horizontal"))
                    {
                        PictureBox bomb = fac.CreateBomb(new HorizontalExplosion()).CreateBombModel(p);
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
