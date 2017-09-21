using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace CGM208_exercise3
{
    public partial class SliderPuzzle : Form
    {
        private int[] imageArr = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        private PictureBox[] PicBoxes;
        private Image[] PlayerImages;
        private Label txt_TimeCount;

        private int Emptypos;
        private int paddingLeft = 40;
        private int paddingTop = 0;
        private int padding = 200;
        private int WindowWidth = 800;
        private int WindowHeight = 600;

        private int PicBoxesWidth = 0;
        private int PicBoxHeight = 0;

        private string CurrentDirectory;
        private string FolderName = @"\Images";
        public SliderPuzzle()
        {
            InitializeComponent();
            this.Size = new Size(WindowWidth, WindowHeight);
            paddingTop = MenuStrip.Height;

            int WidthLeft = WindowWidth - padding - paddingTop;
            int HeightLeft = WidthLeft;

            PicBoxesWidth = (WidthLeft / 3);
            PicBoxHeight = (HeightLeft / 3);
            CurrentDirectory = Directory.GetCurrentDirectory();

            this.MaximizeBox = false;
        }

        private void SliderPuzzle_Load(object sender, EventArgs e)
        {
            PicBoxes = new PictureBox[9];
            PlayerImages = new Image[9];
            txt_TimeCount = new Label();
            txt_TimeCount.Font = new Font("Segoe UI", 16, FontStyle.Bold);
            for(int i =0,index = 0;i<3;i++)
            {
                for(int j = 0;j<3;j++)
                {
                    PicBoxes[index] = new PictureBox();
                    PicBoxes[index].Width = PicBoxesWidth;
                    PicBoxes[index].Height = PicBoxHeight;
                    PicBoxes[index].Left =j * PicBoxesWidth+paddingLeft;
                    PicBoxes[index].Top = i * PicBoxHeight;
                    PicBoxes[index].BorderStyle = BorderStyle.FixedSingle;
                    PicBoxes[index].Tag = index;
                    PicBoxes[index].Click += SliderPuzzle_Click;
                    index++;
                }
            }
            this.Controls.AddRange(PicBoxes);
            this.Controls.Add(txt_TimeCount);
            MenuStrip.ItemClicked += MenuStrip_ItemClicked;
            LoadImageFromFile();
            NewGame();
        }

        private void MenuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            var selectMenuItem = sender as MenuItem;
            var menuText = selectMenuItem.Text;

            switch(menuText)
            {
                case "NewGame":
                    MessageBox.Show("Click");
                    break;
            }
        }

        private void SliderPuzzle_Click(object sender, EventArgs e)
        {
            int selectedPicture = (int)(sender as PictureBox).Tag;
            
            switch(selectedPicture)
            {
                case 0:
                    SlideImage(0);
                    break;
                case 1:
                    SlideImage(1);
                    break;
                case 2:
                    SlideImage(2);
                    break;
                case 3:
                    SlideImage(3);
                    break;
                case 4:
                    SlideImage(4);
                    break;
                case 5:
                    SlideImage(5);
                    break;
                case 6:
                    SlideImage(6);
                    break;
                case 7:
                    SlideImage(7);
                    break;
                case 8:
                    SlideImage(8);
                    break;
            }
        }
        private void NewGame()
        {
            Random rand = new Random();
            for (int i = 0;i<9;i++)
            {
                int j = rand.Next(0, 8);
                int k = rand.Next(0, 8);
                int jValue = imageArr[j];
                int kValue = imageArr[k];

                imageArr[j] = kValue;
                imageArr[k] = jValue;
            }
            for(int i = 0;i<9;i++)
            {
                LoadImageToBox(i, imageArr[i]);
            }
            PicBoxes[8].Image = null;
            Emptypos = 8;
        }
        private void LoadImageToBox(int picBoxIndex,int imageIndex)
        {
            PicBoxes[picBoxIndex].Image = PlayerImages[imageIndex];
        }
        private void LoadImageFromFile()
        {
            for (int i = 0; i < 9; i++)
            {
                string Imagepath = CurrentDirectory + FolderName + @"\" + i + ".jpg";
                PlayerImages[i] = Image.FromFile(Imagepath);
            }
        }
        private void EndGame()
        {
            if (isWinner())
            {
                for (int i = 0; i < 9; i++)
                {
                    LoadImageToBox(i, i);
                }
                MessageBox.Show("You Win!!!");
            }
        }
        private void SlideImage(int index)
        {
            
        }
        private bool isWinner()
        {
            bool isWin = false;
            for(int i = 0;i<9;i++)
            {
                if(imageArr[i] == i)
                {
                    isWin = true;
                }
                else
                {
                    isWin = false;
                    break;
                }
            }
            return isWin;
        }
    }
}
