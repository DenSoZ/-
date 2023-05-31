using System.Linq;
using System.Net;
using System.Xml;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            Show = new Button();
            Cities = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            temp = new Label();
            wind = new Label();
            info = new Label();
            SuspendLayout();
            // 
            // Show
            // 
            Show.Location = new Point(87, 278);
            Show.Name = "Show";
            Show.Size = new Size(94, 29);
            Show.TabIndex = 0;
            Show.Text = "Show";
            Show.UseVisualStyleBackColor = true;
            Show.Click += Show_Click;
            // 
            // Cities
            // 
            Cities.FormattingEnabled = true;
            Cities.ImeMode = ImeMode.NoControl;
            Cities.Items.AddRange(new object[] { "Moscow", "London", "Kazan", "Rome" });
            Cities.Location = new Point(12, 12);
            Cities.Name = "Cities";
            Cities.Size = new Size(241, 28);
            Cities.TabIndex = 1;
            Cities.Text = "Choose city";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(304, 20);
            label1.Name = "label1";
            label1.Size = new Size(93, 20);
            label1.TabIndex = 2;
            label1.Text = "Temperature";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(304, 55);
            label2.Name = "label2";
            label2.Size = new Size(88, 20);
            label2.TabIndex = 3;
            label2.Text = "Wind speed";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(304, 95);
            label3.Name = "label3";
            label3.Size = new Size(85, 20);
            label3.TabIndex = 4;
            label3.Text = "Description";
            // 
            // temp
            // 
            temp.AutoSize = true;
            temp.Location = new Point(491, 20);
            temp.Name = "temp";
            temp.Size = new Size(0, 20);
            temp.TabIndex = 5;
            // 
            // wind
            // 
            wind.AutoSize = true;
            wind.Location = new Point(491, 55);
            wind.Name = "wind";
            wind.Size = new Size(0, 20);
            wind.TabIndex = 6;
            // 
            // info
            // 
            info.AutoSize = true;
            info.Location = new Point(491, 95);
            info.Name = "info";
            info.Size = new Size(0, 20);
            info.TabIndex = 7;
            // 
            // Form1
            // 
            ClientSize = new Size(644, 360);
            Controls.Add(info);
            Controls.Add(wind);
            Controls.Add(temp);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(Cities);
            Controls.Add(Show);
            Name = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Show_Click(object sender, EventArgs e)
        {

            string url = "http://api.openweathermap.org/data/2.5/weather?q=" + Cities.Text 
                + "&mode=xml&lang = ru&units=metric&appid=f23494bdbfbd2a463aa2d5e9e7fd5d37"; // Url с нужным городом и указанием параметров.


            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url); //—оздание запроса на сервер по нашему URL

            HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse(); //ѕолучение ответа с сервера



            using (StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream())) // функци€ дл€ записи ответа в строковую переменную
            {
                string response = streamReader.ReadToEnd();
                temp.Text = search(response, "temperature value=\"", "\" min=\"") + " ∞C";                    //вывод температуры
                wind.Text = search(response, "<speed value=\"", "\" unit=\"") + " m/s";                       //вывод скорости ветра
                info.Text = "Longitude: " + search(response, "<coord lon=\"", "\" lat=\"")                    //вывод долготы
                    + "\nLatitude: " + search(response, "\" lat=\"", "\"></coord>")                           //вывод широты
                    + "\nhumidity: " + search(response, "<humidity value=\"", "\" unit=\"%\">") + " %";       //вывод влажности

            };
        }
        private string search(string text, string start, string end) //функци€ дл€ поиска и вывода текста в строковой переменной
        {
            int first = text.IndexOf(start) + start.Length; //поиск индекса начала нужного текста
            int last = text.LastIndexOf(end);               //поиск индекса конца нужного текста
            return text.Substring(first, last - first);     //вывод нужного текста, где выражение "last - first" - это длина текста
        }                                                   
    }
}