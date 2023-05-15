using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace Рыбалка.Pages
{
    /// <summary>
    /// Логика взаимодействия для ClientPage.xaml
    /// </summary>
    public partial class ClientPage : Page
    {
        MainWindow mainWindow;
        public ClientPage(MainWindow _mainWindow)
        {
            InitializeComponent();
            mainWindow = _mainWindow;
            LoadProduct(mainWindow.products);
        }


        public void LoadProduct(List<Classes.Products> products)
        {
            countInList.Content = "";
            int countForLabel = 0;
            parrent.Children.Clear();
            BrushConverter bc = new BrushConverter();
            for (int i=0; i<products.Count; i++)
            {
                
                Grid grid_parrent = new Grid();
                grid_parrent.Margin=new Thickness(10,0,10,0);
                grid_parrent.Height = 250;
                grid_parrent.Background= (Brush)bc.ConvertFrom("#ffffff");

                Grid line = new Grid();
                line.VerticalAlignment = VerticalAlignment.Bottom;
                line.Background = (Brush)bc.ConvertFrom("#FF498C51");
                line.Height = 3;

                if (Convert.ToInt32(products[i].count) == 0)
                {
                    grid_parrent.Background = (Brush)bc.ConvertFrom("#808080");
                }

                Image img=new Image();
                if (products[i].img != "")
                {
                    img.Height = 170;
                    img.Width = 170;
                    img.VerticalAlignment = VerticalAlignment.Center;
                    img.HorizontalAlignment= HorizontalAlignment.Left;
                    img.Margin=new Thickness(13,0,0,0);
                    img.Source = new BitmapImage(new Uri(mainWindow.localPath + @"\Images\" + products[i].img));
                }
                else
                {
                    img.Height = 170;
                    img.Width = 170;
                    img.VerticalAlignment = VerticalAlignment.Center;
                    img.HorizontalAlignment = HorizontalAlignment.Left;
                    img.Margin = new Thickness(13, 0, 0, 0);
                    img.Source = new BitmapImage(new Uri(mainWindow.localPath + @"\Images\picture.png"));
                }

                Label name=new Label();
                name.HorizontalAlignment= HorizontalAlignment.Left;
                name.Margin=new Thickness(220,20,0,0);
                name.Content = products[i].name;
                name.FontFamily = new FontFamily("Comic Sans MS");
                name.FontSize = 21;

                grid_parrent.Children.Add(line);
                grid_parrent.Children.Add(img);
                grid_parrent.Children.Add(name);

                parrent.Children.Add(grid_parrent);
                countForLabel++;
            }

            countInList.Content = countForLabel+"/"+mainWindow.products.Count;
        }

        private void sorting(object sender, TextChangedEventArgs e)
        {
            if (search.Text == "")
            {
                LoadProduct(mainWindow.products);
            }
            else if(search.Text !="")
            {
                List<Classes.Products> products = new List<Classes.Products>(); 
                products=mainWindow.products.FindAll(x=>x.name.ToLower().Contains(search.Text.ToLower())||x.description.ToLower().Contains(search.Text.ToLower()) || x.postavschik.ToLower().Contains(search.Text.ToLower()));
                LoadProduct(products);
            }
        }
    }
}
