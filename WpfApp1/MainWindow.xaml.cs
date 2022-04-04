using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {

        int size = 0;
        int incerement = 0;
        int incerement2 = 0;
        int rest = 9;
        int number;
        int FlagCountt;
        int resultt = 0;


        bool FlagVerif = false;
        bool GameOver = false;
        bool FirstClickVerif = false;
        bool ClickVerif = false;

        static int FirstIndex;

        Random random = new Random();

        List<int> selection = new List<int>();
        List<int> boomlist = new List<int>();
        List<int> NewBoomList = new List<int>();
        List<int> Numbers = new List<int>();
        List<int> lastFlag = new List<int>();
        List<int> lastClick = new List<int>();


        DispatcherTimer dispatcherTimer = new DispatcherTimer();
        DispatcherTimer dispatcherTimer1 = new DispatcherTimer();


        public MainWindow()
        {
            InitializeComponent();
            AddLastFlag();
            AddLastClick();
            Button_Dizilis();
            Other.Width = 0;
        }


        class Button
        {
            public int Width { get; internal set; }
            public int Height { get; internal set; }
        }





        public void TimeBar()
        {
            dispatcherTimer.Interval = TimeSpan.FromSeconds(1);
            dispatcherTimer.Tick += DispatcherTimer_Tick;
            dispatcherTimer.Start();
        }

        private void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            incerement++;

            if(GameOver == false)
            {
                if(incerement == 999)
                {
                    incerement = 0;
                }

                if(incerement < 10)
                {
                    Time.Text = "00" + incerement.ToString();
                }
                else if (incerement < 99)
                {
                    Time.Text = "0" + incerement.ToString();
                }
                else
                {
                    Time.Text = incerement.ToString();
                }
            }
            else
            {
                dispatcherTimer.Stop();
                incerement = 0;
            }
        }






        private void FirstClick(object sender, MouseButtonEventArgs e)
        {
            int index = -1;
            index = list.SelectedIndex;

            if (FirstClickVerif == false && index != -1 && lastFlag[index] != 1)
            {

                lastClick[index] = 1;


                FirstIndex = list.SelectedIndex;

                selection.Add(FirstIndex);

                FirstClickVerif = true;
                Button_Dizilis();
                ClickVerif = true;
                FlagVerif = true;
                size++;

                TimeBar();
            }
            else if (ClickVerif == true)
            {
                FirstIndex = list.SelectedIndex;

                Click(FirstIndex);

            }
        }



        public void Rakam_Dizilisi()
        {

            for (int i = 0; i < boomlist.Count; i++)
            {
                int index = list.SelectedIndex;
                list.Items.Remove(i);

                NoClickButtonUserControl noClickButtonUserControl = new NoClickButtonUserControl();


                if (boomlist[i] == 2)
                {
                    NewBoomList.Add(2);
                    Numbers.Add(0);
                    continue;
                }
                else if(boomlist[i] != 1)
                {
                    if (i == 0)
                    {
                        if (boomlist[i + 1] == 1) number += 1;
                        if (boomlist[i + 10] == 1) number += 1;
                        if (boomlist[i + 11] == 1) number += 1;
                    }
                    else if(i > 0 && i <= 8)
                    {
                        if (boomlist[i + 1] == 1) number += 1;
                        if (boomlist[i - 1] == 1) number += 1;
                        if (boomlist[i + 9] == 1) number += 1;
                        if (boomlist[i + 10] == 1) number += 1;
                        if (boomlist[i + 11] == 1) number += 1;
                    }
                    else if(i == 9)
                    {
                        if (boomlist[i - 1] == 1) number += 1;
                        if (boomlist[i + 9] == 1) number += 1;
                        if (boomlist[i + 10] == 1) number += 1;
                    }
                    else if(i == 10 || i == 20 || i == 30 || i == 40 || i == 50 || i == 60)
                    {
                        if (boomlist[i + 1] == 1) number += 1;
                        if (boomlist[i - 9] == 1) number += 1;
                        if (boomlist[i - 10] == 1) number += 1;
                        if (boomlist[i + 10] == 1) number += 1;
                        if (boomlist[i + 11] == 1) number += 1;
                    }
                    else if (i == 19 || i == 29 || i == 39 || i == 49 || i == 59 || i == 69)
                    {
                        if (boomlist[i - 1] == 1) number += 1;
                        if (boomlist[i - 10] == 1) number += 1;
                        if (boomlist[i - 11] == 1) number += 1;
                        if (boomlist[i + 9] == 1) number += 1;
                        if (boomlist[i + 10] == 1) number += 1;
                    }
                    else if(i >= 11 && i <= 18 || i >= 21 && i <= 28 || i >= 31 && i <= 38 || i >= 41 && i <= 48 || i >= 51 && i <= 58 || i >= 61 && i <= 68)
                    {
                        if (boomlist[i + 1] == 1) number += 1;
                        if (boomlist[i - 1] == 1) number += 1;
                        if (boomlist[i - 9] == 1) number += 1;
                        if (boomlist[i - 10] == 1) number += 1;
                        if (boomlist[i - 11] == 1) number += 1;
                        if (boomlist[i + 9] == 1) number += 1;
                        if (boomlist[i + 10] == 1) number += 1;
                        if (boomlist[i + 11] == 1) number += 1;
                    }
                    else if(i == 70)
                    {
                        if (boomlist[i + 1] == 1) number += 1;
                        if (boomlist[i - 9] == 1) number += 1;
                        if (boomlist[i - 10] == 1) number += 1;
                    }
                    else if (i == 79)
                    {
                        if (boomlist[i - 1] == 1) number += 1;
                        if (boomlist[i - 10] == 1) number += 1;
                        if (boomlist[i - 11] == 1) number += 1;
                    }
                    else if(i >= 71 && i <= 78)
                    {
                        if (boomlist[i - 1] == 1) number += 1;
                        if (boomlist[i + 1] == 1) number += 1;
                        if (boomlist[i - 9] == 1) number += 1;
                        if (boomlist[i - 10] == 1) number += 1;
                        if (boomlist[i - 11] == 1) number += 1;

                    }
                }
                else
                {
                    NewBoomList.Add(1);
                    Numbers.Add(0);
                    continue;
                }


                if(number == 0)
                {
                    NewBoomList.Add(3);
                    Numbers.Add(0);
                }
                else
                {
                    NewBoomList.Add(0);
                    Numbers.Add(number);

                }

                list.Items[i] = noClickButtonUserControl;


                number = 0;
            }



            NextCell(FirstIndex);


        }


        public void Click(int index)
        {
            
            if (boomlist[index] != 1 && NewBoomList[index] != 3)
            {

                if (lastClick[FirstIndex] == 0 && lastFlag[index] != 1)
                {

                    ButtonStyle buttonStyle = new ButtonStyle();
                    buttonStyle.Name.Text = Numbers[FirstIndex].ToString();
                    list.Items[FirstIndex] = buttonStyle;
                    lastClick[FirstIndex] = 1;
                    size++;

                }


            }
            else if(NewBoomList[index] == 3)
            {
                ButtonStyle buttonStyle = new ButtonStyle();
                buttonStyle.Name.Text = "";
                list.Items[index] = buttonStyle;
                NextCell(index);
            }
            else if(boomlist[index] == 1)
            {

                if (lastClick[index] == 0 && lastFlag[index] != 1)
                {
                    GameOver = true;
                    Bomblist();

                    dispatcherTimer1.Interval = TimeSpan.FromSeconds(1);
                    dispatcherTimer1.Tick += DispatcherTimer1_Tick;
                    dispatcherTimer1.Start();

                }

            }
            
        }

        private void DispatcherTimer1_Tick(object sender, EventArgs e)
        {
            incerement2++;

            if(incerement2 != 1)
            {
                Bomblist();
            }
            else
            {
                dispatcherTimer1.Stop();
                Rest();
            }
        }


        public void Bomblist()
        {
            for (int i = 0; i < boomlist.Count; i++)
            {
                if(boomlist[i] == 1)
                {
                    BooMUserControl booMUserControl = new BooMUserControl();
                    list.Items[i] = booMUserControl;
                }
            }
        }




        public void NextCell(int index)
        {

            int startIndex = index - 10 - 1;

            ButtonStyle buttonStyle1 = new ButtonStyle();
            ButtonStyle buttonStyle2 = new ButtonStyle();
            ButtonStyle buttonStyle3 = new ButtonStyle();
            ButtonStyle buttonStyle4 = new ButtonStyle();
            ButtonStyle buttonStyle5 = new ButtonStyle();
            ButtonStyle buttonStyle6 = new ButtonStyle();
            ButtonStyle buttonStyle7 = new ButtonStyle();
            ButtonStyle buttonStyle8 = new ButtonStyle();


            if (index == 0)
            {
                if (boomlist[index + 1] != 1 && NewBoomList[index + 1] != 3)
                {
                    buttonStyle1.Name.Text = Numbers[index + 1].ToString();
                    list.Items[index + 1] = buttonStyle1;
                    lastClick[index + 1] = 1;
                    size++;
                }
                if (boomlist[index + 10] != 1 && NewBoomList[index + 10] != 3)
                {
                    buttonStyle2.Name.Text = Numbers[index + 10].ToString();
                    list.Items[index + 10] = buttonStyle2;
                    lastClick[index + 10] = 1;
                    size++;

                }
                if (boomlist[index + 11] != 1 && NewBoomList[index + 11] != 3)
                {
                    buttonStyle3.Name.Text = Numbers[index + 11].ToString();
                    list.Items[index + 11] = buttonStyle3;
                    lastClick[index + 11] = 1;
                    size++;

                }
            }
            else if(index == 9)
            {
                if (boomlist[index - 1] != 1 && NewBoomList[index - 1] != 3)
                {
                    buttonStyle1.Name.Text = Numbers[index - 1].ToString();
                    list.Items[index - 1] = buttonStyle1;
                    lastClick[index - 1] = 1;
                    size++;

                }
                if (boomlist[index + 9] != 1 && NewBoomList[index + 9] != 3)
                {
                    buttonStyle2.Name.Text = Numbers[index + 9].ToString();
                    list.Items[index + 9] = buttonStyle2;
                    lastClick[index + 9] = 1;
                    size++;

                }
                if (boomlist[index + 10] != 1 && NewBoomList[index + 10] != 3)
                {
                    buttonStyle3.Name.Text = Numbers[index + 10].ToString();
                    list.Items[index + 10] = buttonStyle3;
                    lastClick[index + 10] = 1;
                    size++;

                }
            }
            else if(index == 70)
            {
                if (boomlist[index + 1] != 1 && NewBoomList[index + 1] != 3)
                {
                    buttonStyle1.Name.Text = Numbers[index + 1].ToString();
                    list.Items[index + 1] = buttonStyle1;
                    lastClick[index + 1] = 1;
                    size++;

                }
                if (boomlist[index - 9] != 1 && NewBoomList[index - 9] != 3)
                {
                    buttonStyle2.Name.Text = Numbers[index - 9].ToString();
                    list.Items[index - 9] = buttonStyle2;
                    lastClick[index - 9] = 1;
                    size++;

                }
                if (boomlist[index - 10] != 1 && NewBoomList[index - 10] != 3)
                {
                    buttonStyle3.Name.Text = Numbers[index - 10].ToString();
                    list.Items[index - 10] = buttonStyle3;
                    lastClick[index - 10] = 1;
                    size++;

                }
            }
            else if (index == 79)
            {
                if (boomlist[index - 1] != 1 && NewBoomList[index - 1] != 3)
                {
                    buttonStyle1.Name.Text = Numbers[index - 1].ToString();
                    list.Items[index - 1] = buttonStyle1;
                    lastClick[index - 1] = 1;
                    size++;

                }
                if (boomlist[index - 10] != 1 && NewBoomList[index - 10] != 3)
                {
                    buttonStyle2.Name.Text = Numbers[index - 10].ToString();
                    list.Items[index - 10] = buttonStyle2;
                    lastClick[index - 10] = 1;
                    size++;

                }
                if (boomlist[index - 11] != 1 && NewBoomList[index - 11] != 3)
                {
                    buttonStyle3.Name.Text = Numbers[index - 11].ToString();
                    list.Items[index - 11] = buttonStyle3;
                    lastClick[index - 11] = 1;
                    size++;

                }
            }
            else if (index > 0 && index <= 8)
            {
                if(boomlist[index + 1] != 1 && NewBoomList[index + 1] != 3)
                {
                    buttonStyle1.Name.Text = Numbers[index + 1].ToString();
                    list.Items[index + 1] = buttonStyle1;
                    lastClick[index + 1] = 1;
                    size++;

                }
                if (boomlist[index - 1] != 1 && NewBoomList[index - 1] != 3)
                {
                    buttonStyle4.Name.Text = Numbers[index - 1].ToString();
                    list.Items[index - 1] = buttonStyle4;
                    lastClick[index - 1] = 1;
                    size++;

                }
                if (boomlist[index + 9] != 1 && NewBoomList[index + 9] != 3)
                {
                    buttonStyle5.Name.Text = Numbers[index + 9].ToString();
                    list.Items[index + 9] = buttonStyle5;
                    lastClick[index + 9] = 1;
                    size++;

                }
                if (boomlist[index + 10] != 1 && NewBoomList[index + 10] != 3)
                {
                    buttonStyle2.Name.Text = Numbers[index + 10].ToString();
                    list.Items[index + 10] = buttonStyle2;
                    lastClick[index + 10] = 1;
                    size++;

                }
                if (boomlist[index + 11] != 1 && NewBoomList[index + 11] != 3)
                {
                    buttonStyle3.Name.Text = Numbers[index + 11].ToString();
                    list.Items[index + 11] = buttonStyle3;
                    lastClick[index + 11] = 1;
                    size++;

                }
            }
            else if(index >= 11 && index <= 18 || index >= 21 && index <= 28 || index >= 31 && index <= 38 || index >= 41 && index <= 48 || index >= 51 && index <= 58 || index >= 61 && index <= 68)
            {
                if(boomlist[index + 1] != 1 && NewBoomList[index + 1] != 3)
                {
                    buttonStyle1.Name.Text = Numbers[index + 1].ToString();
                    list.Items[index + 1] = buttonStyle1;
                    lastClick[index + 1] = 1;
                    size++;

                }
                if (boomlist[index - 1] != 1 && NewBoomList[index - 1] != 3)
                {
                    buttonStyle2.Name.Text = Numbers[index - 1].ToString();
                    list.Items[index - 1] = buttonStyle2;
                    lastClick[index - 1] = 1;
                    size++;

                }
                if (boomlist[index + 9] != 1 && NewBoomList[index + 9] != 3)
                {
                    buttonStyle3.Name.Text = Numbers[index + 9].ToString();
                    list.Items[index + 9] = buttonStyle3;
                    lastClick[index + 9] = 1;
                    size++;

                }
                if (boomlist[index + 10] != 1 && NewBoomList[index + 10] != 3)
                {
                    buttonStyle4.Name.Text = Numbers[index + 10].ToString();
                    list.Items[index + 10] = buttonStyle4;
                    lastClick[index + 10] = 1;
                    size++;

                }
                if (boomlist[index + 11] != 1 && NewBoomList[index + 11] != 3)
                {
                    buttonStyle5.Name.Text = Numbers[index + 11].ToString();
                    list.Items[index + 11] = buttonStyle5;
                    lastClick[index + 11] = 1;
                    size++;

                }
                if (boomlist[index - 9] != 1 && NewBoomList[index - 9] != 3)
                {
                    buttonStyle6.Name.Text = Numbers[index - 9].ToString();
                    list.Items[index - 9] = buttonStyle6;
                    lastClick[index - 9] = 1;
                    size++;

                }
                if (boomlist[index - 10] != 1 && NewBoomList[index - 10] != 3)
                {
                    buttonStyle7.Name.Text = Numbers[index - 10].ToString();
                    list.Items[index - 10] = buttonStyle7;
                    lastClick[index - 10] = 1;
                    size++;

                }
                if (boomlist[index - 11] != 1 && NewBoomList[index - 11] != 3)
                {
                    buttonStyle8.Name.Text = Numbers[index - 11].ToString();
                    list.Items[index - 11] = buttonStyle8;
                    lastClick[index - 11] = 1;
                    size++;

                }
            }
            else if(index == 10 || index == 20 || index == 30 || index == 40 || index == 50 || index == 60)
            {
                if (boomlist[index + 1] != 1 && NewBoomList[index + 1] != 3)
                {
                    buttonStyle1.Name.Text = Numbers[index + 1].ToString();
                    list.Items[index + 1] = buttonStyle1;
                    lastClick[index + 1] = 1;
                    size++;

                }
                if (boomlist[index - 9] != 1 && NewBoomList[index - 9] != 3)
                {
                    buttonStyle2.Name.Text = Numbers[index - 9].ToString();
                    list.Items[index - 9] = buttonStyle2;
                    lastClick[index - 9] = 1;
                    size++;

                }
                if (boomlist[index - 10] != 1 && NewBoomList[index - 10] != 3)
                {
                    buttonStyle3.Name.Text = Numbers[index - 10].ToString();
                    list.Items[index - 10] = buttonStyle3;
                    lastClick[index - 10] = 1;
                    size++;

                }
                if (boomlist[index + 10] != 1 && NewBoomList[index + 10] != 3)
                {
                    buttonStyle4.Name.Text = Numbers[index + 10].ToString();
                    list.Items[index + 10] = buttonStyle4;
                    lastClick[index + 10] = 1;
                    size++;

                }
                if (boomlist[index + 11] != 1 && NewBoomList[index + 11] != 3)
                {
                    buttonStyle5.Name.Text = Numbers[index + 11].ToString();
                    list.Items[index + 11] = buttonStyle5;
                    lastClick[index + 11] = 1;
                    size++;

                }
            }
            else if (index >= 71 && index <= 78)
            {
                if (boomlist[index + 1] != 1 && NewBoomList[index + 1] != 3)
                {
                    buttonStyle1.Name.Text = Numbers[index + 1].ToString();
                    list.Items[index + 1] = buttonStyle1;
                    lastClick[index + 1] = 1;
                    size++;

                }
                if (boomlist[index + 1] != 1 && NewBoomList[index + 1] != 3)
                {
                    buttonStyle2.Name.Text = Numbers[index - 1].ToString();
                    list.Items[index - 1] = buttonStyle2;
                    lastClick[index - 1] = 1;
                    size++;

                }
                if (boomlist[index - 9] != 1 && NewBoomList[index - 9] != 3)
                {
                    buttonStyle3.Name.Text = Numbers[index - 9].ToString();
                    list.Items[index - 9] = buttonStyle3;
                    lastClick[index - 9] = 1;
                    size++;

                }
                if (boomlist[index - 10] != 1 && NewBoomList[index - 10] != 3)
                {
                    buttonStyle4.Name.Text = Numbers[index - 10].ToString();
                    list.Items[index - 10] = buttonStyle4;
                    lastClick[index - 10] = 1;
                    size++;

                }
                if (boomlist[index - 11] != 1 && NewBoomList[index - 11] != 3)
                {
                    buttonStyle5.Name.Text = Numbers[index - 11].ToString();
                    list.Items[index - 11] = buttonStyle5;
                    lastClick[index - 11] = 1;
                    size++;

                }
            }
            else if (index >= 19 && index <= 69) 
            {
                if (boomlist[index - 1] != 1 && NewBoomList[index - 1] != 3)
                {
                    buttonStyle1.Name.Text = Numbers[index - 1].ToString();
                    list.Items[index - 1] = buttonStyle1;
                    lastClick[index - 1] = 1;
                    size++;

                }
                if (boomlist[index - 10] != 1 && NewBoomList[index - 10] != 3)
                {
                    buttonStyle2.Name.Text = Numbers[index - 10].ToString();
                    list.Items[index - 10] = buttonStyle2;
                    lastClick[index - 10] = 1;
                    size++;

                }
                if (boomlist[index - 11] != 1 && NewBoomList[index - 11] != 3)
                {
                    buttonStyle3.Name.Text = Numbers[index - 11].ToString();
                    list.Items[index - 11] = buttonStyle3;
                    lastClick[index - 11] = 1;
                    size++;

                }
                if (boomlist[index + 9] != 1 && NewBoomList[index + 9] != 3)
                {
                    buttonStyle4.Name.Text = Numbers[index + 9].ToString();
                    list.Items[index + 9] = buttonStyle4;
                    lastClick[index + 9] = 1;
                    size++;

                }
                if (boomlist[index + 10] != 1 && NewBoomList[index + 10] != 3)
                {
                    buttonStyle5.Name.Text = Numbers[index + 10].ToString();
                    list.Items[index + 10] = buttonStyle5;
                    lastClick[index + 10] = 1;
                    size++;

                }
            }

        }



        public void Button_Dizilis()
        {

            if(FirstClickVerif == true)
            {

                list.Items.Clear();

                for (int i = 0; i < 80; i++)
                {

                    ButtonStyle buttonStyle = new ButtonStyle();
                    NoClickButtonUserControl noClickButtonUserControl = new NoClickButtonUserControl();

                    if (selection[0] == i)
                    {
                        list.Items.Add(buttonStyle);
                        boomlist.Add(2);
                    }
                    else
                    {
                        Button_Bomb();
                        list.Items.Add(noClickButtonUserControl);
                    }

                }

                Rakam_Dizilisi();

                //for (int i = 0; i < lastFlag.Count; i++)
                //{
                //    if(lastFlag[i] == 1)
                //    {
                //        FlagUserControl flagUserControl = new FlagUserControl();
                //        list.Items[i] = flagUserControl;
                //    }
                //}

                FlagCount.Text = "x" + FlagCountt.ToString();
                resultt = NewBoomList.Count - FlagCountt;

            }
            else
            {
                for (int i = 0; i < 80; i++)
                {
                    NoClickButtonUserControl noClickButtonUserControl = new NoClickButtonUserControl();
                    list.Items.Add(noClickButtonUserControl);
                }
            }
        }




        public void Button_Bomb()
        {
            int RANDOM = random.Next(0, 80);

            if (RANDOM > 40)
            {
                boomlist.Add(1);
                FlagCountt++;
            }
            else
            {
                boomlist.Add(0);
            }


        }





        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try { DragMove(); }
            catch (Exception) { throw; }
        }




        public void AddLastFlag()
        {
            for (int i = 0; i < 80; i++)
            {
                lastFlag.Add(0);
            }
        }


        public void AddLastClick()
        {
            for (int i = 0; i < 80; i++)
            {
                lastClick.Add(0);
            }
        }


        private void list_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {

            if (FlagCountt == 1 && size == resultt)
            {
                Rest();

            }
            else if(FlagVerif == true)
            {
                int index = list.SelectedIndex;

                if (lastFlag[index] == 0 && lastClick[index] == 0)
                {
                    FlagUserControl flagUserControl = new FlagUserControl();
                    list.Items.Remove(index);
                    list.Items[index] = flagUserControl;
                    lastFlag[index] = 1;
                    FlagCountt--;
                    FlagCount.Text = "x" + FlagCountt;
                }
                else if (lastClick[index] != 1)
                {
                    lastFlag[index] = 0;
                    NoClickButtonUserControl noClickButtonUserControl = new NoClickButtonUserControl();
                    list.Items.Remove(index);
                    list.Items[index] = noClickButtonUserControl;
                    FlagCountt++;
                    FlagCount.Text = "x" + FlagCountt;
                }
            }

            
        }

        private void Image_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("a");
        }

        private void Refresh(object sender, RoutedEventArgs e)
        {

            list.Items.Clear();

            rest = 9;
            number = 0;
            size = 0;

            FlagVerif = false;
            GameOver = false;
            FirstClickVerif = false;
            ClickVerif = false;
            
            selection.Clear();
            boomlist.Clear();
            NewBoomList.Clear();
            Numbers.Clear();
            lastFlag.Clear();
            lastClick.Clear();

            FirstIndex = 0;

            dispatcherTimer.Stop();
            Time.Text = "000";
            incerement = 0;
            incerement2 = 0;

            FlagCount.Text = "x0";

            DispatcherTimer dispatcherTimerNew = new DispatcherTimer();
            dispatcherTimer = dispatcherTimerNew;

            DispatcherTimer dispatcherTimerNew1 = new DispatcherTimer();
            dispatcherTimer1 = dispatcherTimerNew1;

            AddLastFlag();
            AddLastClick();
            Button_Dizilis();

            FlagCountt = 0;

            NewOther.Width = 0;
        }


        public void Rest()
        {
            list.Items.Clear();

            rest = 9;
            number = 0;
            size = 0;

            FlagVerif = false;
            GameOver = false;
            FirstClickVerif = false;
            ClickVerif = false;

            selection.Clear();
            boomlist.Clear();
            NewBoomList.Clear();
            Numbers.Clear();
            lastFlag.Clear();
            lastClick.Clear();

            FirstIndex = 0;

            dispatcherTimer.Stop();
            Time.Text = "000";
            incerement = 0;
            incerement2 = 0;

            FlagCount.Text = "x0";

            DispatcherTimer dispatcherTimerNew = new DispatcherTimer();
            dispatcherTimer = dispatcherTimerNew;

            DispatcherTimer dispatcherTimerNew1 = new DispatcherTimer();
            dispatcherTimer1 = dispatcherTimerNew1;

            AddLastFlag();
            AddLastClick();
            Button_Dizilis();

            FlagCountt = 0;


            NewOther.Width = 0;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
