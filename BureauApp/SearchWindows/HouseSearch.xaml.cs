using System;
using System.Windows;
using System.Windows.Controls;

namespace BureauApp.SearchWindows
{
    /// <summary>
    /// Логика взаимодействия для HouseSearch.xaml
    /// </summary>
    public partial class HouseSearch : Window
    {
        public HouseSearch()
        {
            InitializeComponent();
        }

        private void DoSearch_btn_Click(object sender, RoutedEventArgs e)
        {
            Scroll.ScrollToEnd();
            Query query = new Query();
            if (query.Conn.State == System.Data.ConnectionState.Closed)
                query.Conn.Open();

            FillSearchSqlQuery.FillHouseSearch(query, this);
            FillTables.FillTableHouse(query, SearchResult);

        }

        private void Exp_btn_Click(object sender, RoutedEventArgs e)
        {
            Menu.Export(SearchResult);
        }
        private void house_number_low_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (house_number_low.Text != string.Empty)
                house_number_sldr.LowerValue = Convert.ToDouble(house_number_low.Text);
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message + "Пример заполненного поля: 48,5.");
            }

        }

        private void house_number_high_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (house_number_high.Text != string.Empty)
                    house_number_sldr.HigherValue = Convert.ToDouble(house_number_high.Text);
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message+"Пример заполненного поля: 48,5.");
            }
        }

        private void house_number_sldr_LowerValueChanged(object sender, RoutedEventArgs e)
        {
            house_number_low.Text = Convert.ToInt32(house_number_sldr.LowerValue).ToString();
        }

        private void house_number_sldr_HigherValueChanged(object sender, RoutedEventArgs e)
        {
            house_number_high.Text = Convert.ToInt32(house_number_sldr.HigherValue).ToString();
        }

        private void line_low_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (line_low.Text != string.Empty)
                    line_sldr.LowerValue = Convert.ToDouble(line_low.Text);
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message + "Пример заполненного поля: 48,5.");
            }
        }

        private void line_high_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (line_high.Text != string.Empty)
                    line_sldr.HigherValue = Convert.ToDouble(line_high.Text);
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message + "Пример заполненного поля: 48,5.");
            }
        }

        private void line_sldr_LowerValueChanged(object sender, RoutedEventArgs e)
        {
            line_low.Text = (Math.Round(Convert.ToDouble(line_sldr.LowerValue),2)).ToString();
        }

        private void line_sldr_HigherValueChanged(object sender, RoutedEventArgs e)
        {
            line_high.Text = (Math.Round(Convert.ToDouble(line_sldr.HigherValue), 2)).ToString();
        }

        private void year_low_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (year_low.Text != string.Empty)
                    year_sldr.LowerValue = Convert.ToDouble(year_low.Text);
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message + "Пример заполненного поля: 48,5.");
            }
        }

        private void year_high_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (year_high.Text != string.Empty)
                    year_sldr.HigherValue = Convert.ToDouble(year_high.Text);
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message + "Пример заполненного поля: 48,5.");
            }
        }

        private void year_sldr_LowerValueChanged(object sender, RoutedEventArgs e)
        {
            year_low.Text = Convert.ToInt32(year_sldr.LowerValue).ToString();
        }

        private void year_sldr_HigherValueChanged(object sender, RoutedEventArgs e)
        {
            year_high.Text = Convert.ToInt32(year_sldr.HigherValue).ToString();
        }

        private void wear_low_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (wear_low.Text != string.Empty)
                wear_sldr.LowerValue = Convert.ToDouble(wear_low.Text);
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message + "Пример заполненного поля: 48,5.");
            }
        }

        private void wear_high_TextChanged(object sender, TextChangedEventArgs e)
        {
                try
                {
                    if (wear_high.Text != string.Empty)
                wear_sldr.HigherValue = Convert.ToDouble(wear_high.Text);
                }
                catch (FormatException ex)
                {
                    MessageBox.Show(ex.Message + "Пример заполненного поля: 48,5.");
                }
        }

        private void wear_sldr_LowerValueChanged(object sender, RoutedEventArgs e)
        {
            wear_low.Text = Convert.ToInt32(wear_sldr.LowerValue).ToString();
        }

        private void wear_sldr_HigherValueChanged(object sender, RoutedEventArgs e)
        {
            wear_high.Text = Convert.ToInt32(wear_sldr.HigherValue).ToString();
        }

        private void land_low_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (land_low.Text != string.Empty)
                land_sldr.LowerValue = Convert.ToDouble(land_low.Text);
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message + "Пример заполненного поля: 48,5.");
            }
        }

        private void land_high_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (land_high.Text != string.Empty)
                land_sldr.HigherValue = Convert.ToDouble(land_high.Text);
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message + "Пример заполненного поля: 48,5.");
            }
        }

        private void land_sldr_LowerValueChanged(object sender, RoutedEventArgs e)
        {
            land_low.Text = Convert.ToInt32(land_sldr.LowerValue).ToString();
        }

        private void land_sldr_HigherValueChanged(object sender, RoutedEventArgs e)
        {
            land_high.Text = Convert.ToInt32(land_sldr.HigherValue).ToString();
        }

        private void square_low_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (square_low.Text != string.Empty)
                square_sldr.LowerValue = Convert.ToDouble(square_low.Text);
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message + "Пример заполненного поля: 48,5.");
            }
        }

        private void square_high_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (square_high.Text != string.Empty)
                square_sldr.HigherValue = Convert.ToDouble(square_high.Text);
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message + "Пример заполненного поля: 48,5.");
            }
        }

        private void square_sldr_LowerValueChanged(object sender, RoutedEventArgs e)
        {
            square_low.Text = Convert.ToInt32(square_sldr.LowerValue).ToString();
        }

        private void square_sldr_HigherValueChanged(object sender, RoutedEventArgs e)
        {
            square_high.Text = Convert.ToInt32(square_sldr.HigherValue).ToString();
        }

        private void flow_low_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (flow_low.Text != string.Empty)
                    flow_sldr.LowerValue = Convert.ToDouble(flow_low.Text);
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message + "Пример заполненного поля: 48,5.");
            }
        }

        private void flow_high_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (flow_high.Text != string.Empty)
                flow_sldr.HigherValue = Convert.ToDouble(flow_high.Text);
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message + "Пример заполненного поля: 48,5.");
            }
        }

        private void flow_sldr_LowerValueChanged(object sender, RoutedEventArgs e)
        {
            flow_low.Text = Convert.ToInt32(flow_sldr.LowerValue).ToString();
        }

        private void flow_sldr_HigherValueChanged(object sender, RoutedEventArgs e)
        {
            flow_high.Text = Convert.ToInt32(flow_sldr.HigherValue).ToString();
        }

        private void hall_low_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (hall_high.Text != string.Empty)
                hall_sldr.LowerValue = Convert.ToDouble(hall_low.Text);
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message + "Пример заполненного поля: 48,5.");
            }
        }

        private void hall_high_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (hall_high.Text != string.Empty)
                    hall_sldr.HigherValue = Convert.ToDouble(hall_high.Text);
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message + "Пример заполненного поля: 48,5.");
            }
}

        private void hall_sldr_LowerValueChanged(object sender, RoutedEventArgs e)
        {
            hall_low.Text = Convert.ToInt32(hall_sldr.LowerValue).ToString();
        }

        private void hall_sldr_HigherValueChanged(object sender, RoutedEventArgs e)
        {
            hall_high.Text = Convert.ToInt32(hall_sldr.HigherValue).ToString();
        }
    }
}
