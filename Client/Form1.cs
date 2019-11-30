using Client.Models;
using Client.Resources._Interfaces;
using Client.Resources.Abstract_Factory;
using Client.Resources.Adapter.Adapter_1;
using Client.Resources.Bridge;
using Client.Resources.Builder;
using Client.Resources.Command;
using Client.Resources.Decorator;
using Client.Resources.Models;
using Client.Resources.Proxy;
using Client.Resources.Proxy.Singleton;
using Client.Resources.Strategy;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Input;

namespace Client
{
    public partial class Form1 : Form
    {
        private const int updateCountInterval = 300;
        private const int updatePlayersInterval = 30;

        private const int updateBombs = 100;
        private bool canBomb = true;


        //private ConnectionHandler connectionHandler;
        private Timer updatePlayerCount;
        private Timer updatePlayers;
        private Timer updateBombsTimer;

        private RemoteControl rc = new RemoteControl();
        private PlayerFactory playerFactory = new PlayerFactory();
        private EnemyFactory bombFactory = new EnemyFactory();
        private IConnectionHandler connectionHandler = ProxyConnectionHandler.GetInstance();
        //private List<Bomb> bombs = new List<Bomb>();

        //PictureBox box = new PictureBox
        //{
        //    Name = "pic",
        //    Size = new Size(18, 18),
        //    Location = new Point(20, 20),
        //    BackColor = Color.Pink

        //};


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //connectionHandler = new ConnectionHandler();
            SetUp();
        }
        private void SetUp()
        {
            updatePlayerCount = new Timer { Interval = updateCountInterval };
            
            //updatePlayerCount.Start();
            //updatePlayerCount.Tick += UpdatePlayersCount;

            updatePlayers = new Timer { Interval = updatePlayersInterval };
            //updatePlayers.Start();
            updatePlayers.Tick += UpdatePlayers;

            updateBombsTimer = new Timer { Interval = updateBombs };
            updateBombsTimer.Tick += UpdateBombs;

            //this.Controls.Add(box);
        }

        private async void UpdatePlayersCount(object sender, EventArgs e)
        {
            if (connectionHandler.ConnectionEstablished)
            {
                //await connectionHandler.GetAllPlayers();
                //label2.Text = "Current Players: " + connectionHandler.GetAllPlayers().
            }
        }

        private async void UpdateBombs(object sender, EventArgs e)
        {
            if (!connectionHandler.ConnectionEstablished)
                return;

            await connectionHandler.UpdateBombs(this, label1);
        }

