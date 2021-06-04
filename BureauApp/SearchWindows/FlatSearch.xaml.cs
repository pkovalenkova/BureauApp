using System;
using System.Windows;
using System.Windows.Controls;

namespace BureauApp.SearchWindows
{
    /// <summary>
    /// Логика взаимодействия для FlatSearch.xaml
    /// </summary>
    public partial class FlatSearch : Window
    {
        public FlatSearch()
        {
            InitializeComponent();
        }
        private void DoSearch_btn_Click(object sender, RoutedEventArgs e)
        {
            Scroll.ScrollToEnd();
            Query query = new Query();
            if (query.Conn.State == System.Data.ConnectionState.Closed)
                query.Conn.Open();

            FillSearchSqlQuery.FillFlatSearch(query, this);
            FillTables.FillTableFlats(query, SearchResult);

        }
        private void Exp_btn_Click(object sender, RoutedEventArgs e)
        {
            Menu.Export(SearchResult);
        }
        private void flat_number_low_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (flat_number_low.Text != string.Empty)
                    flat_number_sldr.LowerValue = Convert.ToDouble(flat_number_low.Text);
            }
            catch (System.FormatException ex)
            {
                MessageBox.Show(ex.Message + "Пример заполненного поля: 48,5.");
            }
        }
        private void flat_number_high_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (flat_number_high.Text != string.Empty)
                    flat_number_sldr.HigherValue = Convert.ToDouble(flat_number_high.Text);
            }
            catch (System.FormatException ex)
            {
                MessageBox.Show(ex.Message + "Пример заполненного поля: 48,5.");
            }
        }
        private void flat_number_sldr_LowerValueChanged(object sender, RoutedEventArgs e)
        {
            flat_number_low.Text = Convert.ToInt32(flat_number_sldr.LowerValue).ToString();
        }

        private void flat_number_sldr_HigherValueChanged(object sender, RoutedEventArgs e)
        {
            flat_number_high.Text = Convert.ToInt32(flat_number_sldr.HigherValue).ToString();
        }
        private void storey_low_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (storey_low.Text != string.Empty)
                    storey_sldr.LowerValue = Convert.ToDouble(storey_low.Text);
            }
            catch (System.FormatException ex)
            {
                MessageBox.Show(ex.Message + "Пример заполненного поля: 48,5.");
            }
        }
        private void storey_high_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (storey_high.Text != string.Empty)
                    storey_sldr.HigherValue = Convert.ToDouble(storey_high.Text);
            }
            catch (System.FormatException ex)
            {
                MessageBox.Show(ex.Message + "Пример заполненного поля: 48,5.");
            }
        }
        private void storey_sldr_LowerValueChanged(object sender, RoutedEventArgs e)
        {
            storey_low.Text = Convert.ToInt32(storey_sldr.LowerValue).ToString();
        }

        private void storey_sldr_HigherValueChanged(object sender, RoutedEventArgs e)
        {
            storey_high.Text = Convert.ToInt32(storey_sldr.HigherValue).ToString();
        }
        private void rooms_low_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (rooms_low.Text != string.Empty)
                    rooms_sldr.LowerValue = Convert.ToDouble(rooms_low.Text);
            }
            catch (System.FormatException ex)
            {
                MessageBox.Show(ex.Message + "Пример заполненного поля: 48,5.");
            }
        }
        private void rooms_high_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (rooms_high.Text != string.Empty)
                    rooms_sldr.HigherValue = Convert.ToDouble(rooms_high.Text);
            }
            catch (System.FormatException ex)
            {
                MessageBox.Show(ex.Message + "Пример заполненного поля: 48,5.");
            }
        }
        private void rooms_sldr_LowerValueChanged(object sender, RoutedEventArgs e)
        {
            rooms_low.Text = Convert.ToInt32(rooms_sldr.LowerValue).ToString();
        }

        private void rooms_sldr_HigherValueChanged(object sender, RoutedEventArgs e)
        {
            rooms_high.Text = Convert.ToInt32(rooms_sldr.HigherValue).ToString();
        }
        private void height_low_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (height_low.Text != string.Empty)
                    height_sldr.LowerValue = Convert.ToDouble(height_low.Text);
            }
            catch (System.FormatException ex)
            {
                MessageBox.Show(ex.Message + "Пример заполненного поля: 48,5.");
            }
        }

        private void height_high_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (height_high.Text != string.Empty)
                    height_sldr.HigherValue = Convert.ToDouble(height_high.Text);
            }
            catch (System.FormatException ex)
            {
                MessageBox.Show(ex.Message + "Пример заполненного поля: 48,5.");
            }
        }

        private void height_sldr_LowerValueChanged(object sender, RoutedEventArgs e)
        {
            height_low.Text = (Math.Round(Convert.ToDouble(height_sldr.LowerValue), 2)).ToString();
        }

        private void height_sldr_HigherValueChanged(object sender, RoutedEventArgs e)
        {
            height_high.Text = (Math.Round(Convert.ToDouble(height_sldr.HigherValue), 2)).ToString();
        }
        private void square_hall_low_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (square_hall_low.Text != string.Empty)
                    square_hall_sldr.LowerValue = Convert.ToDouble(square_hall_low.Text);
            }
            catch (System.FormatException ex)
            {
                MessageBox.Show(ex.Message + "Пример заполненного поля: 48,5.");
            }
        }

        private void square_hall_high_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (square_hall_high.Text != string.Empty)
                    square_hall_sldr.HigherValue = Convert.ToDouble(square_hall_high.Text);
            }
            catch (System.FormatException ex)
            {
                MessageBox.Show(ex.Message + "Пример заполненного поля: 48,5.");
            }
        }

        private void square_hall_sldr_LowerValueChanged(object sender, RoutedEventArgs e)
        {
            square_hall_low.Text = (Math.Round(Convert.ToDouble(square_hall_sldr.LowerValue), 2)).ToString();
        }

        private void square_hall_sldr_HigherValueChanged(object sender, RoutedEventArgs e)
        {
            square_hall_high.Text = (Math.Round(Convert.ToDouble(square_hall_sldr.HigherValue), 2)).ToString();
        }
        private void living_square_low_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (living_square_low.Text != string.Empty)
                    living_square_sldr.LowerValue = Convert.ToDouble(living_square_low.Text);
            }
            catch (System.FormatException ex)
            {
                MessageBox.Show(ex.Message + "Пример заполненного поля: 48,5.");
            }
        }

        private void living_square_high_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (living_square_high.Text != string.Empty)
                    living_square_sldr.HigherValue = Convert.ToDouble(living_square_high.Text);
            }
            catch (System.FormatException ex)
            {
                MessageBox.Show(ex.Message + "Пример заполненного поля: 48,5.");
            }
        }

        private void living_square_sldr_LowerValueChanged(object sender, RoutedEventArgs e)
        {
            living_square_low.Text = (Math.Round(Convert.ToDouble(living_square_sldr.LowerValue), 2)).ToString();
        }

        private void living_square_sldr_HigherValueChanged(object sender, RoutedEventArgs e)
        {
            living_square_high.Text = (Math.Round(Convert.ToDouble(living_square_sldr.HigherValue), 2)).ToString();
        }
        private void branch_low_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (branch_low.Text != string.Empty)
                    branch_sldr.LowerValue = Convert.ToDouble(branch_low.Text);
            }
            catch (System.FormatException ex)
            {
                MessageBox.Show(ex.Message + "Пример заполненного поля: 48,5.");
            }
        }

        private void branch_high_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (branch_high.Text != string.Empty)
                    branch_sldr.HigherValue = Convert.ToDouble(branch_high.Text);
            }
            catch (System.FormatException ex)
            {
                MessageBox.Show(ex.Message + "Пример заполненного поля: 48,5.");
            }
        }

        private void branch_sldr_LowerValueChanged(object sender, RoutedEventArgs e)
        {
            branch_low.Text = (Math.Round(Convert.ToDouble(branch_sldr.LowerValue), 2)).ToString();
        }

        private void branch_sldr_HigherValueChanged(object sender, RoutedEventArgs e)
        {
            branch_high.Text = (Math.Round(Convert.ToDouble(branch_sldr.HigherValue), 2)).ToString();
        }
        private void balcony_low_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (balcony_low.Text != string.Empty)
                    balcony_sldr.LowerValue = Convert.ToDouble(balcony_low.Text);
            }
            catch (System.FormatException ex)
            {
                MessageBox.Show(ex.Message + "Пример заполненного поля: 48,5.");
            }
        }

        private void balcony_high_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (balcony_high.Text != string.Empty)
                    balcony_sldr.HigherValue = Convert.ToDouble(balcony_high.Text);
            }
            catch (System.FormatException ex)
            {
                MessageBox.Show(ex.Message + "Пример заполненного поля: 48,5.");
            }
        }

        private void balcony_sldr_LowerValueChanged(object sender, RoutedEventArgs e)
        {
            balcony_low.Text = (Math.Round(Convert.ToDouble(balcony_sldr.LowerValue), 2)).ToString();
        }

        private void balcony_sldr_HigherValueChanged(object sender, RoutedEventArgs e)
        {
            balcony_high.Text = (Math.Round(Convert.ToDouble(balcony_sldr.HigherValue), 2)).ToString();
        }

    }
}
