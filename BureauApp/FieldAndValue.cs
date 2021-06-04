namespace BureauApp
{
    class FieldAndValue
    {
        private string field_name;
        public string Field_name 
        { 
            get { return field_name;}
        }
        private string value;
        public string Value 
        { 
            get {return value;}
        }

        public FieldAndValue(string field, string val)
        {
            field_name = field;
            value = val;
        }
    }
}
