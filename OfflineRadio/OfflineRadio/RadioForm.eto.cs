using Eto.Drawing;
using Eto.Forms;
using System;

namespace OfflineRadio
{
    partial class RadioForm : Form
    {
        void InitializeComponent()
        {
            Font font = new Font(SystemFont.Default, 4f);
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
            BT_StartPlayback = new Button { Text = "Play", Size = new Size(111, 22), TabIndex = 0 };
            BT_StartPlayback.Focus();
            BT_StartPlayback.Click += BT_StartPlayback_Click;

            BT_StopPlayback = new Button { Text = "Stop", Size = new Size(111, 22), Enabled = false, TabIndex = 1 };
            BT_StopPlayback.Click += BT_StopPlayback_Click;

            Sl_Volume = new Slider { Value = 100, MaxValue = 100, MinValue = 0, TickFrequency = 2, Size = new Size(186, 45), TabIndex = 2 };
            Sl_Volume.ValueChanged += Sl_Volume_ValueChanged;

            CbB_Stations = new ComboBox { Width = 181, TabIndex = 3 };
            CbB_Stations.SelectedIndexChanged += CbB_Stations_SelectedIndexChanged;

            LB_Volume = new Label { Text = "Volume:\n" + Sl_Volume.Value.ToString(), TextAlignment = TextAlignment.Center };
            label1 = new Label { Text = "Station:", VerticalAlignment = VerticalAlignment.Center };
            label2 = new Label { Text = "Volume:" };

            //set layout
            DynamicLayout layout = new DynamicLayout();
            layout.Padding = new Padding(6, 2);
            layout.Spacing = new Size(0, 2);
            layout.AddSeparateRow(label1, CbB_Stations);
            layout.AddSeparateRow(null, BT_StartPlayback, BT_StopPlayback);
            layout.AddSeparateRow(LB_Volume, Sl_Volume);

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
