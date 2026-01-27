using Eto.Drawing;
using Eto.Forms;
using System;

namespace OfflineRadio
{
    partial class RadioForm : Form
    {
        void InitializeComponent()
        {
            Title = "Radio";
            MinimumSize = new Size(264, 147);
            Size = MinimumSize;
            Resizable = false;

            //menu strip

            aboutToolStripMenuItem = new Command { MenuText = "About..." };
            aboutToolStripMenuItem.Executed += (sender, e) => new AboutDialog().ShowDialog(this);

            topMostToolStripMenuItem = new CheckCommand { MenuText = "Always on Top" };
            topMostToolStripMenuItem.Executed += TopMostToolStripMenuItem_Executed;

            selectFolderCommand = new Command { MenuText = "Select Folder" };
            selectFolderCommand.Executed += SelectFolderCommand_Executed;
            
            refreshStationsCommand = new Command { MenuText = "Refresh Stations" };
            refreshStationsCommand.Executed += RefreshStationsCommand_Executed;
            
            clearStationsCommand = new Command { MenuText = "Clear Stations" };
            clearStationsCommand.Executed += ClearStationsCommand_Executed;

            //form

            BT_StartPlayback = new Button { Text = "Play" , Size = new Size(111, 22) ,TabIndex = 0};
            BT_StartPlayback.Focus();
            BT_StartPlayback.Click += BT_StartPlayback_Click;

            BT_StopPlayback = new Button { Text = "Stop", Size = new Size(111, 22), Enabled = false,TabIndex = 1 };
            BT_StopPlayback.Click += BT_StopPlayback_Click;

            Sl_Volume = new Slider {Value = 100, MaxValue = 100, MinValue = 0, TickFrequency = 5, Size = new Size(186, 45), TabIndex =2 };
            Sl_Volume.ValueChanged += Sl_Volume_ValueChanged;

            CbB_Stations = new ComboBox { Size = new Size(181, 19) ,TabIndex = 3};
            CbB_Stations.SelectedIndexChanged += CbB_Stations_SelectedIndexChanged;

            LB_Volume = new Label { Text = Sl_Volume.Value.ToString() };
            label1 = new Label { Text = "Station:" };
            label2 = new Label { Text =  "Volume:"};

            //set layout

            PixelLayout layout = new PixelLayout();
            layout.Add(BT_StartPlayback, 10, 27);
            layout.Add(BT_StopPlayback, 126, 27);
            layout.Add(Sl_Volume, 48, 50);
            layout.Add(CbB_Stations, 56, 0);
            layout.Add(label1, 8, 3);
            layout.Add(label2, 2, 50);
            layout.Add(LB_Volume, 10, 63);

            Content = layout;

            // create menu
            Menu = new MenuBar
            {
                Items =
                {
					// File submenu
					new SubMenuItem { Text = "&Stations", Items = { selectFolderCommand, refreshStationsCommand, clearStationsCommand } },
                    new SubMenuItem { Text = "&Help", Items = { aboutToolStripMenuItem, topMostToolStripMenuItem}}
				}
            };


            this.Closing += MainForm_Closing;
        }

        private Command selectFolderCommand;
        private ComboBox CbB_Stations;
        private Label label1;
        private Button BT_StartPlayback;
        private Button BT_StopPlayback;
        private Slider Sl_Volume;
        private Label label2;
        private Label LB_Volume;
        private Command clearStationsCommand;
        private Command aboutToolStripMenuItem;
        private Command refreshStationsCommand;
        private CheckCommand topMostToolStripMenuItem;
    }
}