        private async void UpdatePlayers(object sender, EventArgs e)
        {
            if (!connectionHandler.ConnectionEstablished)
                return;

            await connectionHandler.Update(this, label1);

            if (Form.ActiveForm == this)
            {
                if (Keyboard.IsKeyDown(Key.D) || Keyboard.IsKeyDown(Key.A) || Keyboard.IsKeyDown(Key.W) || Keyboard.IsKeyDown(Key.S) || Keyboard.IsKeyDown(Key.LeftCtrl))
                {
                    if (Keyboard.IsKeyDown(Key.D))
                    {
                        rc.MoveRight(connectionHandler.ClientPlayer);
                    }
                    if (Keyboard.IsKeyDown(Key.A))
                    {
                        rc.MoveLeft(connectionHandler.ClientPlayer);
                    }
                    if (Keyboard.IsKeyDown(Key.W))
                    {
                        rc.MoveForward(connectionHandler.ClientPlayer);
                    }
                    if (Keyboard.IsKeyDown(Key.S))
                    {
                        rc.MoveBackward(connectionHandler.ClientPlayer);
                    }
                    if (Keyboard.IsKeyDown(Key.LeftCtrl))
                    {
                        rc.undo();
                    }
                    connectionHandler.ClientPlayerBox.Location = new Point(connectionHandler.ClientPlayer.x, connectionHandler.ClientPlayer.y);
                    await connectionHandler.UpdatePlayer();
                }

                if (Keyboard.IsKeyDown(Key.X) || Keyboard.IsKeyDown(Key.Z))
                {
                    if (canBomb == true)
                    {
                        canBomb = false;
                        Bomb bomb;
                        String bombType = "";
                        if (connectionHandler.PlayerPlacedBombs.Count > 0)
                        {
                            bomb = connectionHandler.PlayerPlacedBombs.Last().Clone();
                            bomb.x = connectionHandler.ClientPlayer.x;
                            bomb.y = connectionHandler.ClientPlayer.y;
                        }
                        else
                        {
                            bomb = new Bomb(connectionHandler.ClientPlayer.x, connectionHandler.ClientPlayer.y);
                        }

                        PlayerFactory fac = new PlayerFactory();

                        if (Keyboard.IsKeyUp(Key.X))
                        {
                            PictureBox b = fac.CreateBomb("horizontal").CreateBombModel(bomb);
                            bomb.Type = "Horizontal";
                            connectionHandler.PlayerPlacedBombModels.Add(connectionHandler.PlayerPlacedBombs.Count, b);
                            this.Controls.Add(b);
                            bombType = "Horizontal";
                        }
                        if (Keyboard.IsKeyUp(Key.Z))
                        {
                            PictureBox b = fac.CreateBomb("vertical").CreateBombModel(bomb);
                            connectionHandler.PlayerPlacedBombModels.Add(connectionHandler.PlayerPlacedBombs.Count, b);
                            bomb.Type = "Vertical";
                            this.Controls.Add(b);
                            bombType = "Vertical";
                        }
                        connectionHandler.PlayerPlacedBombs.Add(bomb);
                        await connectionHandler.PostBomb(bomb, bombType);
                    }
                }
                else if (Keyboard.IsKeyUp(Key.X) || Keyboard.IsKeyUp(Key.Z))
                {
                    canBomb = true;
                }
                if (Keyboard.IsKeyDown(Key.E))
                {

                    //IPowerUpCrateBuilder builder = new SpeedCrateBuilder();
                    //PowerUpCrateBuildDirector director = new PowerUpCrateBuildDirector();
                    //director.Construct(builder, 10, 10);
                    //Crate c = builder.GetCrate();
                    //c.ShowCrate();
                    //this.Controls.Add(new PictureBox { Name = "Wall", Location = new Point(0, 30), Size = new Size(600, 30), BackColor = Color.Black });

                    //List<List<int>> mapWallVals = {0};

                    //for (int i = 2; i < 10; i++)
                    //{
                    //    if(i %2 != 0)
                    //        continue;
                    //    int x = 30 * i;
                    //    int y = 60;
                    //    this.Controls.Add(new PictureBox { Name = "Wall", Location = new Point(x, y), Size = new Size(30, 30), BackColor = Color.Black });
                    //}

                }
                if (Keyboard.IsKeyDown(Key.Q))
                {
                    //IPowerUpCrateBuilder builder = new QuantityCrateBuilder();
                    //PowerUpCrateBuildDirector director = new PowerUpCrateBuildDirector();
                    //director.Construct(builder, 10, 10);
                    //Crate c = builder.GetCrate();
                    //c.ShowCrate();

                    //IMap mapAdapter = new MapAdapter();
                    //IMapItems mapItems = mapAdapter;

                    //PowerUpCrateBuildDirector director = new PowerUpCrateBuildDirector();
                    //IPowerUpCrateBuilder builder = new QuantityCrateBuilder();
                    //IPowerUpCrateBuilder builders = new SpeedCrateBuilder();

                    //director.Construct(builder, 60, 60, mapAdapter, mapItems);
                    //mapItems = builder.GetCrate();

                    //director.Construct(builder, 60, 450, mapAdapter, mapItems);
                    //mapItems = builder.GetCrate();

                    //director.Construct(builders, 450, 450, mapAdapter, mapItems);
                    //mapItems = builders.GetCrate();
                    //mapItems.AddMapItem();


                    //foreach (var VARIABLE in mapAdapter.getMap())
                    //{
                    //    if (VARIABLE is Crate)
                    //    {
                            
                    //        //IColor c = (Crate)VARIABLE.
                    //        this.Controls.Add(new PictureBox { Name = "Crate", Location = new Point(VARIABLE.x, VARIABLE.y), Size = new Size(25, 25), BackColor = (VARIABLE as Crate).GetColor().GetColor() });

                    //    }
                    //}



                    

                }
            }


        }



        // ----------------Connection----------------
        public async void Connect()
        {
            await connectionHandler.Connect(this);
            if (connectionHandler.ConnectionEstablished)
            {
                //label1.Text = "Connected";
            }
        }
        public async void Disconnect()
        {
            await connectionHandler.Disconnect(this);
            //label1.Text = "Disconnected";
        }
        // ------------------------------------------
        private void button1_Click(object sender, EventArgs e)
        {
            
            Connect();
            updateBombsTimer.Start();
            updatePlayers.Start();
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            updatePlayers.Stop();
            updateBombsTimer.Stop();
            Disconnect();

        }




        //Not using
        private void gameTimer_Tick(object sender, EventArgs e)
        {
            //UpdatePlayers();
            try {
                label1.Text = connectionHandler.State.displayState();
            }
            catch { }
            
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
