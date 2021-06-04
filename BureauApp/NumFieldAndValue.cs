using System;

namespace BureauApp
{
    class NumFieldAndValue
    {
        private string field_name;
        public string Field_name 
        { 
            get { return field_name;}
        }

        private double lower_value;
        public double Lower_value
        {
            get { return lower_value;}
        }
        private double higher_value;
        public double Higher_value
        {
            get { return higher_value;}
        }

        public NumFieldAndValue(string field, string l_val, string h_val)
        {
            field_name = field;
            lower_value = Convert.ToDouble(l_val);
            higher_value = Convert.ToDouble(h_val);
        }
    }
}
