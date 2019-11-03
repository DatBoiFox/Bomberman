using Client.Models;
using Client.Models.Singleton;
using Client.Resources._Interfaces;
using Client.Resources.Abstract_Factory;
using Client.Resources.Adapter.Adapter_1;
using Client.Resources.Bridge;
using Client.Resources.Builder;
using Client.Resources.Command;
using Client.Resources.Decorator;
using Client.Resources.Models;
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

        //private ConnectionHandler connectionHandler;
        private Timer updatePlayerCount;
        private Timer updatePlayers;

        private RemoteControl rc = new RemoteControl();
        private List<Bomb> bombs = new List<Bomb>();

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

            //this.Controls.Add(box);
        }

        private async void UpdatePlayersCount(object sender, EventArgs e)
        {
            ConnectionHandler connectionHandler = ConnectionHandler.GetInstance();
            if (connectionHandler.connectionEstablished)
            {
                //await connectionHandler.GetAllPlayers();
                //label2.Text = "Current Players: " + connectionHandler.GetAllPlayers().
            }
        }

        private async void UpdatePlayers(object sender, EventArgs e)
        {
            ConnectionHandler connectionHandler = ConnectionHandler.GetInstance();
            if (!connectionHandler.connectionEstablished)
                return;

            await connectionHandler.Update(this, label1);

            if (Form.ActiveForm == this)
            {
                if (Keyboard.IsKeyDown(Key.D) || Keyboard.IsKeyDown(Key.A) || Keyboard.IsKeyDown(Key.W) || Keyboard.IsKeyDown(Key.S) || Keyboard.IsKeyDown(Key.LeftCtrl))
                {
                    if (Keyboard.IsKeyDown(Key.D))
                    {
                        rc.MoveRight(connectionHandler.clientPlayer);
                    }
                    if (Keyboard.IsKeyDown(Key.A))
                    {
                        rc.MoveLeft(connectionHandler.clientPlayer);
                    }
                    if (Keyboard.IsKeyDown(Key.W))
                    {
                        rc.MoveForward(connectionHandler.clientPlayer);
                    }
                    if (Keyboard.IsKeyDown(Key.S))
                    {
                        rc.MoveBackward(connectionHandler.clientPlayer);
                    }
                    if (Keyboard.IsKeyDown(Key.LeftCtrl))
                    {
                        rc.undo();
                    }
                    connectionHandler.clientPlayerBox.Location = new Point(connectionHandler.clientPlayer.x, connectionHandler.clientPlayer.y);
                    await connectionHandler.UpdatePlayer();
                }

                if (Keyboard.IsKeyDown(Key.X) || Keyboard.IsKeyDown(Key.Z))
                {
                    Bomb bomb;
                    if (bombs.Count > 0)
                    {
                        bomb = bombs.Last().Clone();
                        bomb.x = connectionHandler.clientPlayer.x;
                        bomb.y = connectionHandler.clientPlayer.y;
                    }
                    else
                    {
                        bomb = new Bomb(connectionHandler.clientPlayer.x, connectionHandler.clientPlayer.y);
                    }
                    bombs.Add(bomb);
                    PlayerFactory fac = new PlayerFactory();

                    if (Keyboard.IsKeyDown(Key.X))
                    {
                        PictureBox b = fac.CreateBomb(new HorizontalExplosion()).CreateBombModel(bomb);
                        this.Controls.Add(b);
                    }
                    if (Keyboard.IsKeyDown(Key.Z))
                    {
                        PictureBox b = fac.CreateBomb(new VerticalExplosion()).CreateBombModel(bomb);
                        this.Controls.Add(b);
                    }
                }
                if (Keyboard.IsKeyDown(Key.E))
                {
                    IMap mapAdapter = new MapAdapter();
                    IMapItems mapItems = mapAdapter;
                    mapItems = new Wall(1, 1, new Blue(), mapAdapter, mapItems);
                    mapItems = new Wall(2, 2, new Blue(), mapAdapter, mapItems);

                    PowerUpCrateBuildDirector director = new PowerUpCrateBuildDirector();
                    IPowerUpCrateBuilder builder = new QuantityCrateBuilder();
                    director.Construct(builder, 3, 3, mapAdapter, mapItems);
                    mapItems = builder.GetCrate();

                    mapItems.AddMapItem();
                    //IPowerUpCrateBuilder builder = new SpeedCrateBuilder();
                    //PowerUpCrateBuildDirector director = new PowerUpCrateBuildDirector();
                    //director.Construct(builder, 10, 10);
                    //Crate c = builder.GetCrate();
                    //c.ShowCrate();
                }
                if (Keyboard.IsKeyDown(Key.Q))
                {
                    //IPowerUpCrateBuilder builder = new QuantityCrateBuilder();
                    //PowerUpCrateBuildDirector director = new PowerUpCrateBuildDirector();
                    //director.Construct(builder, 10, 10);
                    //Crate c = builder.GetCrate();
                    //c.ShowCrate();
                }
            }


        }



        // ----------------Connection----------------
        public async void Connect()
        {
            ConnectionHandler connectionHandler = ConnectionHandler.GetInstance();
            await connectionHandler.Connect(this);
            if (connectionHandler.connectionEstablished)
                label1.Text = "Connected";
        }
        public async void Disconnect()
        {
            ConnectionHandler connectionHandler = ConnectionHandler.GetInstance();
            await connectionHandler.Disconnect(this);
            label1.Text = "Disconnected";
        }
        // ------------------------------------------
        private void button1_Click(object sender, EventArgs e)
        {
            updatePlayers.Start();
            Connect();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            updatePlayers.Stop();
            Disconnect();

        }




        //Not using
        private void gameTimer_Tick(object sender, EventArgs e)
        {
            //UpdatePlayers();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
        }
    }
}
