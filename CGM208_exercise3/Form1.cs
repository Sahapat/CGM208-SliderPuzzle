using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace CGM208_exercise3
{
    public partial class SliderPuzzle : Form
    {
        private int[] imageArr = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        private int[] Default = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        private PictureBox[] PicBoxes;
        private Image[] PlayerImages;
        private Label[] txt_Count;
        private System.Timers.Timer time;

        private int Emptypos;
        private int paddingLeft = 40;
        private int paddingTop = 0;
        private int padding = 200;
        private int WindowWidth = 800;
        private int WindowHeight = 600;

        private int PicBoxesWidth = 0;
        private int PicBoxHeight = 0;
        private int second = 0;
        private int moveCount = 0;

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

            time = new System.Timers.Timer();
            time.Interval = 1000;
            time.Elapsed += Time_Elapsed;
        }

        private void Time_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            Invoke(new Action(() =>
            {
                second += 1;
                txt_Count[1].Text = second.ToString();
            }));
        }

        private void SliderPuzzle_Load(object sender, EventArgs e)
        {
            PicBoxes = new PictureBox[9];
            PlayerImages = new Image[9];
            txt_Count = new Label[4];
            for(int i =0;i<4;i++)
            {
                txt_Count[i] = new Label();
                txt_Count[i].Font = new Font("Microsoft Sans Serif", 16, FontStyle.Bold);
            }

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
            txt_Count[0].Text = "Time";
            txt_Count[0].Left = 670;
            txt_Count[0].Top = 50;
            txt_Count[1].Text = "0";
            txt_Count[1].Left = 685;
            txt_Count[1].Top = 100;
            txt_Count[2].Text = "Move";
            txt_Count[2].Left = 670;
            txt_Count[2].Top = 250;
            txt_Count[3].Text = "0";
            txt_Count[3].Left = 685;
            txt_Count[3].Top = 300;
            this.Controls.AddRange(PicBoxes);
            this.Controls.AddRange(txt_Count);
            LoadImageFromFile();
            NewGame();
            time.Start();
        }

        private void SliderPuzzle_Click(object sender, EventArgs e)
        {
            int selectedPicture = (int)(sender as PictureBox).Tag;

            switch (selectedPicture)
            {
                case 0:
                    if (Emptypos == 1 || Emptypos == 3)
                    {
                        int jValue = imageArr[0];
                        int kValue = imageArr[Emptypos];

                        imageArr[Emptypos] = jValue;
                        imageArr[0] = kValue;
                        Emptypos = 0;
                        UpdatePicBox();
                        moveCount++;
                    }
                    break;
                case 1:
                    if (Emptypos == 0 || Emptypos == 2 || Emptypos == 4)
                    {
                        int jValue = imageArr[1];
                        int kValue = imageArr[Emptypos];

                        imageArr[Emptypos] = jValue;
                        imageArr[1] = kValue;
                        Emptypos = 1;
                        moveCount++;
                        UpdatePicBox();
                    }
                    break;
                case 2:
                    if (Emptypos == 1 || Emptypos == 5)
                    {
                        int jValue = imageArr[2];
                        int kValue = imageArr[Emptypos];

                        imageArr[Emptypos] = jValue;
                        imageArr[2] = kValue;
                        Emptypos = 2;
                        moveCount++;
                        UpdatePicBox();
                    }
                    break;
                case 3:
                    if (Emptypos == 0 || Emptypos == 4 || Emptypos == 6)
                    {
                        int jValue = imageArr[3];
                        int kValue = imageArr[Emptypos];

                        imageArr[Emptypos] = jValue;
                        imageArr[3] = kValue;
                        Emptypos = 3;
                        moveCount++;
                        UpdatePicBox();
                    }
                    break;
                case 4:
                    if (Emptypos == 1 || Emptypos == 3 || Emptypos == 5 || Emptypos == 7)
                    {
                        int jValue = imageArr[4];
                        int kValue = imageArr[Emptypos];

                        imageArr[Emptypos] = jValue;
                        imageArr[4] = kValue;
                        Emptypos = 4;
                        moveCount++;
                        UpdatePicBox();
                    }
                    break;
                case 5:
                    if (Emptypos == 2 || Emptypos == 4 || Emptypos == 8)
                    {
                        int jValue = imageArr[5];
                        int kValue = imageArr[Emptypos];

                        imageArr[Emptypos] = jValue;
                        imageArr[5] = kValue;
                        Emptypos = 5;
                        moveCount++;
                        UpdatePicBox();
                    }
                    break;
                case 6:
                    if (Emptypos == 3 || Emptypos == 7)
                    {
                        int jValue = imageArr[6];
                        int kValue = imageArr[Emptypos];

                        imageArr[Emptypos] = jValue;
                        imageArr[6] = kValue;
                        Emptypos = 6;
                        moveCount++;
                        UpdatePicBox();
                    }
                    break;
                case 7:
                    if (Emptypos == 6 || Emptypos == 4 || Emptypos == 8)
                    {
                        int jValue = imageArr[7];
                        int kValue = imageArr[Emptypos];

                        imageArr[Emptypos] = jValue;
                        imageArr[7] = kValue;
                        Emptypos = 7;
                        moveCount++;
                        UpdatePicBox();
                    }
                    break;
                case 8:
                    if (Emptypos == 7 || Emptypos == 5)
                    {
                        int jValue = imageArr[8];
                        int kValue = imageArr[Emptypos];

                        imageArr[Emptypos] = jValue;
                        imageArr[8] = kValue;
                        Emptypos = 8;
                        moveCount++;
                        UpdatePicBox();
                    }
                    break;
            }
        }
        private void NewGame()
        {
            imageArr = (int[])Default.Clone();
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
            Emptypos = 8;
            second = 0;
            moveCount = 0;
            txt_Count[3].Text = moveCount.ToString();
        }
        private void UpdatePicBox()
        {
            for (int i = 0; i < 9; i++)
            {
                LoadImageToBox(i, imageArr[i]);
            }
            txt_Count[3].Text = moveCount.ToString();
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
            PlayerImages[8] = null;
        }
        private void EndGame()
        {
            if (isWinner())
            {
                for (int i = 0; i < 9; i++)
                {
                    LoadImageToBox(i, i);
                }
                PicBoxes[8].Image = Image.FromFile(CurrentDirectory + FolderName + @"\" + 8 + ".jpg");
                time.Stop();
                MessageBox.Show("You Win!!!");

            }
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

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewGame();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
